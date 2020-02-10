using ICMSTU.API.Commands.User;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace ICMSTU.API.Controllers.ApiControllers
{
  [Route("api/[controller]")]
  [ApiController]
  public class UserController : ControllerBase
  {
    private readonly IMediator _mediator;

    public UserController(IMediator mediator)
    {
      _mediator = mediator;
    }

    [HttpPost]
    public async Task<IActionResult> Create(UserCreate message)
    {
      var result = await _mediator.Send(message);

      return Ok(result);
    }

    [HttpPut]
    public async Task<IActionResult> Update(UserUpdate message)
    {
      var result = await _mediator.Send(message);

      return Ok(result);
    }

    //[HttpDelete]
    //public async Task<IActionResult> Delete(UserDelete message)
    //{
    //  var result = await _mediator.Send(message);

    //  return Ok(result);
    //}

    [HttpDelete]
    public async Task<IActionResult> Delete(UserBulkDelete message)
    {
      var result = await _mediator.Send(message);

      return Ok(result);
    }
  }
}
