using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace ICMSTU.API.Models.Entities
{
  [Table("TAHAPAN")]
  public class Tahapan
  {
    public int Id { get; set; }
    //public int? ParentId { get; set; }
    //public Tahapan Parent { get; set; }
    public string Kode { get; set; }
    public string Nama { get; set; }
    //public int Lvl { get; set; }
    //public string Tipe { get; set; }
    //public ICollection<Tahapan> Children { get; set; }
    public ICollection<ProgramUnit> ProgramUnit { get; set; }
    public ICollection<KegiatanUnit> KegiatanUnit { get; set; }
  }
}
