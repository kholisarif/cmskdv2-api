namespace ICMSTU.API.Exceptions
{
  public class ParentConstrainViolationException : CustomException
  {
    public ParentConstrainViolationException() : base("Data masih memiliki anak. Hapus data anak terlebih dahulu sebelum menghapus data induk")
    {
    }
  }
}