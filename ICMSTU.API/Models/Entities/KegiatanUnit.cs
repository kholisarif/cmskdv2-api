using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace ICMSTU.API.Models.Entities
{
  [Table("KEGIATANUNIT")]
  public class KegiatanUnit
  {
    public int Id { get; set; }
    public int ProgramUnitId { get; set; }
    public ProgramUnit ProgramUnit { get; set; }
    public int UnitOrganisasiId { get; set; }
    public UnitOrganisasi UnitOrganisasi { get; set; }
    public int TahapanId { get; set; }
    public Tahapan Tahapan { get; set; }
    public DateTime? TglAwal { get; set; }
    public DateTime? TglAkhir { get; set; }
    public string Lokasi { get; set; }
    public string TolakUkur { get; set; }
    public string Sasaran { get; set; }
    public decimal TargetP { get; set; }
    public decimal JumlahMin1 { get; set; }
    public decimal Pagu { get; set; }
    public decimal JumlahPlus1 { get; set; }
  }
}