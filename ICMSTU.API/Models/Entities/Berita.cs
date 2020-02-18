using System.ComponentModel.DataAnnotations.Schema;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ICMSTU.API.Models.Entities
{
  [Table("BERITA")]
  public class Berita
  {
    public string UnitKey { get; set; }
    // public DAFTUNIT DAFTUNIT { get; set; }
    [Key]
    public string NoBA { get; set; }
    public DateTime? TglBA { get; set; }
    public string KdKegUnit { get; set; }
    public string NoKon { get; set; }
    public string UraiBA { get; set; }
    public DateTime? TglValid { get; set; }
    public string KdStatus{ get; set; }
    public int Id { get; set; }
    public DateTime? DateCreate { get; set; }
    public DateTime? DateUpdate { get; set; }
    public string NoKontrak { get; set; }
    public string NoBerita{ get; set; }
     public List<BPK> BPKs { get; set; }
  }
}
