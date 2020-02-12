using FluentValidation;
using MediatR;
using System.Collections.Generic;
using System;

namespace ICMSTU.API.Commands.BPKDETR
{
  public class BPKDETRCreate : IRequest<Models.Entities.BPKDETR>
  {
    public string MTGkey { get; set; }
    public string KdKegUnit { get; set; }
    public string NoJetra { get; set; }
    public string UnitKey { get; set; }
    public string NoBPK { get; set; }
    public Decimal? Nilai { get; set; }
    public DateTime? DateCreate { get; set; }
    public DateTime? DateUpdate { get; set; }
  }

  public class BPKDETRUpdate : IRequest<Models.Entities.BPKDETR>
  {
    public string MTGkey { get; set; }
    public string KdKegUnit { get; set; }
    public string NoJetra { get; set; }
    public string UnitKey { get; set; }
    public string NoBPK { get; set; }
    public Decimal? Nilai { get; set; }
    public int Id { get; set; }
    public DateTime? DateCreate { get; set; }
    public DateTime? DateUpdate { get; set; }
  }

  public class BPKDETRDelete : IRequest
  {
    public int? Id { get; set; }
  }

  public class BPKDETRBulkDelete : IRequest
  {
    public List<int> Ids { get; set; }
  }

  public class BPKDETRCreateValidator : AbstractValidator<BPKDETRCreate>
  {
    public BPKDETRCreateValidator()
    {
      
    }
  }

  public class BPKDETRUpdateValidator : AbstractValidator<BPKDETRUpdate>
  {
    public BPKDETRUpdateValidator()
    {
      
    }
  }

  public class BPKDETRDeleteValidator : AbstractValidator<BPKDETRDelete>
  {
    public BPKDETRDeleteValidator()
    {
      RuleFor(m => m.Id).NotNull();
    }
  }

  public class BPKDETRBulkDeleteValidator : AbstractValidator<BPKDETRBulkDelete>
  {
    public BPKDETRBulkDeleteValidator()
    {
      RuleFor(m => m.Ids).NotEmpty();
    }
  }
}
