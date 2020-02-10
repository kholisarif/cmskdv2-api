namespace ICMSTU.API.Helpers
{
  public static class StringExtension
  {
    public static int? ToNullableInt(this string s)
    {
      if (int.TryParse(s, out var i)) return i;
      return null;
    }
  }
}
