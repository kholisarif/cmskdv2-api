using System.ComponentModel.DataAnnotations.Schema;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ICMSTU.API.Models.Entities
{
  [Table("KEGUNIT")]
  public class KEGUNIT
  {
    public string KdTahap { get; set; }
    public string UnitKey { get; set; }
    public string KdKegUnit { get; set; }
    // public List<MKegiatan> MKegiatans { get; set; }
    [Key]
    public string IdPrgrm { get; set; }
    public List<MPGRM> MPGRMs { get; set; }
    public int NoPrior { get; set; }
    public string KdSifat { get; set; }
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
}
