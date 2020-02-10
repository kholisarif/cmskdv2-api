namespace ICMSTU.API.Exceptions
{
  public class NoRecordException : CustomException
  {
    public NoRecordException() : base("Record tidak ditemukan")
    {
    }

    public NoRecordException(string message) : base(message)
    {
    }
  }
}