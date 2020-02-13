using System.ComponentModel.DataAnnotations.Schema;
using System;
using System.ComponentModel.DataAnnotations;

namespace ICMSTU.API.Models.Entities
{
  [Table("DAFTPHK3")]
  public class DAFTPHK
  {
    [Key]
    public string KdP3 { get; set; }
    public string NmP3 { get; set; }
    public string NmInst { get; set; }
    public string NoRCP3 { get; set; }
    public string NmBank { get; set; }
    public string JnsUsaha{ get; set; }
    public string Alamat { get; set; }
    public string Telepon { get; set; }
    public string NPWP { get; set; }
    public string UnitKey { get; set; }
    public int Id { get; set; }
    public string WargaNegara { get; set; }
    public string StPenduduk { get; set; }
    public string IdBank { get; set; }
    public string CabangBank{ get; set; }
    public string AlamatBank { get; set; }
    public string NorekBank { get; set; }
    public int? KdJenis { get; set; }
    public int? StValid { get; set; }
    public int? IsLock { get; set; }
    public DateTime? DateCreate { get; set; }
    public DateTime? DateUpdate { get; set; }
  }
}