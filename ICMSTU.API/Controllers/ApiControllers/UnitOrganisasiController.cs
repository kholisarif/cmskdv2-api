using ICMSTU.API.Commands.UnitOrganisasi;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;
using System.Threading.Tasks;

namespace ICMSTU.API.Controllers.ApiControllers
{
  [Route("api/[controller]")]
  [ApiController]
  public class UnitOrganisasiController : ControllerBase
  {
    private readonly IMediator _mediator;

    public UnitOrganisasiController(IMediator mediator)
    {
      _mediator = mediator;
    }

    [HttpPost]
    public async Task<IActionResult> Create(UnitOrganisasiCreate message)
    {
      var result = await _mediator.Send(message);

      return Ok(result);
    }

    [HttpPut]
    public async Task<IActionResult> Update(UnitOrganisasiUpdate message)
    {
      var result = await _mediator.Send(message);

      return Ok(result);
    }

    //[HttpDelete]
    //public async Task<IActionResult> Delete(UnitOrganisasiDelete command)
    //{
    //  await _mediator.Send(command);

    //  return NoContent();
    //}

    [HttpDelete]
    public async Task<IActionResult> BulkDelete(UnitOrganisasiBulkDelete command)
    {
      await _mediator.Send(command);

      return NoContent();
    }
  }
}
