using FluentValidation;
using MediatR;
using System.Collections.Generic;
using System;

namespace ICMSTU.API.Commands.BPKSP2D
{
  public class BPKSP2DCreate : IRequest<Models.Entities.BPKSP2D>
  {
    public string KdStatus { get; set; }
    public string NoBPK { get; set; }
    public DateTime? TglBPK { get; set; }
    public int? KdBayar { get; set; }
    public int? KdTransfer { get; set; }
    public string NoBA { get; set; }
    public string KDP3 { get; set; }
    public string NoRek { get; set; }
    public string UraiBPK { get; set; }
    public DateTime? TglBuku { get; set; }
    public string NoSP2D { get; set; }
  }

  public class BPKSP2DUpdate : IRequest<Models.Entities.BPKSP2D>
  {
    
    public string KdStatus { get; set; }
    public string NoBPK { get; set; }
    public DateTime? TglBPK { get; set; }
    public int? KdBayar { get; set; }
    public int? KdTransfer { get; set; }
    public string NoBA { get; set; }
    public string KDP3 { get; set; }
    public string NoRek { get; set; }
    public string UraiBPK { get; set; }
    public DateTime? TglBuku { get; set; }
    public int? Id { get; set; }
    public string NoSP2D { get; set; }
  }

  public class BPKSP2DDelete : IRequest
  {
    public int? Id { get; set; }
  }

  public class BPKSP2DBulkDelete : IRequest
  {
    public List<int> Ids { get; set; }
  }

  public class BPKSP2DCreateValidator : AbstractValidator<BPKSP2DCreate>
  {
//     public BPKSP2DCreateValidator()
//     {
//       RuleFor(m => m.UnitKey).NotEmpty();
//       RuleFor(m => m.NoBPKSP2D).NotEmpty();
//       RuleFor(m => m.KdStatus).NotEmpty();
//       RuleFor(m => m.StPanjar).NotEmpty();
//       RuleFor(m => m.StTunai).NotEmpty();
//       RuleFor(m => m.StBank).NotEmpty();
//       RuleFor(m => m.IdxKode).NotEmpty();
//       RuleFor(m => m.KeyBend).NotEmpty();
//       RuleFor(m => m.TglBPKSP2D).NotEmpty();
//       RuleFor(m => m.Penerima).NotEmpty();
//       RuleFor(m => m.UraiBPKSP2D).NotEmpty();
//       RuleFor(m => m.TglValid).NotEmpty();
//       RuleFor(m => m.NoBA).NotEmpty();
//       RuleFor(m => m.KdBank).NotEmpty();
//       RuleFor(m => m.NoRek).NotEmpty();
//       RuleFor(m => m.KdTransfer).NotEmpty();
//       RuleFor(m => m.KdBayar).NotEmpty();
//       RuleFor(m => m.KDP3).NotEmpty();
//       RuleFor(m => m.NMP3).NotEmpty();
//       RuleFor(m => m.IdBank).NotEmpty();
//       RuleFor(m => m.NmBank).NotEmpty();
//       RuleFor(m => m.NoRef).NotEmpty();
//       RuleFor(m => m.KdRilis).NotEmpty();
//       RuleFor(m => m.StKirim).NotEmpty();
//       RuleFor(m => m.StCair).NotEmpty();
//       RuleFor(m => m.TglBuku).NotEmpty();
//       RuleFor(m => m.DateCreate).NotEmpty();
//       RuleFor(m => m.DateUpdate).NotEmpty();
//       RuleFor(m => m.NoBerita).NotEmpty();
//     }
  }

  public class BPKSP2DUpdateValidator : AbstractValidator<BPKSP2DUpdate>
  {
    // public BPKSP2DUpdateValidator()
    // {
    //   RuleFor(m => m.Id).NotNull();
    //   RuleFor(m => m.UnitKey).NotEmpty();
    //   RuleFor(m => m.NoBPKSP2D).NotEmpty();
    //   RuleFor(m => m.KdStatus).NotEmpty();
    //   RuleFor(m => m.StPanjar).NotEmpty();
    //   RuleFor(m => m.StTunai).NotEmpty();
    //   RuleFor(m => m.StBank).NotEmpty();
    //   RuleFor(m => m.IdxKode).NotEmpty();
    //   RuleFor(m => m.KeyBend).NotEmpty();
    //   RuleFor(m => m.TglBPKSP2D).NotEmpty();
    //   RuleFor(m => m.Penerima).NotEmpty();
    //   RuleFor(m => m.UraiBPKSP2D).NotEmpty();
    //   RuleFor(m => m.TglValid).NotEmpty();
    //   RuleFor(m => m.NoBA).NotEmpty();
    //   RuleFor(m => m.KdBank).NotEmpty();
    //   RuleFor(m => m.NoRek).NotEmpty();
    //   RuleFor(m => m.KdTransfer).NotEmpty();
    //   RuleFor(m => m.KdBayar).NotEmpty();
    //   RuleFor(m => m.KDP3).NotEmpty();
    //   RuleFor(m => m.NMP3).NotEmpty();
    //   RuleFor(m => m.IdBank).NotEmpty();
    //   RuleFor(m => m.NmBank).NotEmpty();
    //   RuleFor(m => m.NoRef).NotEmpty();
    //   RuleFor(m => m.KdRilis).NotEmpty();
    //   RuleFor(m => m.StKirim).NotEmpty();
    //   RuleFor(m => m.StCair).NotEmpty();
    //   RuleFor(m => m.TglBuku).NotEmpty();
    //   RuleFor(m => m.DateCreate).NotEmpty();
    //   RuleFor(m => m.DateUpdate).NotEmpty();
    //   RuleFor(m => m.NoBerita).NotEmpty();
    // }
  }

  public class BPKSP2DDeleteValidator : AbstractValidator<BPKSP2DDelete>
  {
    public BPKSP2DDeleteValidator()
    {
      RuleFor(m => m.Id).NotNull();
    }
  }

  public class BPKSP2DBulkDeleteValidator : AbstractValidator<BPKSP2DBulkDelete>
  {
    public BPKSP2DBulkDeleteValidator()
    {
      RuleFor(m => m.Ids).NotEmpty();
    }
  }
}
