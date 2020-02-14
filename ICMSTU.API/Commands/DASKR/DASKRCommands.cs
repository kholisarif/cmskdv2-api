using FluentValidation;
using MediatR;
using System.Collections.Generic;
using System;

namespace ICMSTU.API.Commands.DASKR
{
  public class DASKRCreate : IRequest<Models.Entities.DASKR>
  {
    public string KdKegUnit { get; set; }
    public string MTGkey { get; set; }
    public string UnitKey { get; set; }
    public string IdxDask { get; set; }
    public Decimal? Nilai { get; set; }
    public DateTime? DateCreate { get; set; }
    public DateTime? DateUpdate { get; set; }
  }

  public class DASKRUpdate : IRequest<Models.Entities.DASKR>
  {
    public string KdKegUnit { get; set; }
    public string MTGkey { get; set; }
    public string UnitKey { get; set; }
    public string IdxDask { get; set; }
    public Decimal? Nilai { get; set; }
    public int Id { get; set; }
    public DateTime? DateCreate { get; set; }
    public DateTime? DateUpdate { get; set; }
  }

  public class DASKRDelete : IRequest
  {
    public int? Id { get; set; }
  }

  public class DASKRBulkDelete : IRequest
  {
    public List<int> Ids { get; set; }
  }

  public class DASKRCreateValidator : AbstractValidator<DASKRCreate>
  {
    public DASKRCreateValidator()
    {
      
    }
  }

  public class DASKRUpdateValidator : AbstractValidator<DASKRUpdate>
  {
    public DASKRUpdateValidator()
    {
      
    }
  }

  public class DASKRDeleteValidator : AbstractValidator<DASKRDelete>
  {
    public DASKRDeleteValidator()
    {
      RuleFor(m => m.Id).NotNull();
    }
  }

  public class DASKRBulkDeleteValidator : AbstractValidator<DASKRBulkDelete>
  {
    public DASKRBulkDeleteValidator()
    {
      RuleFor(m => m.Ids).NotEmpty();
    }
  }
}
