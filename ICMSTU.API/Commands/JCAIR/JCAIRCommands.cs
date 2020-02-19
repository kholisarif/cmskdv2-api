using FluentValidation;
using MediatR;
using System.Collections.Generic;
using System;

namespace ICMSTU.API.Commands.JCAIR
{
  public class JCAIRCreate : IRequest<Models.Entities.JCAIR>
  {
    public int StCair { get; set; }
    public string UraiCair { get; set; }
    public DateTime? DateCreate { get; set; }
    public DateTime? DateUpdate { get; set; }
  }

  public class JCAIRUpdate : IRequest<Models.Entities.JCAIR>
  {
    public int StCair { get; set; }
    public string UraiCair { get; set; }
    public int Id { get; set; }
    public DateTime? DateCreate { get; set; }
    public DateTime? DateUpdate { get; set; }
  }

  public class JCAIRDelete : IRequest
  {
    public int? Id { get; set; }
  }

  public class JCAIRBulkDelete : IRequest
  {
    public List<int> Ids { get; set; }
  }

  public class JCAIRCreateValidator : AbstractValidator<JCAIRCreate>
  {
    public JCAIRCreateValidator()
    {
      
    }
  }

  public class JCAIRUpdateValidator : AbstractValidator<JCAIRUpdate>
  {
    public JCAIRUpdateValidator()
    {
      
    }
  }

  public class JCAIRDeleteValidator : AbstractValidator<JCAIRDelete>
  {
    public JCAIRDeleteValidator()
    {
      RuleFor(m => m.Id).NotNull();
    }
  }

  public class JCAIRBulkDeleteValidator : AbstractValidator<JCAIRBulkDelete>
  {
    public JCAIRBulkDeleteValidator()
    {
      RuleFor(m => m.Ids).NotEmpty();
    }
  }
}
