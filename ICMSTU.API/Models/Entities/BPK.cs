using System.ComponentModel.DataAnnotations.Schema;
using System;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;

namespace ICMSTU.API.Models.Entities
{
  [Table("BPK")]
  public class BPK
  {
    [ForeignKey("DAFTUNIT")]
    public string UnitKey { get; set; }
    public DAFTUNIT DAFTUNIT { get; set; }
    public string NoBPK { get; set; }
    [ForeignKey("STATTRS")]
    public string KdStatus { get; set; }
    public STATTRS STATTRS { get; set; }
    public bool? StPanjar { get; set; }
    public bool? StTunai { get; set; }
    public bool? StBank { get; set; }
    public int IdxKode { get; set; }
    [ForeignKey("BEND")]
    public string KeyBend { get; set; }
    public BEND BEND { get; set; }
    [Column(TypeName="Date")]
    public DateTime? TglBPK { get; set; }
    public string Penerima { get; set; }
    public string UraiBPK { get; set; }
    [Column(TypeName="Date")]
    public DateTime? TglValid { get; set; }
    [ForeignKey("Berita")]
    public string NoBA { get; set; }
    public Berita Berita { get; set; }
    public string KdBank { get; set; }
    public string NoRek { get; set; }
    public int Id { get; set; }
    [ForeignKey("JTRANSFER")]
    public int? KdTransfer { get; set; }
    public JTRANSFER JTRANSFER { get; set; }
    [ForeignKey("JBAYAR")]
    public int? KdBayar { get; set; }
    public JBAYAR JBAYAR { get; set; }
    [ForeignKey("DAFTPHK")]
    public string KDP3 { get; set; }
    public DAFTPHK DAFTPHK { get; set; }
    public string NMP3 { get; set; }
    public string IdBank { get; set; }
    public string NmBank { get; set; }
    public string NoRef { get; set; }
    public int? KdRilis { get; set; }
    [ForeignKey("JKIRIM")]
    public int? StKirim { get; set; }
    public JKIRIM JKIRIM { get; set; }
    [ForeignKey("JCAIR")]
    public int? StCair { get; set; }
    public JCAIR JCAIR { get; set; }
    [Column(TypeName="Date")]
    public DateTime? TglBuku { get; set; }
    public DateTime? DateCreate { get; set; }
    public DateTime? DateUpdate { get; set; }
    public string NoBerita { get; set; }
    public List<BPKDETR> BPKDETRs { get; set; }
  }
}