using ICMSTU.API.Infrastructures;
using Microsoft.AspNet.OData;
using Microsoft.AspNet.OData.Routing;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using ICMSTU.API.Models.Entities;

namespace ICMSTU.API.Controllers.OdataControllers
{
  [ODataRoutePrefix(nameof(KEGUNIT))]
  public class KEGUNITController : ODataController
  {
    private readonly DataContext _ctx;

    public KEGUNITController(DataContext ctx)
    {
      _ctx = ctx;
    }

    [EnableQuery]
    public IActionResult GetKEGUNIT() => Ok(_ctx.KEGUNIT.AsQueryable());
  }
}
