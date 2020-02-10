using System.ComponentModel.DataAnnotations.Schema;

namespace ICMSTU.API.Models.Entities
{
  [Table("SPPPAJAK")]
  public class SPPPajak
  {
    public int Id { get; set; }
    public int SppRincianId { get; set; }
    public SPPRincian SppRincian { get; set; }
    public int PajakId { get; set; }
    public Pajak Pajak { get; set; }
  }
}