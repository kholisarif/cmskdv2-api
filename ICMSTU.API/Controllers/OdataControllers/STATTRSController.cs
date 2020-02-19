using ICMSTU.API.Infrastructures;
using Microsoft.AspNet.OData;
using Microsoft.AspNet.OData.Routing;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using ICMSTU.API.Models.Entities;

namespace ICMSTU.API.Controllers.OdataControllers
{
  [ODataRoutePrefix(nameof(STATTRS))]
  public class STATTRSController : ODataController
  {
    private readonly DataContext _ctx;

    public STATTRSController(DataContext ctx)
    {
      _ctx = ctx;
    }

    [EnableQuery]
    public IActionResult GetSTATTRS() => Ok(_ctx.STATTRS.AsQueryable());
  }
}
