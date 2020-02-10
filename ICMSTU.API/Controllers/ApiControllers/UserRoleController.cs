using ICMSTU.API.Commands.UserRole;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace ICMSTU.API.Controllers.ApiControllers
{
  [Route("api/[controller]")]
  [ApiController]
  public class UserRoleController : ControllerBase
  {
    private readonly IMediator _mediator;

    public UserRoleController(IMediator mediator)
    {
      _mediator = mediator;
    }

    [HttpPost]
    public async Task<IActionResult> Create(UserRoleCreate message)
    {
      var result = await _mediator.Send(message);

      return Ok(result);
    }

    [HttpDelete]
    public async Task<IActionResult> Delete(UserRoleDelete message)
    {
      var result = await _mediator.Send(message);

      return Ok(result);
    }
  }
}