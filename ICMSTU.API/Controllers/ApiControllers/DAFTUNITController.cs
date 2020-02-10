using ICMSTU.API.Commands.DAFTUNIT;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace ICMSTU.API.Controllers.ApiControllers
{
  [Route("api/[controller]")]
  [ApiController]
  public class DAFTUNITController : ControllerBase
  {
    private readonly IMediator _mediator;

    public DAFTUNITController(IMediator mediator)
    {
      _mediator = mediator;
    }

    [HttpPost]
    public async Task<IActionResult> Post(DAFTUNITCreate command)
    {
      var result = await _mediator.Send(command);

      return Ok(result);
    }

    [HttpPut]
    public async Task<IActionResult> Put(DAFTUNITUpdate command)
    {
      var result = await _mediator.Send(command);

      return Ok(result);
    }

    [HttpDelete]
    public async Task<IActionResult> BulkDelete(DAFTUNITBulkDelete command)
    {
      await _mediator.Send(command);

      return NoContent();
    }
  }
}
