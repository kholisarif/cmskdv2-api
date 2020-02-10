namespace ICMSTU.API.Exceptions
{
  public class TokenExpiredException : CustomException
  {
    public TokenExpiredException() : base("Token expired")
    {
    }

    public TokenExpiredException(string message) : base(message)
    {
    }
  }
}
