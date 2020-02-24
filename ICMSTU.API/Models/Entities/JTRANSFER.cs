using System.ComponentModel.DataAnnotations.Schema;
using System;
using System.ComponentModel.DataAnnotations;

namespace ICMSTU.API.Models.Entities
{
  [Table("JTRANSFER")]
  public class JTRANSFER
  {
    public int KdTransfer { get; set; }
    public string NmTransfer { get; set; }
    public string UraianTrans { get; set; }
    [Key]
    public int Id { get; set; }
    public Decimal? MinNominal { get; set; }
    public string FlagsNom { get; set; }
  }
}