using ICMSTU.API.Commands.DAFTPHK;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace ICMSTU.API.Controllers.ApiControllers
{
  [Route("api/[controller]")]
  [ApiController]
  public class DAFTPHKController : ControllerBase
  {
    private readonly IMediator _mediator;

    public DAFTPHKController(IMediator mediator)
    {
      _mediator = mediator;
    }

    [HttpPost]
    public async Task<IActionResult> Post(DAFTPHKCreate command)
    {
      var result = await _mediator.Send(command);

      return Ok(result);
    }

    [HttpPut]
    public async Task<IActionResult> Put(DAFTPHKUpdate command)
    {
      var result = await _mediator.Send(command);

      return Ok(result);
    }

    [HttpDelete]
    public async Task<IActionResult> BulkDelete(DAFTPHKBulkDelete command)
    {
      await _mediator.Send(command);

      return NoContent();
    }
  }
}
