using ICMSTU.API.Commands.MKegiatan;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace ICMSTU.API.Controllers.ApiControllers
{
  [Route("api/[controller]")]
  [ApiController]
  public class MKegiatanController : ControllerBase
  {
    private readonly IMediator _mediator;

    public MKegiatanController(IMediator mediator)
    {
      _mediator = mediator;
    }

    [HttpPost]
    public async Task<IActionResult> Post(MKegiatanCreate command)
    {
      var result = await _mediator.Send(command);

      return Ok(result);
    }

    [HttpPut]
    public async Task<IActionResult> Put(MKegiatanUpdate command)
    {
      var result = await _mediator.Send(command);

      return Ok(result);
    }

    [HttpDelete]
    public async Task<IActionResult> BulkDelete(MKegiatanBulkDelete command)
    {
      await _mediator.Send(command);

      return NoContent();
    }
  }
}
