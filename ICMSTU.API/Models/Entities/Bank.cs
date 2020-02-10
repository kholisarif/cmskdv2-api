using System.ComponentModel.DataAnnotations.Schema;

namespace ICMSTU.API.Models.Entities
{
  [Table("BANK")]
  public class Bank
  {
    public int Id { get; set; }
    public string NamaLengkap { get; set; }
    public string Nama { get; set; }
    public string KodeBank { get; set; }
    public string KodeSKN { get; set; }
    public string KodeRTGS { get; set; }
    public string KodeKota { get; set; }
    public string KodeSwift { get; set; }
  }
}