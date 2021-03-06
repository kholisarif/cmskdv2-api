﻿using System.ComponentModel.DataAnnotations.Schema;
using System;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;

namespace ICMSTU.API.Models.Entities
{
  [Table("PEGAWAI")]
  public class Pegawai
  {
    [Key]
    public int Id { get; set; }
    public int? IdDAFTUNIT { get; set; }
    [ForeignKey("IdDAFTUNIT")]
    public DAFTUNIT DAFTUNIT { get; set; }
    public string NIP { get; set; }
    public string KdGol { get; set; }
    public string UnitKey { get; set; }
    public string Nama { get; set; }
    //public int GolonganId { get; set; }
    //public Golongan Golongan { get; set; }
    //public int UnitOrganisasiId { get; set; }
    //public UnitOrganisasi UnitOrganisasi { get; set; }
    public string Alamat { get; set; }
    public string Jabatan { get; set; }
    public string PDDK { get; set; }
    public string NPWP { get; set; }
    public DateTime? DateCreate { get; set; }
    public DateTime? DateUpdate { get; set; }
    public List<BEND> BENDs { get; set; }
  }
}