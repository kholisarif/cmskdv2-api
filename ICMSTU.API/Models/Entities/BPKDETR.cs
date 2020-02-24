using System.ComponentModel.DataAnnotations.Schema;
using System;

namespace ICMSTU.API.Models.Entities
{
  [Table("BPKDETR")]
  public class BPKDETR
  {
    public string MTGkey { get; set; }
    public string KdKegUnit { get; set; }
    public string NoJetra { get; set; }
    public JTRNLKAS JTRNLKAS { get; set; }
    public string UnitKey { get; set; }
    public string NoBPK { get; set; }
    public Decimal? Nilai { get; set; }
    public int Id { get; set; }
    public int IdMatangR { get; set; }
    [ForeignKey("IdMatangR")]
    public MATANGR MATANGR { get; set; }
    public int IdMKegiatan { get; set; }
    [ForeignKey("IdMKegiatan")]
    public MKegiatan MKegiatan { get; set; }
    public int IdDaftUnit { get; set; }
    [ForeignKey("IdDaftUnit")]
    public DAFTUNIT DAFTUNIT { get; set; }
    public int IdBPK { get; set; }
    [ForeignKey("IdBPK")]
    public BPK BPK { get; set; }
    public DateTime? DateCreate { get; set; }
    public DateTime? DateUpdate { get; set; }
  }
}