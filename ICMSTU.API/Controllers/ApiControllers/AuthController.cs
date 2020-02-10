using ICMSTU.API.Commands.User;
using ICMSTU.API.Exceptions;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace ICMSTU.API.Controllers.ApiControllers
{
  [Route("api/[controller]")]
  [ApiController]
  public class AuthController : ControllerBase
  {
    private readonly IMediator _mediator;

    public AuthController(IMediator mediator)
    {
      _mediator = mediator;
    }

    [AllowAnonymous]
    [Route("token")]
    [HttpPost]
    public async Task<IActionResult> Token(UserLogin command)
    {
      try
      {
        var token = await _mediator.Send(command);

        return Ok(token);
      }
      catch (NoRecordException)
      {
        return Unauthorized();
      }
      catch (Exception e)
      {
        return BadRequest(e.InnerException?.Message ?? e.Message);
      }
    }

    [AllowAnonymous]
    [HttpPost("token/refresh")]
    public async Task<IActionResult> RefreshToken([FromBody] ValidateRefreshToken command)
    {
      try
      {
        return Ok(await _mediator.Send(command));
      }
      catch (NoRecordException)
      {
        return Unauthorized();
      }
      catch (TokenExpiredException)
      {
        return Unauthorized();
      }
      catch (Exception e)
      {
        return BadRequest(e.InnerException?.Message ?? e.Message);
      }
    }
  }
}
