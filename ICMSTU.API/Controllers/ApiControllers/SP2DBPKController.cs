using ICMSTU.API.Commands.SP2DBPK;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace ICMSTU.API.Controllers.ApiControllers
{
  [Route("api/[controller]")]
  [ApiController]
  public class SP2DBPKController : ControllerBase
  {
    private readonly IMediator _mediator;

    public SP2DBPKController(IMediator mediator)
    {
      _mediator = mediator;
    }

    [HttpPost]
    public async Task<IActionResult> Post(SP2DBPKCreate command)
    {
      var result = await _mediator.Send(command);

      return Ok(result);
    }

    [HttpPut]
    public async Task<IActionResult> Put(SP2DBPKUpdate command)
    {
      var result = await _mediator.Send(command);

      return Ok(result);
    }

    [HttpDelete]
    public async Task<IActionResult> BulkDelete(SP2DBPKBulkDelete command)
    {
      await _mediator.Send(command);

      return NoContent();
    }
  }
}
