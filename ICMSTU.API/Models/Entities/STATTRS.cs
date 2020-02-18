using System.ComponentModel.DataAnnotations.Schema;
using System;
using System.ComponentModel.DataAnnotations;

namespace ICMSTU.API.Models.Entities
{
  [Table("STATTRS")]
  public class STATTRS
  {
    [Key]
    public string KdStatus { get; set; }
    public string LblStatus { get; set; }
    public string Uraian { get; set; }
    public int Id { get; set; }
    public DateTime? DateCreate { get; set; }
    public DateTime? DateUpdate { get; set; }
  }
}