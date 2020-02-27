using FluentValidation;
using MediatR;
using System.Collections.Generic;
using System;

namespace ICMSTU.API.Commands.NPDBPK
{
  public class NPDBPKCreate : IRequest<Models.Entities.NPDBPK>
  {
    public string NoNPD { get; set; }
    public string NoBPK { get; set; }
    public string UnitKey { get; set; }
    public int IdTrans { get; set; }
    public DateTime? TglKirim { get; set; }
    public DateTime? DateCreate { get; set; }
    public DateTime? DateUpdate { get; set; }
  }

  public class NPDBPKUpdate : IRequest<Models.Entities.NPDBPK>
  {
    public string NoNPD { get; set; }
    public string NoBPK { get; set; }
    public string UnitKey { get; set; }
    public int IdTrans { get; set; }
    public DateTime? TglKirim { get; set; }
    public int Id { get; set; }
    public DateTime? DateCreate { get; set; }
    public DateTime? DateUpdate { get; set; }
  }

  public class NPDBPKDelete : IRequest
  {
    public int? Id { get; set; }
  }

  public class NPDBPKBulkDelete : IRequest
  {
    public List<int> Ids { get; set; }
  }

  public class NPDBPKCreateValidator : AbstractValidator<NPDBPKCreate>
  {
    public NPDBPKCreateValidator()
    {
      
    }
  }

  public class NPDBPKUpdateValidator : AbstractValidator<NPDBPKUpdate>
  {
    public NPDBPKUpdateValidator()
    {
      
    }
  }

  public class NPDBPKDeleteValidator : AbstractValidator<NPDBPKDelete>
  {
    public NPDBPKDeleteValidator()
    {
      RuleFor(m => m.Id).NotNull();
    }
  }

  public class NPDBPKBulkDeleteValidator : AbstractValidator<NPDBPKBulkDelete>
  {
    public NPDBPKBulkDeleteValidator()
    {
      RuleFor(m => m.Ids).NotEmpty();
    }
  }
}
