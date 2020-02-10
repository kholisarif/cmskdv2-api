using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace ICMSTU.API.Models.Entities
{
  [Table("ROLE")]
  public class Role
  {
    public int Id { get; set; }
    public string Nama { get; set; }
    public string Deskripsi { get; set; }
    public ICollection<UserRole> UserRolesCollection { get; set; }
    public ICollection<Permission> Permissions { get; set; }
  }
}