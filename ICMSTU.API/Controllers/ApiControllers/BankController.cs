using ICMSTU.API.Commands.Bank;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace ICMSTU.API.Controllers.ApiControllers
{
  [Route("api/[controller]")]
  [ApiController]
  public class BankController : ControllerBase
  {
    private readonly IMediator _mediator;

    public BankController(IMediator mediator)
    {
      _mediator = mediator;
    }

    [HttpPost]
    public async Task<IActionResult> Post(BankCreate command)
    {
      var result = await _mediator.Send(command);

      return Ok(result);
    }

    [HttpPut]
    public async Task<IActionResult> Put(BankUpdate command)
    {
      var result = await _mediator.Send(command);

      return Ok(result);
    }

    //[HttpDelete]
    //public async Task<IActionResult> Delete(BankDelete command)
    //{
    //  await _mediator.Send(command);

    //  return NoContent();
    //}

    [HttpDelete]
    public async Task<IActionResult> BulkDelete(BankBulkDelete command)
    {
      await _mediator.Send(command);

      return NoContent();
    }
  }
}
