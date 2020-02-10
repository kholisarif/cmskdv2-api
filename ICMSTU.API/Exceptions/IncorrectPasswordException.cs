namespace ICMSTU.API.Exceptions
{
  public class IncorrectPasswordException : CustomException
  {
    public IncorrectPasswordException() : base("User/Password salah")
    {
    }
  }
}