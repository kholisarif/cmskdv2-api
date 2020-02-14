using ICMSTU.API.Infrastructures;
using Microsoft.AspNet.OData;
using Microsoft.AspNet.OData.Routing;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using ICMSTU.API.Models.Entities;

namespace ICMSTU.API.Controllers.OdataControllers
{
  [ODataRoutePrefix(nameof(JBAYAR))]
  public class JBAYARController : ODataController
  {
    private readonly DataContext _ctx;

    public JBAYARController(DataContext ctx)
    {
      _ctx = ctx;
    }

    [EnableQuery]
    public IActionResult GetJBAYAR() => Ok(_ctx.JBAYAR.AsQueryable());
  }
}
