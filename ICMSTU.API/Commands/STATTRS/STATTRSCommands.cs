using FluentValidation;
using MediatR;
using System.Collections.Generic;
using System;

namespace ICMSTU.API.Commands.STATTRS
{
  public class STATTRSCreate : IRequest<Models.Entities.STATTRS>
  {
    public string KdDana { get; set; }
    public string NmDana { get; set; }
    public string Ket { get; set; }
    public string Type { get; set; }
    public DateTime? DateCreate { get; set; }
    public DateTime? DateUpdate { get; set; }
  }

  public class STATTRSUpdate : IRequest<Models.Entities.STATTRS>
  {
    public string KdDana { get; set; }
    public string NmDana { get; set; }
    public string Ket { get; set; }
    public int Id { get; set; }
    public string Type { get; set; }
    public DateTime? DateCreate { get; set; }
    public DateTime? DateUpdate { get; set; }
  }

  public class STATTRSDelete : IRequest
  {
    public int? Id { get; set; }
  }

  public class STATTRSBulkDelete : IRequest
  {
    public List<int> Ids { get; set; }
  }

  public class STATTRSCreateValidator : AbstractValidator<STATTRSCreate>
  {
    public STATTRSCreateValidator()
    {
      
    }
  }

  public class STATTRSUpdateValidator : AbstractValidator<STATTRSUpdate>
  {
    public STATTRSUpdateValidator()
    {
      
    }
  }

  public class STATTRSDeleteValidator : AbstractValidator<STATTRSDelete>
  {
    public STATTRSDeleteValidator()
    {
      RuleFor(m => m.Id).NotNull();
    }
  }

  public class STATTRSBulkDeleteValidator : AbstractValidator<STATTRSBulkDelete>
  {
    public STATTRSBulkDeleteValidator()
    {
      RuleFor(m => m.Ids).NotEmpty();
    }
  }
}
