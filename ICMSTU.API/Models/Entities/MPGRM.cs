using System.ComponentModel.DataAnnotations.Schema;
using System;

namespace ICMSTU.API.Models.Entities
{
  [Table("MPGRM")]
  public class MPGRM
  {
    public string IdPrgrm { get; set; }
    public string UnitKey { get; set; }
    public string NmPrgrm { get; set; }
    public string NuPrgrm { get; set; }
    public int Id { get; set; }
    public DateTime? DateCreate { get; set; }
    public DateTime? DateUpdate { get; set; }
  }
}