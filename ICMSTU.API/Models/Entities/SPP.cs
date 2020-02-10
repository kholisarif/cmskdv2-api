using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace ICMSTU.API.Models.Entities
{
  [Table("SPP")]
  public class SPP : MCAS
  {
    public int Id { get; set; }
    public int UnitOrganisasiId { get; set; }
    public UnitOrganisasi UnitOrganisasi { get; set; }
    public int JnsTransaksiId { get; set; }
    public JnsTransaksi JnsTransaksi { get; set; }
    public int? KegiatanUnitId { get; set; }
    public KegiatanUnit KegiatanUnit { get; set; }
    public int? NoPengajuan { get; set; }
    public DateTime? TglPengajuan { get; set; }
    public string NoRegister { get; set; }
    public string Keperluan { get; set; }
    public ICollection<SPPRincian> SppRincian { get; set; }
  }
}