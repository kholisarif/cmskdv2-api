using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace ICMSTU.API.Models.Entities
{
  [Table("UNITORGANISASI")]
  public class UnitOrganisasi
  {
    public int Id { get; set; }
    //public int? ParentId { get; set; }
    //public UnitOrganisasi Parent { get; set; }
    public int Lvl { get; set; }
    public string Kode { get; set; }
    public string Nama { get; set; }
    public string Akronim { get; set; }
    public string Alamat { get; set; }
    public string Telepon { get; set; }
    public string Tipe { get; set; }
    //public ICollection<UnitOrganisasi> OPDCollection { get; set; }
    public ICollection<MProgram> MProgram { get; set; }
    public ICollection<ProgramUnit> ProgramUnit { get; set; }
    public ICollection<KegiatanUnit> KegiatanUnit { get; set; }
  }
}