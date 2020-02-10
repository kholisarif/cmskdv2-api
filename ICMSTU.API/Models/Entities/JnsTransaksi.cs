using System.ComponentModel.DataAnnotations.Schema;

namespace ICMSTU.API.Models.Entities
{
  [Table("JNSTRANSAKSI")]
  public class JnsTransaksi
  {
    public int Id { get; set; }
    public string Kode { get; set; }
    public string Nama { get; set; }
  }
}