using System.ComponentModel.DataAnnotations.Schema;
using System;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;

namespace ICMSTU.API.Models.Entities
{
  [Table("MPGRM")]
  public class MPGRM
  {
    [Key]
    public string IdPrgrm { get; set; }
    public List<MKegiatan> MKegiatans { get; set; }
    public string UnitKey { get; set; }
    public string NmPrgrm { get; set; }
    public string NuPrgrm { get; set; }
    public int Id { get; set; }
    public DateTime? DateCreate { get; set; }
    public DateTime? DateUpdate { get; set; }
    // public KEGUNIT KEGUNIT { get; set; }
    public List<PGRMUNIT> PGRMUNITs { get; set; }
  }
}
