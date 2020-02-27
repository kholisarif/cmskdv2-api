using FluentValidation;
using MediatR;
using System.Collections.Generic;
using System;

namespace ICMSTU.API.Commands.NPD
{
  public class NPDCreate : IRequest<Models.Entities.NPD>
  {
    public string NonPD { get; set; }
    public string UnitKey { get; set; }
    public string KeyBend { get; set; }
    public int IdTrans { get; set; }
    public string Uraian { get; set; }
    public DateTime? TglNPD { get; set; }
    public DateTime? DateCreate { get; set; }
    public DateTime? DateUpdate { get; set; }
  }

  public class NPDUpdate : IRequest<Models.Entities.NPD>
  {
    public string NonPD { get; set; }
    public string UnitKey { get; set; }
    public string KeyBend { get; set; }
    public int IdTrans { get; set; }
    public string Uraian { get; set; }
    public DateTime? TglNPD { get; set; }
    public int Id { get; set; }
    public DateTime? DateCreate { get; set; }
    public DateTime? DateUpdate { get; set; }
  }

  public class NPDDelete : IRequest
  {
    public int? Id { get; set; }
  }

  public class NPDBulkDelete : IRequest
  {
    public List<int> Ids { get; set; }
  }

  public class NPDCreateValidator : AbstractValidator<NPDCreate>
  {
    public NPDCreateValidator()
    {
      
    }
  }

  public class NPDUpdateValidator : AbstractValidator<NPDUpdate>
  {
    public NPDUpdateValidator()
    {
      
    }
  }

  public class NPDDeleteValidator : AbstractValidator<NPDDelete>
  {
    public NPDDeleteValidator()
    {
      RuleFor(m => m.Id).NotNull();
    }
  }

  public class NPDBulkDeleteValidator : AbstractValidator<NPDBulkDelete>
  {
    public NPDBulkDeleteValidator()
    {
      RuleFor(m => m.Ids).NotEmpty();
    }
  }
}
