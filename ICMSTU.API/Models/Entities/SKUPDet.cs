using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace ICMSTU.API.Models.Entities
{
  [Table("SKUPDET")]
  public class SKUPDet
  {
    public int Id { get; set; }
    public int SKUPId { get; set; }
    public SKUP SKUP { get; set; }
    public int UnitOrganisasiId { get; set; }
    public UnitOrganisasi UnitOrganisasi { get; set; }
    public decimal Nilai { get; set; }
  }
}