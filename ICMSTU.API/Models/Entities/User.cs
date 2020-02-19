using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace ICMSTU.API.Models.Entities
{
  [Table("USER")]
  public class User
  {
    public int Id { get; set; }
    public string Username { get; set; }
    public int? UnitOrganisasiId { get; set; }
    public UnitOrganisasi UnitOrganisasi { get; set; }
    public string NIP { get; set; }
    public Pegawai Pegawai { get; set; }
    public string Password { get; set; }
    public byte FalseLoginCount { get; set; }
    public bool LockedOut { get; set; }
    public string Deskripsi { get; set; }
    public ICollection<UserRole> UserRoleCollection { get; set; }
  }
}
