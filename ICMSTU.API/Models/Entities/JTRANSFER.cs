using System.ComponentModel.DataAnnotations.Schema;
using System;
using System.ComponentModel.DataAnnotations;

namespace ICMSTU.API.Models.Entities
{
  [Table("JTRANSFER")]
  public class JTRANSFER
  {
    [Key]
    public int KdTransfer { get; set; }
    public string NmTransfer { get; set; }
    public string UraianTrans { get; set; }
    public int Id { get; set; }
    public Decimal? MinNominal { get; set; }
    public string FlagsNom { get; set; }
  }
}