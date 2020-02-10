using System.ComponentModel.DataAnnotations.Schema;

namespace ICMSTU.API.Models.Entities
{
  [Table("PAJAK")]
  public class Pajak
  {
    public int Id { get; set; }
    public string Kode { get; set; }
    public int KodeMap { get; set; }
    public int NmMap { get; set; }
    public int JnsSetoran { get; set; }
    public int JnsAkun { get; set; }
    public int Lvl { get; set; }
    public string Tipe { get; set; }
  }
}