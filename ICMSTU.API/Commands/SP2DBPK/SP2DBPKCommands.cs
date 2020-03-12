using FluentValidation;
using MediatR;
using System.Collections.Generic;
using System;

namespace ICMSTU.API.Commands.SP2DBPK
{
  public class SP2DBPKCreate : IRequest<Models.Entities.SP2DBPK>
  {
    public string kdtahap { get; set; }
    //public Tahapan Tahapan { get; set; }
    public string UnitKey { get; set; }
    public string IdPrgrm { get; set; }
    //public MProgram Program { get; set; }
    //public int UnitOrganisasiId { get; set; }
    //public UnitOrganisasi UnitOrganisasi { get; set; }
    public int? IdMPGRM { get; set; }
    public string Target { get; set; }
    public string Sasaran { get; set; }
    public int? NoPrio { get; set; }
    public int? IdDAFTUNIT { get; set; }
    public DateTime? DateCreate { get; set; }
    public DateTime? DateUpdate { get; set; }
  }

  public class SP2DBPKUpdate : IRequest<Models.Entities.SP2DBPK>
  {
    public int Id { get; set; }
    public int? IdDAFTUNIT { get; set; }
    public string kdtahap { get; set; }
    //public Tahapan Tahapan { get; set; }
    public string UnitKey { get; set; }
    public string IdPrgrm { get; set; }
    //public MProgram Program { get; set; }
    //public int UnitOrganisasiId { get; set; }
    //public UnitOrganisasi UnitOrganisasi { get; set; }
    public int? IdMPGRM { get; set; }
    public string Target { get; set; }
    public string Sasaran { get; set; }
    public int? NoPrio { get; set; }
    public DateTime? DateCreate { get; set; }
    public DateTime? DateUpdate { get; set; }
  }

  public class SP2DBPKDelete : IRequest
  {
    public int? Id { get; set; }
  }

  public class SP2DBPKBulkDelete : IRequest
  {
    public List<int> Ids { get; set; }
  }

  public class SP2DBPKCreateValidator : AbstractValidator<SP2DBPKCreate>
  {
    public SP2DBPKCreateValidator()
    {
      
    }
  }

  public class SP2DBPKUpdateValidator : AbstractValidator<SP2DBPKUpdate>
  {
    public SP2DBPKUpdateValidator()
    {
      
    }
  }

  public class SP2DBPKDeleteValidator : AbstractValidator<SP2DBPKDelete>
  {
    public SP2DBPKDeleteValidator()
    {
      RuleFor(m => m.Id).NotNull();
    }
  }

  public class SP2DBPKBulkDeleteValidator : AbstractValidator<SP2DBPKBulkDelete>
  {
    public SP2DBPKBulkDeleteValidator()
    {
      RuleFor(m => m.Ids).NotEmpty();
    }
  }
}
