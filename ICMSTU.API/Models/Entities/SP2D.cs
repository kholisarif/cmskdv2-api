using System.ComponentModel.DataAnnotations.Schema;
using System;
using System.Collections.Generic;

namespace ICMSTU.API.Models.Entities
{
  [Table("SP2D")]
  public class SP2D
  {
    public string UnitKey { get; set; }
    public string NoSp2d { get; set; }
    public string KdStatus { get; set; }
    public string NoSPM { get; set; }
    public string KeyBend { get; set; }
    public string IdxSko { get; set; }
    public string IdxTtd { get; set; }
    public string Kdp3 { get; set; }
    public int IdxKode { get; set; }
    public string NoReg { get; set; }
    public string KetOtor { get; set; }
    public string NoKontrak { get; set; }
    public string Keperluan { get; set; }
    public string Penolakan { get; set; }
    [Column(TypeName="Date")]
    public DateTime? TglValid { get; set; }
    [Column(TypeName="Date")]
    public DateTime? TglSP2D { get; set; }
    [Column(TypeName="Date")]
    public DateTime? TglSPM { get; set; }
    public string NoBBantu { get; set; }
    public int Id { get; set; }
    public DateTime? DateCreate { get; set; }
    public DateTime? DateUpdate { get; set; }
  }
}
