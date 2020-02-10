using System.ComponentModel.DataAnnotations.Schema;

namespace ICMSTU.API.Models.Entities
{
  [Table("JNSBEND")]
  public class JnsBend
  {
    public int Id { get; set; }
    public string Nama { get; set; }
  }
}