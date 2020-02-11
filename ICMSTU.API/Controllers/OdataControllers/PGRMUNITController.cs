using ICMSTU.API.Infrastructures;
using Microsoft.AspNet.OData;
using Microsoft.AspNet.OData.Routing;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using ICMSTU.API.Models.Entities;

namespace ICMSTU.API.Controllers.OdataControllers
{
  [ODataRoutePrefix(nameof(PGRMUNIT))]
  public class PGRMUNITController : ODataController
  {
    private readonly DataContext _ctx;

    public PGRMUNITController(DataContext ctx)
    {
      _ctx = ctx;
    }

    [EnableQuery]
    public IActionResult Get() => Ok(_ctx.PGRMUNIT.AsQueryable());
  }
}
