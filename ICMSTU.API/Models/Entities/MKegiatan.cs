using System.ComponentModel.DataAnnotations.Schema;
using System;

namespace ICMSTU.API.Models.Entities
{
  [Table("MKEGIATAN")]
  public class MKegiatan
  {
    public string KdKegUnit { get; set; }
    public string IdPrgrm { get; set; }
    //public MProgram Program { get; set; }
    public string KdPerspektif { get; set; }
    public string NuKeg { get; set; }
    public string NmKegUnit { get; set; }
    public string LevelKeg { get; set; }
    public string Type { get; set; }
    public string KdKeg_Induk { get; set; }
    public int Id { get; set; }
    public DateTime? DateCreate { get; set; }
    public DateTime? DateUpdate { get; set; }
  }
}