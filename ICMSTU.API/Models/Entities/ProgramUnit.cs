using System.ComponentModel.DataAnnotations.Schema;

namespace ICMSTU.API.Models.Entities
{
  [Table("PROGRAMUNIT")]
  public class ProgramUnit
  {
    public int Id { get; set; }
    public int TahapanId { get; set; }
    public Tahapan Tahapan { get; set; }
    public int ProgramId { get; set; }
    public MProgram Program { get; set; }
    public int UnitOrganisasiId { get; set; }
    public UnitOrganisasi UnitOrganisasi { get; set; }
    public string Target { get; set; }
    public string Sasaran { get; set; }
    public string Indikator { get; set; }
  }
}