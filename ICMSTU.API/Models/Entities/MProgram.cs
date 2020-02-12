using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace ICMSTU.API.Models.Entities
{
  [Table("MPROGRAM")]
  public class MProgram
  {
    public int Id { get; set; }
    public int? UrusanId { get; set; }
    public UnitOrganisasi UnitOrganisasi { get; set; }
    public string Kode { get; set; }
    public string Nama { get; set; }
    //public ICollection<MKegiatan> MKegiatan { get; set; }
  }
}
