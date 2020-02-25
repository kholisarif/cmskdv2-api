using System.ComponentModel.DataAnnotations.Schema;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ICMSTU.API.Models.Entities
{
  [Table("BEND")]
  public class BEND
  {
    public string KeyBend { get; set; }
    public string Jns_Bend { get; set; }
    public string NIP { get; set; }
    public string KdBank { get; set; }
    public string UnitKey { get; set; }
    public string Jab_Bend { get; set; }
    public string RekBend{ get; set; }
    public decimal? SaldoBend { get; set; }
    public string NPWPBend { get; set; }
    [Column(TypeName="Date")]
    public DateTime? TglStopBend { get; set; }
    public decimal? SaldoBendT { get; set; }
    [Key]
    public int Id { get; set; }
    public int IdDAFTUNIT { get; set; }
    [ForeignKey("IdDAFTUNIT")]
    public DAFTUNIT DAFTUNIT { get; set; }
    public int IdPegawai { get; set; }
    [ForeignKey("IdPegawai")]
    public Pegawai Pegawai { get; set; }
    public int StAktif { get; set; }
    public DateTime? DateCreate { get; set; }
    public DateTime? DateUpdate { get; set; }
  }
}
