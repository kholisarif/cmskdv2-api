using System.ComponentModel.DataAnnotations.Schema;
using System;

namespace ICMSTU.API.Models.Entities
{
  [Table("BERITADETR")]
  public class BERITADETR
  {
    public string UnitKey { get; set; }
    public string NoBA { get; set; }
    public string MtgKey { get; set; }
    public Decimal? Nilai { get; set; }
    public int Id { get; set; }
    public DateTime? DateCreate { get; set; }
    public DateTime? DateUpdate { get; set; }
  }
}