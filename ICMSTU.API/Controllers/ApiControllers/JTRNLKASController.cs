using ICMSTU.API.Commands.JTRNLKAS;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace ICMSTU.API.Controllers.ApiControllers
{
  [Route("api/[controller]")]
  [ApiController]
  public class JTRNLKASController : ControllerBase
  {
    private readonly IMediator _mediator;

    public JTRNLKASController(IMediator mediator)
    {
      _mediator = mediator;
    }

    [HttpPost]
    public async Task<IActionResult> Post(JTRNLKASCreate command)
    {
      var result = await _mediator.Send(command);

      return Ok(result);
    }

    [HttpPut]
    public async Task<IActionResult> Put(JTRNLKASUpdate command)
    {
      var result = await _mediator.Send(command);

      return Ok(result);
    }

    [HttpDelete]
    public async Task<IActionResult> BulkDelete(JTRNLKASBulkDelete command)
    {
      await _mediator.Send(command);

      return NoContent();
    }
  }
}