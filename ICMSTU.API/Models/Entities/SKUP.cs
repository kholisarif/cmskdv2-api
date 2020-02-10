using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace ICMSTU.API.Models.Entities
{
  [Table("SKUP")]
  public class SKUP
  {
    public int Id { get; set; }
    public string NoSK { get; set; }
    public DateTime? TglSK { get; set; }
    public string Keperluan { get; set; }
    public List<SKUPDet> SKUPDet { get; set; }

    public SKUP()
    {
        SKUPDet = new List<SKUPDet>();
    }
  }
}