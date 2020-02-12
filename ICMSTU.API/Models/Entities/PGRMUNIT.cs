using System.ComponentModel.DataAnnotations.Schema;
using System;
namespace ICMSTU.API.Models.Entities
{
  [Table("PGRMUNIT")]
  public class PGRMUNIT
  {
    public int Id { get; set; }
    public string kdtahap { get; set; }
    //public Tahapan Tahapan { get; set; }
    public string UnitKey { get; set; }
    public string IdPrgrm { get; set; }
    public MPGRM MPGRM { get; set; }
    //public int UnitOrganisasiId { get; set; }
    //public UnitOrganisasi UnitOrganisasi { get; set; }
    public string Target { get; set; }
    public string Sasaran { get; set; }
    public int? NoPrio { get; set; }
    public DateTime? DateCreate { get; set; }
    public DateTime? DateUpdate { get; set; }
  }
}
