using System.ComponentModel.DataAnnotations.Schema;

namespace ICMSTU.API.Models.Entities
{
  [Table("STUKTURREKENING")]
  public class StrukturRekening
  {
    public int Id { get; set; }
    public string Nama { get; set; }
  }
}
