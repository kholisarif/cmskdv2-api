using System.ComponentModel.DataAnnotations.Schema;

namespace ICMSTU.API.Models.Entities
{
  [Table("PERMISSION")]
  public class Permission
  {
    public int RoleId { get; set; }
    public Role Role { get; set; }
    public int MenuId { get; set; }
    public Menu Menu { get; set; }
    public bool Maker { get; set; }
    public bool Checker { get; set; }
    public bool Approver { get; set; }
  }
}
