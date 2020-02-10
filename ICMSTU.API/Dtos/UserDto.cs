namespace ICMSTU.API.Dtos
{
  public class UserDto
  {
    public int Id { get; set; }
    public string Username { get; set; }
    public int? UnitOrganisasiId { get; set; }
    public int? PegawaiId { get; set; }
    public string Deskripsi { get; set; }
  }
}
