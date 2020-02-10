using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace ICMSTU.API.Models.Entities
{
  [Table("MENU")]
  public class Menu
  {
    public int Id { get; set; }
    //public int? ParentId { get; set; }
    //public Menu Parent { get; set; }
    public string Kode { get; set; }
    public string Label { get; set; }
    public string Icon { get; set; }
    public string Resource { get; set; }
    public string RouterLink { get; set; }
    public string QueryParams { get; set; }
    public string Configuration { get; set; }
    public int Lvl { get; set; }
    public string Tipe { get; set; }
    //public ICollection<Menu> MenuCollection { get; set; }
    public ICollection<Permission> Permissions { get; set; }
  }
}
