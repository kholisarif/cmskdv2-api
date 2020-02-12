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
    public string UnitKey { get; set; }
    public string NoBPK { get; set; }
    public Decimal? Nilai { get; set; }
    public int Id { get; set; }
    public DateTime? DateCreate { get; set; }
    public DateTime? DateUpdate { get; set; }
  }
}