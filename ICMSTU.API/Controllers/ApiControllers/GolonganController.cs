using ICMSTU.API.Commands.Golongan;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace ICMSTU.API.Controllers.ApiControllers
{
  [Route("api/[controller]")]
  [ApiController]
  public class GolonganController : ControllerBase
  {
    private readonly IMediator _mediator;

    public GolonganController(IMediator mediator)
    {
      _mediator = mediator;
    }

    [HttpPost]
    public async Task<IActionResult> Post(GolonganCreate command)
    {
      var result = await _mediator.Send(command);

      return Ok(result);
    }

    [HttpPut]
    public async Task<IActionResult> Put(GolonganUpdate command)
    {
      var result = await _mediator.Send(command);

      return Ok(result);
    }

    //[HttpDelete]
    //public async Task<IActionResult> Delete(GolonganDelete command)
    //{
    //  await _mediator.Send(command);

    //  return NoContent();
    //}

    [HttpDelete]
    public async Task<IActionResult> BulkDelete(GolonganBulkDelete command)
    {
      await _mediator.Send(command);

      return NoContent();
    }
  }
}
