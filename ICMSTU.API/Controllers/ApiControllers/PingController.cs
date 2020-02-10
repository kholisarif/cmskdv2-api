using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ICMSTU.API.Controllers.ApiControllers
{
  [Route("api/[controller]")]
  [ApiController]
  public class PingController : ControllerBase
  {
    private readonly IHttpContextAccessor _accessor;

    public PingController(IHttpContextAccessor accessor)
    {
      _accessor = accessor;
    }

    [HttpGet]
    public IActionResult Ping()
    {
      var ip = _accessor.HttpContext?.Connection?.RemoteIpAddress?.ToString();

      return Ok(new { Message = $"You are pinging from {ip}" });
    }
  }
}
