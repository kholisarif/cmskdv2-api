using ICMSTU.API.Commands.Role;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace ICMSTU.API.Controllers.ApiControllers
{
  [Route("api/[controller]")]
  [ApiController]
  public class RoleController : ControllerBase
  {
    private readonly IMediator _mediator;

    public RoleController(IMediator mediator)
    {
      _mediator = mediator;
    }

    [HttpPost]
    public async Task<IActionResult> Post(RoleCreate command)
    {
      var result = await _mediator.Send(command);

      return Ok(result);
    }

    [HttpPut]
    public async Task<IActionResult> Put(RoleUpdate command)
    {
      var result = await _mediator.Send(command);

      return Ok(result);
    }

    //[HttpDelete]
    //public async Task<IActionResult> Delete(RoleDelete command)
    //{
    //  var result = await _mediator.Send(command);

    //  return NoContent();
    //}

    [HttpDelete]
    public async Task<IActionResult> Delete(RoleBulkDelete command)
    {
      var result = await _mediator.Send(command);

      return NoContent();
    }
  }
}
