using ICMSTU.API.Commands.BPKDETRDANA;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace ICMSTU.API.Controllers.ApiControllers
{
  [Route("api/[controller]")]
  [ApiController]
  public class BPKDETRDANAController : ControllerBase
  {
    private readonly IMediator _mediator;

    public BPKDETRDANAController(IMediator mediator)
    {
      _mediator = mediator;
    }

    [HttpPost]
    public async Task<IActionResult> Post(BPKDETRDANACreate command)
    {
      var result = await _mediator.Send(command);

      return Ok(result);
    }

    [HttpPut]
    public async Task<IActionResult> Put(BPKDETRDANAUpdate command)
    {
      var result = await _mediator.Send(command);

      return Ok(result);
    }

    [HttpDelete]
    public async Task<IActionResult> BulkDelete(BPKDETRDANABulkDelete command)
    {
      await _mediator.Send(command);

      return NoContent();
    }
  }
}
