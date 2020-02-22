using FluentValidation;
using MediatR;
using System.Collections.Generic;
using System;

namespace ICMSTU.API.Commands.Kontrak
{
  public class KontrakCreate : IRequest<Models.Entities.Kontrak>
  {
    public string UnitKey { get; set; }
    public string NoKon { get; set; }
    public string Kdp3 { get; set; }
    public int IdDAFTPHK3 { get; set; }
    public string KdKegUnit { get; set; }
    public DateTime? TglKon { get; set; }
    public DateTime? TglSlsKonk { get; set; }
    public string Uraian { get; set; }
    public Decimal? Nilai { get; set; }
    public DateTime? DateCreate { get; set; }
    public DateTime? DateUpdate { get; set; }
    public string NoKontrak { get; set; }
    public DateTime? TglAwalKontrak { get; set; }
    public DateTime? TglAkhirKontrak { get; set; }
  }

  public class KontrakUpdate : IRequest<Models.Entities.Kontrak>
  {
    public string UnitKey { get; set; }
    public string NoKon { get; set; }
    public string Kdp3 { get; set; }
    public string KdKegUnit { get; set; }
    public DateTime? TglKon { get; set; }
    public DateTime? TglSlsKonk { get; set; }
    public string Uraian { get; set; }
    public Decimal? Nilai { get; set; }
    public int Id { get; set; }
    public DateTime? DateCreate { get; set; }
    public DateTime? DateUpdate { get; set; }
    public string NoKontrak { get; set; }
    public DateTime? TglAwalKontrak { get; set; }
    public DateTime? TglAkhirKontrak { get; set; }
  }

  public class KontrakDelete : IRequest
  {
    public int? Id { get; set; }
  }

  public class KontrakBulkDelete : IRequest
  {
    public List<int> Ids { get; set; }
  }

  public class KontrakCreateValidator : AbstractValidator<KontrakCreate>
  {
    public KontrakCreateValidator()
    {
      
    }
  }

  public class KontrakUpdateValidator : AbstractValidator<KontrakUpdate>
  {
    public KontrakUpdateValidator()
    {
      
    }
  }

  public class KontrakDeleteValidator : AbstractValidator<KontrakDelete>
  {
    public KontrakDeleteValidator()
    {
      RuleFor(m => m.Id).NotNull();
    }
  }

  public class KontrakBulkDeleteValidator : AbstractValidator<KontrakBulkDelete>
  {
    public KontrakBulkDeleteValidator()
    {
      RuleFor(m => m.Ids).NotEmpty();
    }
  }
}
