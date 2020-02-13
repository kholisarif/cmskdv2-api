using ICMSTU.API.Infrastructures;
using Microsoft.AspNet.OData;
using Microsoft.AspNet.OData.Routing;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using ICMSTU.API.Models.Entities;

namespace ICMSTU.API.Controllers.OdataControllers
{
  [ODataRoutePrefix(nameof(MATANGR))]
  public class MATANGRController : ODataController
  {
    private readonly DataContext _ctx;

    public MATANGRController(DataContext ctx)
    {
      _ctx = ctx;
    }

    [EnableQuery]
    public IActionResult GetMATANGR() => Ok(_ctx.MATANGR.AsQueryable());
  }
}
