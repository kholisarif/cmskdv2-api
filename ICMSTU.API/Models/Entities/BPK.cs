using System.ComponentModel.DataAnnotations.Schema;
using System;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;

namespace ICMSTU.API.Models.Entities
{
  [Table("BPK")]
  public class BPK
  {
    public string UnitKey { get; set; }
    public List<DAFTUNIT> DAFTUNITs { get; set; }
    [Key]
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
    public int? KdTransfer { get; set; }
    public int? KdBayar { get; set; }
    public string KDP3 { get; set; }
    public List<DAFTPHK> DAFTPHKs { get; set; }
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
    public List<BPKDETR> BPKDETRs { get; set; }
  }
}