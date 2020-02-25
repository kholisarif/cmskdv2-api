using System.ComponentModel.DataAnnotations.Schema;
using System;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;

namespace ICMSTU.API.Models.Entities
{
  [Table("MPGRM")]
  public class MPGRM
  {
    public string IdPrgrm { get; set; }
    // public List<MKegiatan> MKegiatans { get; set; }
    public string UnitKey { get; set; }
    public string NmPrgrm { get; set; }
    public string NuPrgrm { get; set; }
    [Key]
    public int Id { get; set; }
    // public int? IdDAFTUNIT { get; set; }
    // [ForeignKey("IdDAFTUNIT")]
    // public DAFTUNIT DAFTUNIT { get; set; }
    public DateTime? DateCreate { get; set; }
    public DateTime? DateUpdate { get; set; }
    // public KEGUNIT KEGUNIT { get; set; }
    public List<PGRMUNIT> PGRMUNITs { get; set; }
    public List<KEGUNIT> KEGUNITs { get; set; }
  }
}
