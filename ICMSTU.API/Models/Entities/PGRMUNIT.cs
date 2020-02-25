using System.ComponentModel.DataAnnotations.Schema;
using System;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;

namespace ICMSTU.API.Models.Entities
{
  [Table("PGRMUNIT")]
  public class PGRMUNIT
  {
    [Key]
    public int Id { get; set; }
    // public int? IdDAFTUNIT { get; set; }
    // [ForeignKey("IdDAFTUNIT")]
    // public DAFTUNIT DAFTUNIT { get; set; }
    public string kdtahap { get; set; }
    public string UnitKey { get; set; }
    public string IdPrgrm { get; set; }
    public int? IdMPGRM { get; set; }
    [ForeignKey("IdMPGRM")]
    public MPGRM MPGRM { get; set; }
    public string Target { get; set; }
    public string Sasaran { get; set; }
    public int? NoPrio { get; set; }
    public DateTime? DateCreate { get; set; }
    public DateTime? DateUpdate { get; set; }
    public List<KEGUNIT> KEGUNITs { get; set; }
  }
}
