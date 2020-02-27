using System.ComponentModel.DataAnnotations.Schema;
using System;
using System.ComponentModel.DataAnnotations;

namespace ICMSTU.API.Models.Entities
{
  [Table("SBDANAR")]
  public class SBDANAR
  {
    public string KdKegUnit { get; set; }
    public string MTGkey { get; set; }
    public string KdTahap { get; set; }
    public string UnitKey { get; set; }
    public string KdDana { get; set; }
    public Decimal? Nilai { get; set; }
    [Key]
    public int Id { get; set; }
    // public int IdJDANA { get; set; }
    // [ForeignKey("IdJDANA")]
    // public JDANA JDANA { get; set; }
    // public DAFTPHK DAFTPHK { get; set; }
    public DateTime? DateCreate { get; set; }
    public DateTime? DateUpdate { get; set; }
  }
}