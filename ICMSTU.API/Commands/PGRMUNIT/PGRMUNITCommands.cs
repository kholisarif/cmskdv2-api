using FluentValidation;
using MediatR;
using System.Collections.Generic;
using System;

namespace ICMSTU.API.Commands.PGRMUNIT
{
  public class PGRMUNITCreate : IRequest<Models.Entities.PGRMUNIT>
  {
    public string kdtahap { get; set; }
    //public Tahapan Tahapan { get; set; }
    public string UnitKey { get; set; }
    public string IdPrgrm { get; set; }
    //public MProgram Program { get; set; }
    //public int UnitOrganisasiId { get; set; }
    //public UnitOrganisasi UnitOrganisasi { get; set; }
    public string Target { get; set; }
    public string Sasaran { get; set; }
    public int? NoPrio { get; set; }
    public DateTime? DateCreate { get; set; }
    public DateTime? DateUpdate { get; set; }
  }

  public class PGRMUNITUpdate : IRequest<Models.Entities.PGRMUNIT>
  {
    public int Id { get; set; }
    public string kdtahap { get; set; }
    //public Tahapan Tahapan { get; set; }
    public string UnitKey { get; set; }
    public string IdPrgrm { get; set; }
    //public MProgram Program { get; set; }
    //public int UnitOrganisasiId { get; set; }
    //public UnitOrganisasi UnitOrganisasi { get; set; }
    public string Target { get; set; }
    public string Sasaran { get; set; }
    public int? NoPrio { get; set; }
    public DateTime? DateCreate { get; set; }
    public DateTime? DateUpdate { get; set; }
  }

  public class PGRMUNITDelete : IRequest
  {
    public int? Id { get; set; }
  }

  public class PGRMUNITBulkDelete : IRequest
  {
    public List<int> Ids { get; set; }
  }

  public class PGRMUNITCreateValidator : AbstractValidator<PGRMUNITCreate>
  {
    public PGRMUNITCreateValidator()
    {
      
    }
  }

  public class PGRMUNITUpdateValidator : AbstractValidator<PGRMUNITUpdate>
  {
    public PGRMUNITUpdateValidator()
    {
      
    }
  }

  public class PGRMUNITDeleteValidator : AbstractValidator<PGRMUNITDelete>
  {
    public PGRMUNITDeleteValidator()
    {
      RuleFor(m => m.Id).NotNull();
    }
  }

  public class PGRMUNITBulkDeleteValidator : AbstractValidator<PGRMUNITBulkDelete>
  {
    public PGRMUNITBulkDeleteValidator()
    {
      RuleFor(m => m.Ids).NotEmpty();
    }
  }
}
