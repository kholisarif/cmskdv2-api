using System;

namespace ICMSTU.API.Models.Entities
{
  public class MCAS
  {
    public int? CreatedById { get; set; }
    public DateTime? CreatedDate { get; set; }
    public string CreatedByName { get; set; }
    public int? CheckedById { get; set; }
    public DateTime? CheckedDate { get; set; }
    public string CheckedByName { get; set; }
    public int? ApprovedById { get; set; }
    public DateTime? ApprovedDate { get; set; }
    public string ApprovedByName { get; set; }
    public int SignedById { get; set; }
    public DateTime? SignedDate { get; set; }
    public string SignedByName { get; set; }
  }
}
