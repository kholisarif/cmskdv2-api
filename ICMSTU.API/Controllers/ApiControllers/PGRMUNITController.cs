using ICMSTU.API.Commands.PGRMUNIT;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace ICMSTU.API.Controllers.ApiControllers
{
  [Route("api/[controller]")]
  [ApiController]
  public class PGRMUNITController : ControllerBase
  {
    private readonly IMediator _mediator;

    public PGRMUNITController(IMediator mediator)
    {
      _mediator = mediator;
    }

    [HttpPost]
    public async Task<IActionResult> Post(PGRMUNITCreate command)
    {
      var result = await _mediator.Send(command);

      return Ok(result);
    }

    [HttpPut]
    public async Task<IActionResult> Put(PGRMUNITUpdate command)
    {
      var result = await _mediator.Send(command);

      return Ok(result);
    }

    [HttpDelete]
    public async Task<IActionResult> BulkDelete(PGRMUNITBulkDelete command)
    {
      await _mediator.Send(command);

      return NoContent();
    }
  }
}
