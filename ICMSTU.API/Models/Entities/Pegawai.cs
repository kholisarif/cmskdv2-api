using System.ComponentModel.DataAnnotations.Schema;

namespace ICMSTU.API.Models.Entities
{
  [Table("PEGAWAI")]
  public class Pegawai
  {
    public int Id { get; set; }
    public string Nip { get; set; }
    public string Nama { get; set; }
    public int GolonganId { get; set; }
    public Golongan Golongan { get; set; }
    //public int UnitOrganisasiId { get; set; }
    //public UnitOrganisasi UnitOrganisasi { get; set; }
    public string Alamat { get; set; }
    public string Jabatan { get; set; }
    public string Pendidikan { get; set; }
  }
}