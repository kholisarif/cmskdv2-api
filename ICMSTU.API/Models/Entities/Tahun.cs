using System.ComponentModel.DataAnnotations.Schema;

namespace ICMSTU.API.Models.Entities
{
  [Table("TAHUN")]
  public class Tahun
  {
    public int Id { get; set; }
    public int Nilai { get; set; }
  }
}
