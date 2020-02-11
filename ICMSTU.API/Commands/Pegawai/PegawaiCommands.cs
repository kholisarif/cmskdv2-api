using FluentValidation;
using MediatR;
using System.Collections.Generic;
using System;

namespace ICMSTU.API.Commands.Pegawai
{
  public class PegawaiCreate : IRequest<Models.Entities.Pegawai>
  {
    public string NIP { get; set; }
    public string KdGol { get; set; }
    public string UnitKey { get; set; }
    public string Nama { get; set; }
    //public int GolonganId { get; set; }
    //public Golongan Golongan { get; set; }
    //public int UnitOrganisasiId { get; set; }
    //public UnitOrganisasi UnitOrganisasi { get; set; }
    public string Alamat { get; set; }
    public string Jabatan { get; set; }
    public string PDDK { get; set; }
    public string NPWP { get; set; }
    public DateTime? DateCreate { get; set; }
    public DateTime? DateUpdate { get; set; }
  }

  public class PegawaiUpdate : IRequest<Models.Entities.Pegawai>
  {
    public int Id { get; set; }
    public string NIP { get; set; }
    public string KdGol { get; set; }
    public string UnitKey { get; set; }
    public string Nama { get; set; }
    //public int GolonganId { get; set; }
    //public Golongan Golongan { get; set; }
    //public int UnitOrganisasiId { get; set; }
    //public UnitOrganisasi UnitOrganisasi { get; set; }
    public string Alamat { get; set; }
    public string Jabatan { get; set; }
    public string PDDK { get; set; }
    public string NPWP { get; set; }
    public DateTime? DateCreate { get; set; }
    public DateTime? DateUpdate { get; set; }
  }

  public class PegawaiDelete : IRequest
  {
    public int? Id { get; set; }
  }

  public class PegawaiBulkDelete : IRequest
  {
    public List<int> Ids { get; set; }
  }

  public class PegawaiCreateValidator : AbstractValidator<PegawaiCreate>
  {
    public PegawaiCreateValidator()
    {
      
    }
  }

  public class PegawaiUpdateValidator : AbstractValidator<PegawaiUpdate>
  {
    public PegawaiUpdateValidator()
    {
      
    }
  }

  public class PegawaiDeleteValidator : AbstractValidator<PegawaiDelete>
  {
    public PegawaiDeleteValidator()
    {
      RuleFor(m => m.Id).NotNull();
    }
  }

  public class PegawaiBulkDeleteValidator : AbstractValidator<PegawaiBulkDelete>
  {
    public PegawaiBulkDeleteValidator()
    {
      RuleFor(m => m.Ids).NotEmpty();
    }
  }
}
