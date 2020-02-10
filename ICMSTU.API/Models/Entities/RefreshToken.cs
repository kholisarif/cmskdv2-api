using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace ICMSTU.API.Models.Entities
{
  [Table("REFRESHTOKEN")]
  public class RefreshToken
  {
    public int Id { get; set; }
    public string Token { get; set; }
    public DateTime IssuedAt { get; set; }
    public DateTime ExpireAt { get; set; }
    public int UserId { get; set; }
    public User User { get; set; }
  }
}
