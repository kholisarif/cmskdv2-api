using ICMSTU.API.Commands.JTRANSFER;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace ICMSTU.API.Controllers.ApiControllers
{
  [Route("api/[controller]")]
  [ApiController]
  public class JTRANSFERController : ControllerBase
  {
    private readonly IMediator _mediator;

    public JTRANSFERController(IMediator mediator)
    {
      _mediator = mediator;
    }

    [HttpPost]
    public async Task<IActionResult> Post(JTRANSFERCreate command)
    {
      var result = await _mediator.Send(command);

      return Ok(result);
    }

    [HttpPut]
    public async Task<IActionResult> Put(JTRANSFERUpdate command)
    {
      var result = await _mediator.Send(command);

      return Ok(result);
    }

    [HttpDelete]
    public async Task<IActionResult> BulkDelete(JTRANSFERBulkDelete command)
    {
      await _mediator.Send(command);

      return NoContent();
    }
  }
}
