using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace ICMSTU.API.Models.Entities
{
  [Table("SPPRINCIAN")]
  public class SPPRincian
  {
    public int Id { get; set; }
    public int SppId { get; set; }
    public SPP Spp { get; set; }
    public int RekeningId { get; set; }
    public Rekening Rekening { get; set; }
    public ICollection<SPPPajak> SppPajak { get; set; }
  }
}