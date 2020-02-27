using System.ComponentModel.DataAnnotations.Schema;
using System;
using System.ComponentModel.DataAnnotations;

namespace ICMSTU.API.Models.Entities
{
  [Table("NPD")]
  public class NPD
  {
    public string NonPD { get; set; }
    public string UnitKey { get; set; }
    public string KeyBend { get; set; }
    public int IdTrans { get; set; }
    public string Uraian { get; set; }
    public DateTime? TglNPD { get; set; }
    [Key]
    public int Id { get; set; }
    public DateTime? DateCreate { get; set; }
    public DateTime? DateUpdate { get; set; }
  }
}