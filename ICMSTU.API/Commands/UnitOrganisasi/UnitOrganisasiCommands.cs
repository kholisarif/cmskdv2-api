using FluentValidation;
using MediatR;
using System.Collections.Generic;

namespace ICMSTU.API.Commands.UnitOrganisasi
{
  public class UnitOrganisasiCreate : IRequest<Models.Entities.UnitOrganisasi>
  {
    public int? ParentId { get; set; }
    public int? Lvl { get; set; }
    public string Kode { get; set; }
    public string Nama { get; set; }
    public string Akronim { get; set; }
    public string Alamat { get; set; }
    public string Telepon { get; set; }
    public string Tipe { get; set; }
  }

  public class UnitOrganisasiUpdate : IRequest<Models.Entities.UnitOrganisasi>
  {
    public int? Id { get; set; }
    public int? ParentId { get; set; }
    public int? Lvl { get; set; }
    public string Kode { get; set; }
    public string Nama { get; set; }
    public string Akronim { get; set; }
    public string Alamat { get; set; }
    public string Telepon { get; set; }
    public string Tipe { get; set; }
  }

  public class UnitOrganisasiDelete : IRequest
  {
    public int? Id;
  }

  public class UnitOrganisasiBulkDelete : IRequest
  {
    public List<int> Ids { get; set; }
  }

  public class UnitOrganisasiCreateValidator : AbstractValidator<UnitOrganisasiCreate>
  {
    public UnitOrganisasiCreateValidator()
    {
      RuleFor(u => u.Lvl).NotEmpty();
      RuleFor(u => u.Kode).NotEmpty();
      RuleFor(u => u.Nama).NotEmpty();
      RuleFor(u => u.Tipe).NotEmpty();
    }
  }

  public class UnitOrganisasiUpdateValidator : AbstractValidator<UnitOrganisasiUpdate>
  {
    public UnitOrganisasiUpdateValidator()
    {
      RuleFor(u => u.Id).NotEmpty();
      RuleFor(u => u.Lvl).NotEmpty();
      RuleFor(u => u.Kode).NotEmpty();
      RuleFor(u => u.Nama).NotEmpty();
      RuleFor(u => u.Tipe).NotEmpty();
    }
  }

  public class UnitOrganisasiDeleteValidator : AbstractValidator<UnitOrganisasiDelete>
  {
    public UnitOrganisasiDeleteValidator()
    {
      RuleFor(u => u.Id).NotEmpty();
    }
  }

  public class UnitOrganisasiBulkDeleteValidator : AbstractValidator<UnitOrganisasiBulkDelete>
  {
    public UnitOrganisasiBulkDeleteValidator()
    {
      RuleFor(m => m.Ids).NotEmpty();
    }
  }
}
