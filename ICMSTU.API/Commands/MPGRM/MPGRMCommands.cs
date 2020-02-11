using FluentValidation;
using MediatR;
using System.Collections.Generic;
using System;

namespace ICMSTU.API.Commands.MPGRM
{
  public class MPGRMCreate : IRequest<Models.Entities.MPGRM>
  {
    public string IdPrgrm { get; set; }
    public string UnitKey { get; set; }
    public string NmPrgrm { get; set; }
    public string NuPrgrm { get; set; }
    public DateTime? DateCreate { get; set; }
    public DateTime? DateUpdate { get; set; }
  }

  public class MPGRMUpdate : IRequest<Models.Entities.MPGRM>
  {
    public string IdPrgrm { get; set; }
    public string UnitKey { get; set; }
    public string NmPrgrm { get; set; }
    public string NuPrgrm { get; set; }
    public int Id { get; set; }
    public DateTime? DateCreate { get; set; }
    public DateTime? DateUpdate { get; set; }
  }

  public class MPGRMDelete : IRequest
  {
    public int? Id { get; set; }
  }

  public class MPGRMBulkDelete : IRequest
  {
    public List<int> Ids { get; set; }
  }

  public class MPGRMCreateValidator : AbstractValidator<MPGRMCreate>
  {
    public MPGRMCreateValidator()
    {
      
    }
  }

  public class MPGRMUpdateValidator : AbstractValidator<MPGRMUpdate>
  {
    public MPGRMUpdateValidator()
    {
      
    }
  }

  public class MPGRMDeleteValidator : AbstractValidator<MPGRMDelete>
  {
    public MPGRMDeleteValidator()
    {
      RuleFor(m => m.Id).NotNull();
    }
  }

  public class MPGRMBulkDeleteValidator : AbstractValidator<MPGRMBulkDelete>
  {
    public MPGRMBulkDeleteValidator()
    {
      RuleFor(m => m.Ids).NotEmpty();
    }
  }
}
