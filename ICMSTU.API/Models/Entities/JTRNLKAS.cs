using System.ComponentModel.DataAnnotations.Schema;
using System;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;

namespace ICMSTU.API.Models.Entities
{
  [Table("JTRNLKAS")]
  public class JTRNLKAS
  {
    [Key]
    public string NoJetra { get; set; }
    public string NmJetra { get; set; }
    public string KdPers { get; set; }
    public List<BPKDETR> BPKDETRs { get; set; }
    public int Id { get; set; }
    public DateTime? DateCreate { get; set; }
    public DateTime? DateUpdate { get; set; }
    
  }
}