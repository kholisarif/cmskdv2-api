using System.ComponentModel.DataAnnotations.Schema;
using System;

namespace ICMSTU.API.Models.Entities
{
  [Table("JDANA")]
  public class JDANA
  {
    public string KdDana { get; set; }
    public string NmDana { get; set; }
    public string Ket { get; set; }
    public int Id { get; set; }
    public string Type { get; set; }
    public DateTime? DateCreate { get; set; }
    public DateTime? DateUpdate { get; set; }
  }
}