using ICMSTU.API.Infrastructures;
using Microsoft.AspNet.OData;
using Microsoft.AspNet.OData.Routing;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using ICMSTU.API.Models.Entities;

namespace ICMSTU.API.Controllers.OdataControllers
{
  [ODataRoutePrefix(nameof(SBDANAR))]
  public class SBDANARController : ODataController
  {
    private readonly DataContext _ctx;

    public SBDANARController(DataContext ctx)
    {
      _ctx = ctx;
    }

    [EnableQuery]
    public IActionResult GetSBDANAR() => Ok(_ctx.SBDANAR.AsQueryable());
  }
}