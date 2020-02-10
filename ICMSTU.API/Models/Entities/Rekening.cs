using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace ICMSTU.API.Models.Entities
{
  [Table("REKENING")]
  public class Rekening
  {
    public int Id { get; set; }
    public string Kode { get; set; }
    public string Nama { get; set; }
    public int Lvl { get; set; }
    public int KdKhusus { get; set; }
    public int JnsRek { get; set; }
    public int JnsAkun { get; set; }
    public string Tipe { get; set; }
    public ICollection<SPPRincian> SppRincian { get; set; }
  }
}