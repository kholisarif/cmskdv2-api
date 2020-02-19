using FluentValidation;
using MediatR;
using System.Collections.Generic;
using System;

namespace ICMSTU.API.Commands.BPKDETRDANA
{
  public class BPKDETRDANACreate : IRequest<Models.Entities.BPKDETRDANA>
  {
    public string MTGkey { get; set; }
    public string KdKegUnit { get; set; }
    public string UnitKey { get; set; }
    public string NoBPK { get; set; }
    public string KdDana { get; set; }
    public Decimal? Nilai { get; set; }
    public string NoJetra { get; set; }
    public DateTime? DateCreate { get; set; }
    public DateTime? DateUpdate { get; set; }
  }

  public class BPKDETRDANAUpdate : IRequest<Models.Entities.BPKDETRDANA>
  {
    public string MTGkey { get; set; }
    public string KdKegUnit { get; set; }
    public string UnitKey { get; set; }
    public string NoBPK { get; set; }
    public string KdDana { get; set; }
    public Decimal? Nilai { get; set; }
    public int Id { get; set; }
    public string NoJetra { get; set; }
    public DateTime? DateCreate { get; set; }
    public DateTime? DateUpdate { get; set; }
  }

  public class BPKDETRDANADelete : IRequest
  {
    public int? Id { get; set; }
  }

  public class BPKDETRDANABulkDelete : IRequest
  {
    public List<int> Ids { get; set; }
  }

  public class BPKDETRDANACreateValidator : AbstractValidator<BPKDETRDANACreate>
  {
    public BPKDETRDANACreateValidator()
    {
      
    }
  }

  public class BPKDETRDANAUpdateValidator : AbstractValidator<BPKDETRDANAUpdate>
  {
    public BPKDETRDANAUpdateValidator()
    {
      
    }
  }

  public class BPKDETRDANADeleteValidator : AbstractValidator<BPKDETRDANADelete>
  {
    public BPKDETRDANADeleteValidator()
    {
      RuleFor(m => m.Id).NotNull();
    }
  }

  public class BPKDETRDANABulkDeleteValidator : AbstractValidator<BPKDETRDANABulkDelete>
  {
    public BPKDETRDANABulkDeleteValidator()
    {
      RuleFor(m => m.Ids).NotEmpty();
    }
  }
}
