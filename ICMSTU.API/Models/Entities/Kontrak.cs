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
    public string NoKon { get; set; }
    public string KdP3 { get; set; }
    public string KdKegUnit { get; set; }
    [Column(TypeName="Date")]
    public DateTime? TglKon { get; set; }
    [Column(TypeName="Date")]
    public DateTime? TglSlsKonk { get; set; }
    public string Uraian { get; set; }
    public Decimal? Nilai { get; set; }
    [Key]
    public int Id { get; set; }
    public int IdDAFTPHK3 { get; set; }
    [ForeignKey("IdDAFTPHK3")]
    public DAFTPHK DAFTPHK { get; set; }
    public int IdDAFTUNIT { get; set; }
    [ForeignKey("IdDAFTUNIT")]
    public DAFTUNIT DAFTUNIT { get; set; }
    public DateTime? DateCreate { get; set; }
    public DateTime? DateUpdate { get; set; }
    public string NoKontrak { get; set; }
    [Column(TypeName="Date")]
    public DateTime? TglAwalKontrak { get; set; }
    [Column(TypeName="Date")]
    public DateTime? TglAkhirKontrak { get; set; }
    
  }
}
