using System.ComponentModel.DataAnnotations.Schema;
using System;

namespace ICMSTU.API.Models.Entities
{
  [Table("STATTRS")]
  public class STATTRS
  {
    public string KdStatus { get; set; }
    public string LblStatus { get; set; }
    public string Uraian { get; set; }
    public int Id { get; set; }
    public DateTime? DateCreate { get; set; }
    public DateTime? DateUpdate { get; set; }
  }
}