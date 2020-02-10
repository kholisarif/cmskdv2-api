using ICMSTU.API.Commands.BPKDETR;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace ICMSTU.API.Controllers.ApiControllers
{
  [Route("api/[controller]")]
  [ApiController]
  public class BPKDETRController : ControllerBase
  {
    private readonly IMediator _mediator;

    public BPKDETRController(IMediator mediator)
    {
      _mediator = mediator;
    }

    [HttpPost]
    public async Task<IActionResult> Post(BPKDETRCreate command)
    {
      var result = await _mediator.Send(command);

      return Ok(result);
    }

    [HttpPut]
    public async Task<IActionResult> Put(BPKDETRUpdate command)
    {
      var result = await _mediator.Send(command);

      return Ok(result);
    }

    [HttpDelete]
    public async Task<IActionResult> BulkDelete(BPKDETRBulkDelete command)
    {
      await _mediator.Send(command);

      return NoContent();
    }
  }
}
