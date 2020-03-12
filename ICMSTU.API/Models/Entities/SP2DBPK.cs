using System.ComponentModel.DataAnnotations.Schema;
using System;
using System.ComponentModel.DataAnnotations;

namespace ICMSTU.API.Models.Entities
{
  [Table("SP2DBPK")]
  public class SP2DBPK
  {
    
    public string NoBPK { get; set; }
    public string UnitKey { get; set; }
    public string NoSP2D { get; set; }
    [Key]
    public int Id { get; set; }
    public int IdSP2D { get; set; }
    [ForeignKey("IdSP2D")]
    public SP2D SP2D { get; set; }
    public DateTime? DateCreate { get; set; }
    public DateTime? DateUpdate { get; set; }
  }
}