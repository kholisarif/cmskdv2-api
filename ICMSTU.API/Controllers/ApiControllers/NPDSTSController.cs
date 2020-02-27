using ICMSTU.API.Commands.NPDSTS;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace ICMSTU.API.Controllers.ApiControllers
{
  [Route("api/[controller]")]
  [ApiController]
  public class NPDSTSController : ControllerBase
  {
    private readonly IMediator _mediator;

    public NPDSTSController(IMediator mediator)
    {
      _mediator = mediator;
    }

    [HttpPost]
    public async Task<IActionResult> Post(NPDSTSCreate command)
    {
      var result = await _mediator.Send(command);

      return Ok(result);
    }

    [HttpPut]
    public async Task<IActionResult> Put(NPDSTSUpdate command)
    {
      var result = await _mediator.Send(command);

      return Ok(result);
    }

    [HttpDelete]
    public async Task<IActionResult> BulkDelete(NPDSTSBulkDelete command)
    {
      await _mediator.Send(command);

      return NoContent();
    }
  }
}
