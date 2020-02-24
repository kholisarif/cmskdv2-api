using System.ComponentModel.DataAnnotations.Schema;
using System;
using System.ComponentModel.DataAnnotations;

namespace ICMSTU.API.Models.Entities
{
  [Table("JCAIR")]
  public class JCAIR
  {
    public int StCair { get; set; }
    public string UraiCair { get; set; }
    [Key]
    public int Id { get; set; }
    public DateTime? DateCreate { get; set; }
    public DateTime? DateUpdate { get; set; }
  }
}