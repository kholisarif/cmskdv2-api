using System.ComponentModel.DataAnnotations.Schema;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ICMSTU.API.Models.Entities
{
  [Table("DAFTUNIT")]
  public class DAFTUNIT
  {
    [Key]
    public string UnitKey { get; set; }
    public string KdLevel { get; set; }
    public string KdUnit { get; set; }
    public string NmUnit { get; set; }
    public string AkroUnit { get; set; }
    public string Alamat { get; set; }
    public string Telepon{ get; set; }
    public string Type { get; set; }
    public int Id { get; set; }
    public DateTime? DateCreate { get; set; }
    public DateTime? DateUpdate { get; set; }
    public List<PGRMUNIT> PGRMUNITs { get; set; }
  }
}
