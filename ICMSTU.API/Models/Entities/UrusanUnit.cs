using System.ComponentModel.DataAnnotations.Schema;

namespace ICMSTU.API.Models.Entities
{
  [Table("URUSANUNIT")]
  public class UrusanUnit
  {
    public int UnitOrganisasiId { get; set; }
    public UnitOrganisasi UnitOrganisasi { get; set; }
    public int UrusanId { get; set; }
    public UnitOrganisasi Urusan { get; set; }
  }
}
