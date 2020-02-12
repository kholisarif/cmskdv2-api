using FluentValidation;
using MediatR;
using System.Collections.Generic;
using System;

namespace ICMSTU.API.Commands.KEGUNIT
{
  public class KEGUNITCreate : IRequest<Models.Entities.KEGUNIT>
  {
    public string KdTahap { get; set; }
    public string UnitKey { get; set; }
    public string KdKegUnit { get; set; }
    public string IdPrgrm { get; set; }
    public int? NoPrior { get; set; }
    public string KdSifat{ get; set; }
    public string NIP { get; set; }
    public DateTime? TglAkhir { get; set; }
    public DateTime? TglAwal { get; set; }
    public Decimal? TargetP { get; set; }
    public string Lokasi { get; set; }
    public Decimal? JumlahMin1 { get; set; }
    public Decimal? Pagu { get; set; }
    public Decimal? JumlahPls1{ get; set; }
    public string Sasaran { get; set; }
    public string KetKeg { get; set; }
    public DateTime? DateCreate { get; set; }
    public DateTime? DateUpdate { get; set; }
  }

  public class KEGUNITUpdate : IRequest<Models.Entities.KEGUNIT>
  {
    public string KdTahap { get; set; }
    public string UnitKey { get; set; }
    public string KdKegUnit { get; set; }
    public string IdPrgrm { get; set; }
    public int? NoPrior { get; set; }
    public string KdSifat{ get; set; }
    public string NIP { get; set; }
    public DateTime? TglAkhir { get; set; }
    public DateTime? TglAwal { get; set; }
    public Decimal? TargetP { get; set; }
    public int Id { get; set; }
    public string Lokasi { get; set; }
    public Decimal? JumlahMin1 { get; set; }
    public Decimal? Pagu { get; set; }
    public Decimal? JumlahPls1{ get; set; }
    public string Sasaran { get; set; }
    public string KetKeg { get; set; }
    public DateTime? DateCreate { get; set; }
    public DateTime? DateUpdate { get; set; }
  }

  public class KEGUNITDelete : IRequest
  {
    public int? Id { get; set; }
  }

  public class KEGUNITBulkDelete : IRequest
  {
    public List<int> Ids { get; set; }
  }

  public class KEGUNITCreateValidator : AbstractValidator<KEGUNITCreate>
  {
    public KEGUNITCreateValidator()
    {
      
    }
  }

  public class KEGUNITUpdateValidator : AbstractValidator<KEGUNITUpdate>
  {
    public KEGUNITUpdateValidator()
    {
      
    }
  }

  public class KEGUNITDeleteValidator : AbstractValidator<KEGUNITDelete>
  {
    public KEGUNITDeleteValidator()
    {
      RuleFor(m => m.Id).NotNull();
    }
  }

  public class KEGUNITBulkDeleteValidator : AbstractValidator<KEGUNITBulkDelete>
  {
    public KEGUNITBulkDeleteValidator()
    {
      RuleFor(m => m.Ids).NotEmpty();
    }
  }
}
