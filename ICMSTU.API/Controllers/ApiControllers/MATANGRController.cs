using ICMSTU.API.Commands.MATANGR;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace ICMSTU.API.Controllers.ApiControllers
{
  [Route("api/[controller]")]
  [ApiController]
  public class MATANGRController : ControllerBase
  {
    private readonly IMediator _mediator;

    public MATANGRController(IMediator mediator)
    {
      _mediator = mediator;
    }

    [HttpPost]
    public async Task<IActionResult> Post(MATANGRCreate command)
    {
      var result = await _mediator.Send(command);

      return Ok(result);
    }

    [HttpPut]
    public async Task<IActionResult> Put(MATANGRUpdate command)
    {
      var result = await _mediator.Send(command);

      return Ok(result);
    }

    [HttpDelete]
    public async Task<IActionResult> BulkDelete(MATANGRBulkDelete command)
    {
      await _mediator.Send(command);

      return NoContent();
    }
  }
}
