using ICMSTU.API.Commands.JDANA;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace ICMSTU.API.Controllers.ApiControllers
{
  [Route("api/[controller]")]
  [ApiController]
  public class JDANAController : ControllerBase
  {
    private readonly IMediator _mediator;

    public JDANAController(IMediator mediator)
    {
      _mediator = mediator;
    }

    [HttpPost]
    public async Task<IActionResult> Post(JDANACreate command)
    {
      var result = await _mediator.Send(command);

      return Ok(result);
    }

    [HttpPut]
    public async Task<IActionResult> Put(JDANAUpdate command)
    {
      var result = await _mediator.Send(command);

      return Ok(result);
    }

    [HttpDelete]
    public async Task<IActionResult> BulkDelete(JDANABulkDelete command)
    {
      await _mediator.Send(command);

      return NoContent();
    }
  }
}
