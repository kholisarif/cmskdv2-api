using FluentValidation;
using MediatR;
using System.Collections.Generic;
using System;

namespace ICMSTU.API.Commands.BPK
{
  public class BPKCreate : IRequest<Models.Entities.BPK>
  {
    public string UnitKey { get; set; }
    public string NoBPK { get; set; }
    public string KdStatus { get; set; }
    public bool? StPanjar { get; set; }
    public bool? StTunai { get; set; }
    public bool? StBank { get; set; }
    public int IdxKode { get; set; }
    public string KeyBend { get; set; }
    public DateTime? TglBPK { get; set; }
    public string Penerima { get; set; }
    public string UraiBPK { get; set; }
    public DateTime? TglValid { get; set; }
    public string NoBA { get; set; }
    public string KdBank { get; set; }
    public string NoRek { get; set; }
    public int IdDAFTUNIT { get; set; }
    public int IdSTATTRS { get; set; }
    public int IdBEND { get; set; }
    public int IdBerita { get; set; }
    public int IdJTRANSFER { get; set; }
    public int IdJBAYAR { get; set; }
    public int IdDAFTPHK3 { get; set; }
    public int IdJKIRIM { get; set; }
    public int IdJCAIR { get; set; }
    public int? KdTransfer { get; set; }
    public int? KdBayar { get; set; }
    public string KDP3 { get; set; }
    public string NMP3 { get; set; }
    public string IdBank { get; set; }
    public string NmBank { get; set; }
    public string NoRef { get; set; }
    public int? KdRilis { get; set; }
    public int? StKirim { get; set; }
    public int? StCair { get; set; }
    public DateTime? TglBuku { get; set; }
    public DateTime? DateCreate { get; set; }
    public DateTime? DateUpdate { get; set; }
    public string NoBerita { get; set; }
  }

  public class BPKUpdate : IRequest<Models.Entities.BPK>
  {
    
    public string UnitKey { get; set; }
    public string NoBPK { get; set; }
    public string KdStatus { get; set; }
    public bool? StPanjar { get; set; }
    public bool? StTunai { get; set; }
    public bool? StBank { get; set; }
    public int IdxKode { get; set; }
    public string KeyBend { get; set; }
    public DateTime? TglBPK { get; set; }
    public string Penerima { get; set; }
    public string UraiBPK { get; set; }
    public DateTime? TglValid { get; set; }
    public string NoBA { get; set; }
    public string KdBank { get; set; }
    public string NoRek { get; set; }
    public int Id { get; set; }
    public int IdDAFTUNIT { get; set; }
    public int IdSTATTRS { get; set; }
    public int IdBEND { get; set; }
    public int IdBerita { get; set; }
    public int IdJTRANSFER { get; set; }
    public int IdJBAYAR { get; set; }
    public int IdDAFTPHK3 { get; set; }
    public int IdJKIRIM { get; set; }
    public int IdJCAIR { get; set; }
    public int? KdTransfer { get; set; }
    public int? KdBayar { get; set; }
    public string KDP3 { get; set; }
    public string NMP3 { get; set; }
    public string IdBank { get; set; }
    public string NmBank { get; set; }
    public string NoRef { get; set; }
    public int? KdRilis { get; set; }
    public int? StKirim { get; set; }
    public int? StCair { get; set; }
    public DateTime? TglBuku { get; set; }
    public DateTime? DateCreate { get; set; }
    public DateTime? DateUpdate { get; set; }
    public string NoBerita { get; set; }
  }

  public class BPKDelete : IRequest
  {
    public int? Id { get; set; }
  }

  public class BPKBulkDelete : IRequest
  {
    public List<int> Ids { get; set; }
  }

  public class BPKCreateValidator : AbstractValidator<BPKCreate>
  {
    public BPKCreateValidator()
    {
      RuleFor(m => m.UnitKey).NotEmpty();
      RuleFor(m => m.NoBPK).NotEmpty();
      RuleFor(m => m.KdStatus).NotEmpty();
      RuleFor(m => m.StPanjar).NotEmpty();
      RuleFor(m => m.StTunai).NotEmpty();
      RuleFor(m => m.StBank).NotEmpty();
      RuleFor(m => m.IdxKode).NotEmpty();
      RuleFor(m => m.KeyBend).NotEmpty();
      RuleFor(m => m.TglBPK).NotEmpty();
      RuleFor(m => m.Penerima).NotEmpty();
      RuleFor(m => m.UraiBPK).NotEmpty();
      RuleFor(m => m.TglValid).NotEmpty();
      RuleFor(m => m.NoBA).NotEmpty();
      RuleFor(m => m.KdBank).NotEmpty();
      RuleFor(m => m.NoRek).NotEmpty();
      RuleFor(m => m.KdTransfer).NotEmpty();
      RuleFor(m => m.KdBayar).NotEmpty();
      RuleFor(m => m.KDP3).NotEmpty();
      RuleFor(m => m.NMP3).NotEmpty();
      RuleFor(m => m.IdBank).NotEmpty();
      RuleFor(m => m.NmBank).NotEmpty();
      RuleFor(m => m.NoRef).NotEmpty();
      RuleFor(m => m.KdRilis).NotEmpty();
      RuleFor(m => m.StKirim).NotEmpty();
      RuleFor(m => m.StCair).NotEmpty();
      RuleFor(m => m.TglBuku).NotEmpty();
      RuleFor(m => m.DateCreate).NotEmpty();
      RuleFor(m => m.DateUpdate).NotEmpty();
      RuleFor(m => m.NoBerita).NotEmpty();
    }
  }

  public class BPKUpdateValidator : AbstractValidator<BPKUpdate>
  {
    public BPKUpdateValidator()
    {
      RuleFor(m => m.Id).NotNull();
      RuleFor(m => m.UnitKey).NotEmpty();
      RuleFor(m => m.NoBPK).NotEmpty();
      RuleFor(m => m.KdStatus).NotEmpty();
      RuleFor(m => m.StPanjar).NotEmpty();
      RuleFor(m => m.StTunai).NotEmpty();
      RuleFor(m => m.StBank).NotEmpty();
      RuleFor(m => m.IdxKode).NotEmpty();
      RuleFor(m => m.KeyBend).NotEmpty();
      RuleFor(m => m.TglBPK).NotEmpty();
      RuleFor(m => m.Penerima).NotEmpty();
      RuleFor(m => m.UraiBPK).NotEmpty();
      RuleFor(m => m.TglValid).NotEmpty();
      RuleFor(m => m.NoBA).NotEmpty();
      RuleFor(m => m.KdBank).NotEmpty();
      RuleFor(m => m.NoRek).NotEmpty();
      RuleFor(m => m.KdTransfer).NotEmpty();
      RuleFor(m => m.KdBayar).NotEmpty();
      RuleFor(m => m.KDP3).NotEmpty();
      RuleFor(m => m.NMP3).NotEmpty();
      RuleFor(m => m.IdBank).NotEmpty();
      RuleFor(m => m.NmBank).NotEmpty();
      RuleFor(m => m.NoRef).NotEmpty();
      RuleFor(m => m.KdRilis).NotEmpty();
      RuleFor(m => m.StKirim).NotEmpty();
      RuleFor(m => m.StCair).NotEmpty();
      RuleFor(m => m.TglBuku).NotEmpty();
      RuleFor(m => m.DateCreate).NotEmpty();
      RuleFor(m => m.DateUpdate).NotEmpty();
      RuleFor(m => m.NoBerita).NotEmpty();
    }
  }

  public class BPKDeleteValidator : AbstractValidator<BPKDelete>
  {
    public BPKDeleteValidator()
    {
      RuleFor(m => m.Id).NotNull();
    }
  }

  public class BPKBulkDeleteValidator : AbstractValidator<BPKBulkDelete>
  {
    public BPKBulkDeleteValidator()
    {
      RuleFor(m => m.Ids).NotEmpty();
    }
  }
}
