using System.ComponentModel.DataAnnotations.Schema;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ICMSTU.API.Models.Entities
{
  [Table("KONTRAK")]
  public class Kontrak
  {
    public string UnitKey { get; set; }
    [Key]
    public string NoKon { get; set; }
    public string Kdp3 { get; set; }
    public DAFTPHK DAFTPHK { get; set; }
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
}
