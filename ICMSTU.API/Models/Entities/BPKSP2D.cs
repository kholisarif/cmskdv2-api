using System.ComponentModel.DataAnnotations.Schema;
using System;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;

namespace ICMSTU.API.Models.Entities
{
  public class BPKSP2D
  {
    public string KdStatus { get; set; }
    public string NoBPK { get; set; }
    public DateTime? TglBPK { get; set; }
    public int? KdBayar { get; set; }
    public int? KdTransfer { get; set; }
    public string NoBA { get; set; }
    public string KDP3 { get; set; }
    public string NoRek { get; set; }
    public string UraiBPK { get; set; }
    [Column(TypeName="Date")]
    public DateTime? TglBuku { get; set; }
    [Key]
    public int Id { get; set; }
    //DARI TABEL SP2DBPK
    public string NoSP2D { get; set; }
    
  }
}