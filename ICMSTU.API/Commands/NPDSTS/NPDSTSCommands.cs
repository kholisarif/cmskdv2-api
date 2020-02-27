using FluentValidation;
using MediatR;
using System.Collections.Generic;
using System;

namespace ICMSTU.API.Commands.NPDSTS
{
  public class NPDSTSCreate : IRequest<Models.Entities.NPDSTS>
  {
    public string NoNPD { get; set; }
    public string NoSTS { get; set; }
    public string UnitKey { get; set; }
    public int IdTrans { get; set; }
    public DateTime? TglKirim { get; set; }
    public DateTime? DateCreate { get; set; }
    public DateTime? DateUpdate { get; set; }
  }

  public class NPDSTSUpdate : IRequest<Models.Entities.NPDSTS>
  {
    public string NoNPD { get; set; }
    public string NoSTS { get; set; }
    public string UnitKey { get; set; }
    public int IdTrans { get; set; }
    public DateTime? TglKirim { get; set; }
    public int Id { get; set; }
    public DateTime? DateCreate { get; set; }
    public DateTime? DateUpdate { get; set; }
  }

  public class NPDSTSDelete : IRequest
  {
    public int? Id { get; set; }
  }

  public class NPDSTSBulkDelete : IRequest
  {
    public List<int> Ids { get; set; }
  }

  public class NPDSTSCreateValidator : AbstractValidator<NPDSTSCreate>
  {
    public NPDSTSCreateValidator()
    {
      
    }
  }

  public class NPDSTSUpdateValidator : AbstractValidator<NPDSTSUpdate>
  {
    public NPDSTSUpdateValidator()
    {
      
    }
  }

  public class NPDSTSDeleteValidator : AbstractValidator<NPDSTSDelete>
  {
    public NPDSTSDeleteValidator()
    {
      RuleFor(m => m.Id).NotNull();
    }
  }

  public class NPDSTSBulkDeleteValidator : AbstractValidator<NPDSTSBulkDelete>
  {
    public NPDSTSBulkDeleteValidator()
    {
      RuleFor(m => m.Ids).NotEmpty();
    }
  }
}
