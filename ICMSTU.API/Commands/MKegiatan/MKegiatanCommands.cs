using FluentValidation;
using MediatR;
using System.Collections.Generic;
using System;

namespace ICMSTU.API.Commands.MKegiatan
{
  public class MKegiatanCreate : IRequest<Models.Entities.MKegiatan>
  {
    public string KdKegUnit { get; set; }
    public string IdPrgrm { get; set; }
    //public MProgram Program { get; set; }
    public string KdPerspektif { get; set; }
    public string NuKeg { get; set; }
    public string NmKegUnit { get; set; }
    public string LevelKeg { get; set; }
    public string Type { get; set; }
    public string KdKeg_Induk { get; set; }
    public DateTime? DateCreate { get; set; }
    public DateTime? DateUpdate { get; set; }
  }

  public class MKegiatanUpdate : IRequest<Models.Entities.MKegiatan>
  {
    public string KdKegUnit { get; set; }
    public string IdPrgrm { get; set; }
    //public MProgram Program { get; set; }
    public string KdPerspektif { get; set; }
    public string NuKeg { get; set; }
    public string NmKegUnit { get; set; }
    public string LevelKeg { get; set; }
    public string Type { get; set; }
    public string KdKeg_Induk { get; set; }
    public int Id { get; set; }
    public DateTime? DateCreate { get; set; }
    public DateTime? DateUpdate { get; set; }
  }

  public class MKegiatanDelete : IRequest
  {
    public int? Id { get; set; }
  }

  public class MKegiatanBulkDelete : IRequest
  {
    public List<int> Ids { get; set; }
  }

  public class MKegiatanCreateValidator : AbstractValidator<MKegiatanCreate>
  {
    public MKegiatanCreateValidator()
    {
      
    }
  }

  public class MKegiatanUpdateValidator : AbstractValidator<MKegiatanUpdate>
  {
    public MKegiatanUpdateValidator()
    {
      
    }
  }

  public class MKegiatanDeleteValidator : AbstractValidator<MKegiatanDelete>
  {
    public MKegiatanDeleteValidator()
    {
      RuleFor(m => m.Id).NotNull();
    }
  }

  public class MKegiatanBulkDeleteValidator : AbstractValidator<MKegiatanBulkDelete>
  {
    public MKegiatanBulkDeleteValidator()
    {
      RuleFor(m => m.Ids).NotEmpty();
    }
  }
}
