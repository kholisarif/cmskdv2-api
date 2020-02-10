namespace ICMSTU.API.Models.Entities
{
  public class RKUD
  {
    public int Id { get; set; }
    public int BankId { get; set; }
    public Bank Bank { get; set; }
    public string NamaRekening { get; set; }
    public string NoRekening { get; set; }
    public decimal SaldoAwal { get; set; }
  }
}
