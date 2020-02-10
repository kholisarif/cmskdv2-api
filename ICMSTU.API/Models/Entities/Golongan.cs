using System.ComponentModel.DataAnnotations.Schema;

namespace ICMSTU.API.Models.Entities
{
  [Table("GOLONGAN")]
  public class Golongan
  {
    public int Id { get; set; }
    public string Kode { get; set; }
    public string Pangkat { get; set; }
  }
}