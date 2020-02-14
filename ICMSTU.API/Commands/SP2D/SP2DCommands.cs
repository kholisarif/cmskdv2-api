using FluentValidation;
using MediatR;
using System.Collections.Generic;
using System;

namespace ICMSTU.API.Commands.SP2D
{
  public class SP2DCreate : IRequest<Models.Entities.SP2D>
  {
    public string KeySP2D { get; set; }
    public string Jns_SP2D { get; set; }
    public string NIP { get; set; }
    public string KdBank { get; set; }
    public string UnitKey { get; set; }
    public string Jab_SP2D { get; set; }
    public string RekSP2D{ get; set; }
    public decimal? SaldoSP2D { get; set; }
    public string NPWPSP2D { get; set; }
    public DateTime? TglStopSP2D { get; set; }
    public decimal? SaldoSP2DT { get; set; }
    public int StAktif { get; set; }
    public DateTime? DateCreate { get; set; }
    public DateTime? DateUpdate { get; set; }
  }

  public class SP2DUpdate : IRequest<Models.Entities.SP2D>
  {
    public string KeySP2D { get; set; }
    public string Jns_SP2D { get; set; }
    public string NIP { get; set; }
    public string KdBank { get; set; }
    public string UnitKey { get; set; }
    public string Jab_SP2D { get; set; }
    public string RekSP2D{ get; set; }
    public decimal? SaldoSP2D { get; set; }
    public string NPWPSP2D { get; set; }
    public DateTime? TglStopSP2D { get; set; }
    public decimal? SaldoSP2DT { get; set; }
    public int Id { get; set; }
    public int StAktif { get; set; }
    public DateTime? DateCreate { get; set; }
    public DateTime? DateUpdate { get; set; }
  }

  public class SP2DDelete : IRequest
  {
    public int? Id { get; set; }
  }

  public class SP2DBulkDelete : IRequest
  {
    public List<int> Ids { get; set; }
  }

  public class SP2DCreateValidator : AbstractValidator<SP2DCreate>
  {
    public SP2DCreateValidator()
    {
      
    }
  }

  public class SP2DUpdateValidator : AbstractValidator<SP2DUpdate>
  {
    public SP2DUpdateValidator()
    {
      
    }
  }

  public class SP2DDeleteValidator : AbstractValidator<SP2DDelete>
  {
    public SP2DDeleteValidator()
    {
      RuleFor(m => m.Id).NotNull();
    }
  }

  public class SP2DBulkDeleteValidator : AbstractValidator<SP2DBulkDelete>
  {
    public SP2DBulkDeleteValidator()
    {
      RuleFor(m => m.Ids).NotEmpty();
    }
  }
}
