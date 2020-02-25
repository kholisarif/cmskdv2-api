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
    public string NoBPK { get; set; }
    public string KdStatus { get; set; }
    public bool? StPanjar { get; set; }
    public bool? StTunai { get; set; }
    public bool? StBank { get; set; }
    public int IdxKode { get; set; }
    public string KeyBend { get; set; }
    [Column(TypeName="Date")]
    public DateTime? TglBPK { get; set; }
    public string Penerima { get; set; }
    public string UraiBPK { get; set; }
    [Column(TypeName="Date")]
    public DateTime? TglValid { get; set; }
    public string NoBA { get; set; }
    public string KdBank { get; set; }
    public string NoRek { get; set; }
    [Key]
    public int Id { get; set; }
    public int IdDAFTUNIT { get; set; }
    [ForeignKey("IdDAFTUNIT")]
    public DAFTUNIT DAFTUNIT { get; set; }
    public int IdSTATTRS { get; set; }
    [ForeignKey("IdSTATTRS")]
    public STATTRS STATTRS { get; set; }
    public int IdBEND { get; set; }
    [ForeignKey("IdBEND")]
    public BEND BEND { get; set; }
    public int IdBerita { get; set; }
    [ForeignKey("IdBerita")]
    public Berita Berita { get; set; }
    public int IdJTRANSFER { get; set; }
    [ForeignKey("IdJTRANSFER")]
    public JTRANSFER JTRANSFER { get; set; }
    public int IdJBAYAR { get; set; }
    [ForeignKey("IdJBAYAR")]
    public JBAYAR JBAYAR { get; set; }
    public int IdDAFTPHK3 { get; set; }
    [ForeignKey("IdDAFTPHK3")]
    public DAFTPHK DAFTPHK { get; set; }
    public int IdJKIRIM { get; set; }
    [ForeignKey("IdJKIRIM")]
    public JKIRIM JKIRIM { get; set; }
    public int IdJCAIR { get; set; }
    [ForeignKey("IdJCAIR")]
    public JCAIR JCAIR { get; set; }
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
    [Column(TypeName="Date")]
    public DateTime? TglBuku { get; set; }
    public DateTime? DateCreate { get; set; }
    public DateTime? DateUpdate { get; set; }
    public string NoBerita { get; set; }
    public List<BPKDETR> BPKDETRs { get; set; }
  }
}