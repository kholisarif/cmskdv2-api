using FluentValidation;
using MediatR;
using System.Collections.Generic;
using System;

namespace ICMSTU.API.Commands.NPDTBPL
{
  public class NPDTBPLCreate : IRequest<Models.Entities.NPDTBPL>
  {
    public string NoNPD { get; set; }
    public string NoTBPL { get; set; }
    public string UnitKey { get; set; }
    public int IdTrans { get; set; }
    public DateTime? TglKirim { get; set; }
    public DateTime? DateCreate { get; set; }
    public DateTime? DateUpdate { get; set; }
  }

  public class NPDTBPLUpdate : IRequest<Models.Entities.NPDTBPL>
  {
    public string NoNPD { get; set; }
    public string NoTBPL { get; set; }
    public string UnitKey { get; set; }
    public int IdTrans { get; set; }
    public DateTime? TglKirim { get; set; }
    public int Id { get; set; }
    public DateTime? DateCreate { get; set; }
    public DateTime? DateUpdate { get; set; }
  }

  public class NPDTBPLDelete : IRequest
  {
    public int? Id { get; set; }
  }

  public class NPDTBPLBulkDelete : IRequest
  {
    public List<int> Ids { get; set; }
  }

  public class NPDTBPLCreateValidator : AbstractValidator<NPDTBPLCreate>
  {
    public NPDTBPLCreateValidator()
    {
      
    }
  }

  public class NPDTBPLUpdateValidator : AbstractValidator<NPDTBPLUpdate>
  {
    public NPDTBPLUpdateValidator()
    {
      
    }
  }

  public class NPDTBPLDeleteValidator : AbstractValidator<NPDTBPLDelete>
  {
    public NPDTBPLDeleteValidator()
    {
      RuleFor(m => m.Id).NotNull();
    }
  }

  public class NPDTBPLBulkDeleteValidator : AbstractValidator<NPDTBPLBulkDelete>
  {
    public NPDTBPLBulkDeleteValidator()
    {
      RuleFor(m => m.Ids).NotEmpty();
    }
  }
}
