using System.ComponentModel.DataAnnotations.Schema;
using System;
using System.ComponentModel.DataAnnotations;

namespace ICMSTU.API.Models.Entities
{
  [Table("BERITADETR")]
  public class BERITADETR
  {
    public string UnitKey { get; set; }
    public string NoBA { get; set; }
    public string MtgKey { get; set; }
    public Decimal? Nilai { get; set; }
    [Key]
    public int Id { get; set; }
    public int IdMATANGR { get; set; }
    [ForeignKey("IdMATANGR")]
    public MATANGR MATANGR { get; set; }
    public DateTime? DateCreate { get; set; }
    public DateTime? DateUpdate { get; set; }
  }
}