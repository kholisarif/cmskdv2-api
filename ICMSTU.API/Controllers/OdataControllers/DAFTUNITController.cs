using ICMSTU.API.Infrastructures;
using Microsoft.AspNet.OData;
using Microsoft.AspNet.OData.Routing;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using ICMSTU.API.Models.Entities;

namespace ICMSTU.API.Controllers.OdataControllers
{
  [ODataRoutePrefix(nameof(DAFTUNIT))]
  public class DAFTUNITController : ODataController
  {
    private readonly DataContext _ctx;

    public DAFTUNITController(DataContext ctx)
    {
      _ctx = ctx;
    }

    [EnableQuery]
    public IActionResult GetDAFTUNIT() => Ok(_ctx.DAFTUNIT.AsQueryable());
  }
}
