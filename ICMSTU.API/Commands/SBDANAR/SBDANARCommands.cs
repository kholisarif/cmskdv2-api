using FluentValidation;
using MediatR;
using System.Collections.Generic;
using System;

namespace ICMSTU.API.Commands.SBDANAR
{
  public class SBDANARCreate : IRequest<Models.Entities.SBDANAR>
  {
    public string MTGkey { get; set; }
    public string KdKegUnit { get; set; }
    public string UnitKey { get; set; }
    public string NoBPK { get; set; }
    public string KdDana { get; set; }
    public Decimal? Nilai { get; set; }
    public int IdJDANA { get; set; }
    public string NoJetra { get; set; }
    public DateTime? DateCreate { get; set; }
    public DateTime? DateUpdate { get; set; }
  }

  public class SBDANARUpdate : IRequest<Models.Entities.SBDANAR>
  {
    public string MTGkey { get; set; }
    public string KdKegUnit { get; set; }
    public string UnitKey { get; set; }
    public string NoBPK { get; set; }
    public string KdDana { get; set; }
    public Decimal? Nilai { get; set; }
    public int Id { get; set; }
    public int IdJDANA { get; set; }
    public string NoJetra { get; set; }
    public DateTime? DateCreate { get; set; }
    public DateTime? DateUpdate { get; set; }
  }

  public class SBDANARDelete : IRequest
  {
    public int? Id { get; set; }
  }

  public class SBDANARBulkDelete : IRequest
  {
    public List<int> Ids { get; set; }
  }

  public class SBDANARCreateValidator : AbstractValidator<SBDANARCreate>
  {
    public SBDANARCreateValidator()
    {
      
    }
  }

  public class SBDANARUpdateValidator : AbstractValidator<SBDANARUpdate>
  {
    public SBDANARUpdateValidator()
    {
      
    }
  }

  public class SBDANARDeleteValidator : AbstractValidator<SBDANARDelete>
  {
    public SBDANARDeleteValidator()
    {
      RuleFor(m => m.Id).NotNull();
    }
  }

  public class SBDANARBulkDeleteValidator : AbstractValidator<SBDANARBulkDelete>
  {
    public SBDANARBulkDeleteValidator()
    {
      RuleFor(m => m.Ids).NotEmpty();
    }
  }
}
