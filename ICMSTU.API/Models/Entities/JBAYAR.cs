using System.ComponentModel.DataAnnotations.Schema;
using System;

namespace ICMSTU.API.Models.Entities
{
  [Table("JBAYAR")]
  public class JBAYAR
  {
    public int KdBayar { get; set; }
    public string UraianBayar { get; set; }
    public int Id { get; set; }
    public DateTime? DateCreate { get; set; }
    public DateTime? DateUpdate { get; set; }
  }
}