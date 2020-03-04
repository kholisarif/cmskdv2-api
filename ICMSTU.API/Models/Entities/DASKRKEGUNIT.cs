using System.ComponentModel.DataAnnotations.Schema;
using System;
using System.ComponentModel.DataAnnotations;

namespace ICMSTU.API.Models.Entities
{
  [Table("DASKRKEGUNIT")]
  public class DASKRKEGUNIT
  {
    public string MTGkey { get; set; }
    public string IdxDask { get; set; }
    public Decimal? Nilai { get; set; }
    public int? IdMatangR { get; set; }
    [ForeignKey("IdMatangR")]
    public MATANGR MATANGR { get; set; }
    [Key]
    public string KdTahap { get; set; }
    [Key]
    public string UnitKey { get; set; }
    public string KdKegUnit { get; set; }
    public string IdPrgrm { get; set; }
    public int NoPrior { get; set; }
    public string KdSifat { get; set; }
    public string NIP { get; set; }
    [Column(TypeName="Date")]
    public DateTime? TglAkhir { get; set; }
    [Column(TypeName="Date")]
    public DateTime? TglAwal { get; set; }
    public Decimal? TargetP { get; set; }
    public string Lokasi { get; set; }
    public Decimal? JumlahMin1 { get; set; }
    public Decimal? Pagu { get; set; }
    public Decimal? JumlahPls1{ get; set; }
    public string Sasaran { get; set; }
    public string KetKeg { get; set; }
    public int Id { get; set; }
    // public int? IdDAFTUNIT { get; set; }
    // [ForeignKey("IdDAFTUNIT")]
    public int? IdMPGRM { get; set; }
    [ForeignKey("IdMPGRM")]
    public MPGRM MPGRM { get; set; }
    // public DAFTUNIT DAFTUNIT { get; set; }
    // public int? IdPgrmUnit { get; set; }
    // [ForeignKey("IdPgrmUnit")]
    // public PGRMUNIT PGRMUNIT { get; set; }
    public int? IdMKegiatan { get; set; }
    [ForeignKey("IdMKegiatan")]
    public MKegiatan MKegiatan { get; set; }
    
  }
}