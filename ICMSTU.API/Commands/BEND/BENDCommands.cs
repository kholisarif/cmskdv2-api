using FluentValidation;
using MediatR;
using System.Collections.Generic;
using System;

namespace ICMSTU.API.Commands.BEND
{
  public class BENDCreate : IRequest<Models.Entities.BEND>
  {
    public string KeyBend { get; set; }
    public string Jns_Bend { get; set; }
    public string NIP { get; set; }
    public string KdBank { get; set; }
    public string UnitKey { get; set; }
    public string Jab_Bend { get; set; }
    public string RekBend{ get; set; }
    public decimal SaldoBend { get; set; }
    public string NPWPBend { get; set; }
    public DateTime TglStopBend { get; set; }
    public decimal SaldoBendT { get; set; }
    public int StAktif { get; set; }
    public DateTime DateCreate { get; set; }
    public DateTime DateUpdate { get; set; }
  }

  public class BENDUpdate : IRequest<Models.Entities.BEND>
  {
    public string KeyBend { get; set; }
    public string Jns_Bend { get; set; }
    public string NIP { get; set; }
    public string KdBank { get; set; }
    public string UnitKey { get; set; }
    public string Jab_Bend { get; set; }
    public string RekBend{ get; set; }
    public decimal SaldoBend { get; set; }
    public string NPWPBend { get; set; }
    public DateTime TglStopBend { get; set; }
    public decimal SaldoBendT { get; set; }
    public int Id { get; set; }
    public int StAktif { get; set; }
    public DateTime DateCreate { get; set; }
    public DateTime DateUpdate { get; set; }
  }

  public class BENDDelete : IRequest
  {
    public int? Id { get; set; }
  }

  public class BENDBulkDelete : IRequest
  {
    public List<int> Ids { get; set; }
  }

  public class BENDCreateValidator : AbstractValidator<BENDCreate>
  {
    public BENDCreateValidator()
    {
      
    }
  }

  public class BENDUpdateValidator : AbstractValidator<BENDUpdate>
  {
    public BENDUpdateValidator()
    {
      
    }
  }

  public class BENDDeleteValidator : AbstractValidator<BENDDelete>
  {
    public BENDDeleteValidator()
    {
      RuleFor(m => m.Id).NotNull();
    }
  }

  public class BENDBulkDeleteValidator : AbstractValidator<BENDBulkDelete>
  {
    public BENDBulkDeleteValidator()
    {
      RuleFor(m => m.Ids).NotEmpty();
    }
  }
}
