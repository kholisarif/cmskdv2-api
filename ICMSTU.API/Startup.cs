using AutoMapper;
using FluentValidation;
using FluentValidation.AspNetCore;
using ICMSTU.API.Helpers;
using ICMSTU.API.Infrastructures;
using MediatR;
using Microsoft.AspNet.OData.Builder;
using Microsoft.AspNet.OData.Extensions;
using Microsoft.AspNet.OData.Formatter;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using Microsoft.Net.Http.Headers;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using Swashbuckle.AspNetCore.Swagger;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Net;
using System.Text;

namespace ICMSTU.API
{
  public class Startup
  {
    public Startup(IConfiguration configuration)
    {
      Configuration = configuration;
    }

    public IConfiguration Configuration { get; }

    // This method gets called by the runtime. Use this method to add services to the container.
    public void ConfigureServices(IServiceCollection services)
    {
      services.AddMvc(opt =>
      {
        opt.EnableEndpointRouting = false;

        var policy = new AuthorizationPolicyBuilder()
          .RequireAuthenticatedUser()
          .Build();

        //opt.Filters.Add(new AuthorizeFilter(policy));

      }).AddJsonOptions(opt =>
      {
        opt.SerializerSettings.ContractResolver = new CamelCasePropertyNamesContractResolver();
        opt.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore;
      })
        .AddFluentValidation(opt =>
        {
          opt.RegisterValidatorsFromAssemblyContaining<Startup>();
          opt.RunDefaultMvcValidationAfterFluentValidationExecutes = false;
          ValidatorOptions.LanguageManager.Culture = new CultureInfo("id-ID");
        })
        .SetCompatibilityVersion(CompatibilityVersion.Version_2_2);

      services.AddApiVersioning(opt =>
      {
        opt.ReportApiVersions = true;
        opt.DefaultApiVersion = new ApiVersion(1, 0);
        opt.AssumeDefaultVersionWhenUnspecified = true;
      });

      services.AddMediatR(typeof(Startup).Assembly);

      services.AddDbContext<DataContext>((provider, opt) =>
      {
        var httpContext = provider.GetService<IHttpContextAccessor>().HttpContext;
        var tahun = httpContext?.Request.Headers["x-api-tahun"];
        opt.UseSqlServer(Configuration.SetDbYear(tahun?.ToString().ToNullableInt()));
      });

      services.AddOData().EnableApiVersioning();

      services.AddODataQueryFilter();

      services.AddMvcCore(opt =>
      {
        foreach (var outputFormatter in opt.OutputFormatters.OfType<ODataOutputFormatter>()
          .Where(_ => _.SupportedMediaTypes.Count == 0))
        {
          outputFormatter.SupportedMediaTypes.Add(new MediaTypeHeaderValue("application/prs.odatatestxx-odata"));
        }

        foreach (var inputFormatter in opt.InputFormatters.OfType<ODataInputFormatter>()
          .Where(_ => _.SupportedMediaTypes.Count == 0))
        {
          inputFormatter.SupportedMediaTypes.Add(new MediaTypeHeaderValue("application/prs.odatatestxx-odata"));
        }
      });

      services.AddCors();

      services.AddAuthentication(opt =>
        {
          opt.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
          opt.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;

        })
        .AddJwtBearer(cfg =>
        {
          cfg.RequireHttpsMetadata = false;
          cfg.SaveToken = true;
          cfg.TokenValidationParameters = new TokenValidationParameters
          {
            ValidIssuer = Configuration["TokenOptions:Issuer"],
            ValidAudience = Configuration["TokenOptions:Audience"],
            ValidateAudience = false,
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Configuration["TokenOptions:Key"]))
          };
        });

      services.AddHttpClient();

      services.AddAutoMapper(typeof(MappingProfile));

      services.AddSwaggerGen(opt =>
      {
        opt.SwaggerDoc("v1", new Info { Title = "ICMSKD", Version = "1.0" });

        var security = new Dictionary<string, IEnumerable<string>>
        {
          {"Bearer", new string[] { }},
        };

        opt.AddSecurityDefinition("Bearer",
                new ApiKeyScheme
                {
                  In = "header",
                  Description = "Masukkan JWT Bearer Token",
                  Name = "Authorization",
                  Type = "apiKey"
                });

        opt.AddSecurityRequirement(security);
      });
    }

    // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
    public void Configure(IApplicationBuilder app, IHostingEnvironment env, VersionedODataModelBuilder oDataModelBuilder)
    {
      if (env.IsDevelopment())
        app.UseDeveloperExceptionPage();
      else
      {
        // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
        app.UseHsts();

        app.UseExceptionHandler(builder =>
        {
          builder.Run(async ctx =>
          {
            ctx.Response.StatusCode = (int)HttpStatusCode.InternalServerError;

            var error = ctx.Features.Get<IExceptionHandlerFeature>();

            if (error != null)
            {
              ctx.Response.AddApplicationError(error.Error.Message);
              await ctx.Response.WriteAsync(error.Error.Message);
            }
          });
        });
      }

      app.UseCors(opt => opt.AllowAnyHeader().AllowAnyMethod().AllowAnyOrigin());

      //app.UseHttpsRedirection();

      app.UseAuthentication();

      app.UseMvc(builder =>
      {
        builder.Select().Expand().Filter().OrderBy().Count().MaxTop(100);
        builder.MapVersionedODataRoutes("ODataRoutes", "odata", oDataModelBuilder.GetEdmModels());
        builder.EnableDependencyInjection();
      });

      app.UseSwagger();

      app.UseSwaggerUI(c =>
      {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "ICMSKD API v1.0");

      });
    }
  }
}