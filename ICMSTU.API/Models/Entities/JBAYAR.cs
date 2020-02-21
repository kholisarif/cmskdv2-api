using System.ComponentModel.DataAnnotations.Schema;
using System;
using System.ComponentModel.DataAnnotations;

namespace ICMSTU.API.Models.Entities
{
  [Table("JBAYAR")]
  public class JBAYAR
  {
    
    public int KdBayar { get; set; }
    public string UraianBayar { get; set; }
    [Key]
    public int Id { get; set; }
    public DateTime? DateCreate { get; set; }
    public DateTime? DateUpdate { get; set; }
  }
}