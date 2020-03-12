using System.ComponentModel.DataAnnotations.Schema;
using System;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;

namespace ICMSTU.API.Models.Entities
{
  [Table("DASKRKEGUNIT")]
  public class DASKRKEGUNIT
  {
    // public int Id { get; set; }
    [Key]
    public string KdTahap { get; set; }
    [Key]
    public string UnitKey { get; set; }
    public string KdKEGUNIT { get; set; }
    public string NuKeg { get; set; }
    public string NmKEGUNIT { get; set; }
    public string Type { get; set; }
    public int KdLevel { get; set; }
    public string KdSifat { get; set; }
    public int? idMKegiatan { get; set; }
    // public string IdPrgrm { get; set; }
    // public int? IdMPGRM { get; set; }
    // [ForeignKey("IdMPGRM")]
    // public MPGRM MPGRM { get; set; }
    // public Decimal? TargetP { get; set; }
    // public string Sasaran { get; set; }
    // public int NoPrior { get; set; }
    public List<KEGUNIT> KEGUNITs { get; set; }
    
  }
}