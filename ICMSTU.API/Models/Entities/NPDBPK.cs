using System.ComponentModel.DataAnnotations.Schema;
using System;
using System.ComponentModel.DataAnnotations;

namespace ICMSTU.API.Models.Entities
{
  [Table("NPDBPK")]
  public class NPDBPK
  {
    public string NoNPD { get; set; }
    public string NoBPK { get; set; }
    public string UnitKey { get; set; }
    public int IdTrans { get; set; }
    public DateTime? TglKirim { get; set; }
    [Key]
    public int Id { get; set; }
    public DateTime? DateCreate { get; set; }
    public DateTime? DateUpdate { get; set; }
  }
}