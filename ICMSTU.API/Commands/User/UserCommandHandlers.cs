using AutoMapper;
using ICMSTU.API.Dtos;
using ICMSTU.API.Exceptions;
using ICMSTU.API.Helpers;
using ICMSTU.API.Infrastructures;
using ICMSTU.API.Models.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using JwtRegisteredClaimNames = Microsoft.IdentityModel.JsonWebTokens.JwtRegisteredClaimNames;

namespace ICMSTU.API.Commands.User
{
  public class UserCreateCommandHandlers :
    IRequestHandler<UserCreate, UserDto>,
    IRequestHandler<UserUpdate, UserDto>,
    IRequestHandler<UserDelete>, IRequestHandler<UserBulkDelete>,
    IRequestHandler<UserLogin, object>,
    IRequestHandler<ValidateRefreshToken, object>
  {
    private readonly DataContext _ctx;
    private readonly IMapper _mapper;
    private readonly IConfiguration _config;

    public UserCreateCommandHandlers(DataContext ctx, IMapper mapper, IConfiguration config)
    {
      _ctx = ctx;
      _mapper = mapper;
      _config = config;
    }

    public async Task<UserDto> Handle(UserCreate message, CancellationToken cancellationToken)
    {
      var model = _mapper.Map<Models.Entities.User>(message);

      model.UserRoleCollection = new List<Models.Entities.UserRole>();

      foreach (var id in message.RoleId)
      {
        model.UserRoleCollection.Add(new Models.Entities.UserRole { RoleId = id, User = model });
      }

      await _ctx.AddAsync(model, cancellationToken);

      await _ctx.SaveChangesAsync(cancellationToken);

      return _mapper.Map<UserDto>(model);
    }

    public async Task<UserDto> Handle(UserUpdate message, CancellationToken cancellationToken)
    {
      var model = await _ctx.User.SingleOrDefaultAsync(u => u.Id == message.Id, cancellationToken);

      if (model == null) throw new NoRecordException();

      if (!PasswordHasher.Validate(model.Password, message.OldPassword))
        throw new IncorrectPasswordException();

      _mapper.Map(message, model);

      await _ctx.SaveChangesAsync(cancellationToken);

      return _mapper.Map<UserDto>(model);
    }

    public async Task<Unit> Handle(UserDelete message, CancellationToken cancellationToken)
    {
      var model = await _ctx.User.SingleOrDefaultAsync(u => u.Id == message.Id, cancellationToken);

      if (model == null) throw new NoRecordException();

      _ctx.Remove(model);

      await _ctx.SaveChangesAsync(cancellationToken);

      return Unit.Value;
    }

    public async Task<Unit> Handle(UserBulkDelete request, CancellationToken cancellationToken)
    {
      var models = await _ctx.User
        .Where(u => request.Ids.Any(id => u.Id == id))
        .ToListAsync(cancellationToken);

      _ctx.RemoveRange(models);

      await _ctx.SaveChangesAsync(cancellationToken);

      return Unit.Value;
    }

    public async Task<dynamic> Handle(UserLogin request, CancellationToken cancellationToken)
    {
      var user = await _ctx.User
        .Include(u => u.UserRoleCollection)
        .ThenInclude(u => u.Role)
        .SingleOrDefaultAsync(u => u.Username == request.Username, cancellationToken);

      if (user == null) throw new NoRecordException();

      if (!PasswordHasher.Validate(user.Password, request.Password))
        throw new NoRecordException();

      var refreshToken = await CreateRefreshToken(cancellationToken, user);

      var token = GenerateToken(user);

      return new { Jwt = token, RefreshToken = refreshToken };
    }

    private async Task<string> CreateRefreshToken(CancellationToken cancellationToken, Models.Entities.User user)
    {
      using (var transaction = await _ctx.Database.BeginTransactionAsync(cancellationToken))
      {
        try
        {
          var existingRefreshToken = await _ctx.RefreshToken.SingleOrDefaultAsync(r => r.UserId == user.Id, cancellationToken);

          if (existingRefreshToken != null)
          {
            _ctx.RefreshToken.Remove(existingRefreshToken);

            await _ctx.SaveChangesAsync(cancellationToken);
          }

          var refreshToken = new RefreshToken
          {
            UserId = user.Id,
            Token = Guid.NewGuid().ToString(),
            IssuedAt = DateTime.UtcNow,
            ExpireAt = DateTime.UtcNow.AddDays(1)
          };

          await _ctx.AddAsync(refreshToken, cancellationToken);

          await _ctx.SaveChangesAsync(cancellationToken);

          transaction.Commit();

          return refreshToken.Token;
        }
        catch (Exception)
        {
          transaction.Rollback();
          throw new Exception("Token refresh creation failed");
        }
      }
    }

    public async Task<object> Handle(ValidateRefreshToken request, CancellationToken cancellationToken)
    {
      var refreshToken = await _ctx.RefreshToken
        .Include(r => r.User)
        .ThenInclude(r => r.UserRoleCollection)
        .ThenInclude(r => r.Role)
        .SingleOrDefaultAsync(r => r.Token == request.Token, cancellationToken: cancellationToken);

      if (refreshToken == null) throw new NoRecordException();

      if (refreshToken.ExpireAt < DateTime.UtcNow) return new TokenExpiredException();

      var token = GenerateToken(refreshToken.User);

      return new { Jwt = token, RefreshToken = refreshToken.Token };
    }

    private List<Claim> GetClaims(Models.Entities.User user)
    {
      var roleNameClaims = user.UserRoleCollection.Select(ur => new Claim("roleNames", ur.Role.Nama)).ToList();
      var roleIds = user.UserRoleCollection.Select(ur => new Claim("roleIds", ur.Role.Id.ToString())).ToList();

      var claims = new List<Claim>();

      claims.AddRange(new List<Claim>
      {
        new Claim(JwtRegisteredClaimNames.Jti, user.Id.ToString()),
        new Claim(JwtRegisteredClaimNames.NameId, user.Username)
      }.Union(roleNameClaims).Union(roleIds));

      return claims;
    }

    private SigningCredentials SigningCredentials()
    {
      var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["TokenOptions:Key"]));

      var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

      return creds;
    }

    private string GenerateToken(Models.Entities.User user)
    {
      var claims = GetClaims(user);

      var token = new JwtSecurityToken(
        issuer: _config["TokenOptions:Issuer"],
        audience: _config["TokenOptions:Audience"],
        claims: claims,
        expires: DateTime.UtcNow.AddMinutes(10),
        signingCredentials: SigningCredentials()
      );

      return new JwtSecurityTokenHandler().WriteToken(token);
    }
  }
}
