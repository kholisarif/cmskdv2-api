using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace ICMSTU.API.Models.Entities
{
  [Table("BENDAHARA")]
  public class Bendahara
  {
    public int Id { get; set; }
    public string NoSK { get; set; }
    public int UnitOrganisasiId { get; set; }
    public UnitOrganisasi UnitOrganisasi { get; set; }
    public int JnsBendId { get; set; }
    public JnsBend JnsBend { get; set; }
    public int PegawaiId { get; set; }
    public Pegawai Pegawai { get; set; }
    public int BankId { get; set; }
    public Bank Bank { get; set; }
    public string KodeRekening { get; set; }
    public string NPWP { get; set; }
    public decimal SaldoBend { get; set; }
    public decimal SaldoBendt { get; set; }
    public DateTime? TglAwal { get; set; }
    public DateTime? TglAkhir { get; set; }
    public bool StatusAktif { get; set; }
    public DateTime TglNonAktif { get; set; }
  }
}
