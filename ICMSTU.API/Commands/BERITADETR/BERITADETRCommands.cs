using FluentValidation;
using MediatR;
using System.Collections.Generic;
using System;

namespace ICMSTU.API.Commands.BERITADETR
{
  public class BERITADETRCreate : IRequest<Models.Entities.BERITADETR>
  {
    public string UnitKey { get; set; }
    public string NoBA { get; set; }
    public string MtgKey { get; set; }
    public Decimal? Nilai { get; set; }
    public int IdMATANGR { get; set; }
    public int IdBerita { get; set; }
    public DateTime? DateCreate { get; set; }
    public DateTime? DateUpdate { get; set; }
  }

  public class BERITADETRUpdate : IRequest<Models.Entities.BERITADETR>
  {
    public string UnitKey { get; set; }
    public string NoBA { get; set; }
    public string MtgKey { get; set; }
    public Decimal? Nilai { get; set; }
    public int Id { get; set; }
    public int IdMATANGR { get; set; }
    public int IdBerita { get; set; }
    public DateTime? DateCreate { get; set; }
    public DateTime? DateUpdate { get; set; }
  }

  public class BERITADETRDelete : IRequest
  {
    public int? Id { get; set; }
  }

  public class BERITADETRBulkDelete : IRequest
  {
    public List<int> Ids { get; set; }
  }

  public class BERITADETRCreateValidator : AbstractValidator<BERITADETRCreate>
  {
    public BERITADETRCreateValidator()
    {
      
    }
  }

  public class BERITADETRUpdateValidator : AbstractValidator<BERITADETRUpdate>
  {
    public BERITADETRUpdateValidator()
    {
      
    }
  }

  public class BERITADETRDeleteValidator : AbstractValidator<BERITADETRDelete>
  {
    public BERITADETRDeleteValidator()
    {
      RuleFor(m => m.Id).NotNull();
    }
  }

  public class BERITADETRBulkDeleteValidator : AbstractValidator<BERITADETRBulkDelete>
  {
    public BERITADETRBulkDeleteValidator()
    {
      RuleFor(m => m.Ids).NotEmpty();
    }
  }
}
