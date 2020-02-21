using System.ComponentModel.DataAnnotations.Schema;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ICMSTU.API.Models.Entities
{
  [Table("BERITA")]
  public class Berita
  {
    [ForeignKey("DAFTUNIT")]
    public string UnitKey { get; set; }
    public DAFTUNIT DAFTUNIT { get; set; }
    public string NoBA { get; set; }
    [Column(TypeName="Date")]
    public DateTime? TglBA { get; set; }
    public string KdKegUnit { get; set; }
    [ForeignKey("Kontrak")]
    public string NoKon { get; set; }
    public Kontrak Kontrak { get; set; }
    public string UraiBA { get; set; }
    [Column(TypeName="Date")]
    public DateTime? TglValid { get; set; }
    [ForeignKey("STATTRS")]
    public string KdStatus{ get; set; }
    public STATTRS STATTRS { get; set; }
    [Key]
    public int Id { get; set; }
    public DateTime? DateCreate { get; set; }
    public DateTime? DateUpdate { get; set; }
    public string NoKontrak { get; set; }
    public string NoBerita{ get; set; }
    public List<BPK> BPKs { get; set; }
  }
}
