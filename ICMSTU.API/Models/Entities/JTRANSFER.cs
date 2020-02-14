using System.ComponentModel.DataAnnotations.Schema;
using System;

namespace ICMSTU.API.Models.Entities
{
  [Table("JTRANSFER")]
  public class JTRANSFER
  {
    public int KdTransfer { get; set; }
    public string NmTransfer { get; set; }
    public string UraianTrans { get; set; }
    public int Id { get; set; }
    public Decimal? MinNominal { get; set; }
    public string FlagsNom { get; set; }
  }
}