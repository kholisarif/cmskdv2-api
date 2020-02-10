using System.ComponentModel.DataAnnotations.Schema;

namespace ICMSTU.API.Models.Entities
{
  [Table("STRUKTURUNIT")]
  public class StrukturUnit
  {
    public int Id { get; set; }
    public string Nama { get; set; }
  }
}
