using ICMSTU.API.Commands.NPDTBPL;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace ICMSTU.API.Controllers.ApiControllers
{
  [Route("api/[controller]")]
  [ApiController]
  public class NPDTBPLController : ControllerBase
  {
    private readonly IMediator _mediator;

    public NPDTBPLController(IMediator mediator)
    {
      _mediator = mediator;
    }

    [HttpPost]
    public async Task<IActionResult> Post(NPDTBPLCreate command)
    {
      var result = await _mediator.Send(command);

      return Ok(result);
    }

    [HttpPut]
    public async Task<IActionResult> Put(NPDTBPLUpdate command)
    {
      var result = await _mediator.Send(command);

      return Ok(result);
    }

    [HttpDelete]
    public async Task<IActionResult> BulkDelete(NPDTBPLBulkDelete command)
    {
      await _mediator.Send(command);

      return NoContent();
    }
  }
}
