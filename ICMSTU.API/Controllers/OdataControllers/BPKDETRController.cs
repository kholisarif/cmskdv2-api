using ICMSTU.API.Infrastructures;
using Microsoft.AspNet.OData;
using Microsoft.AspNet.OData.Routing;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using ICMSTU.API.Models.Entities;

namespace ICMSTU.API.Controllers.OdataControllers
{
  [ODataRoutePrefix(nameof(BPKDETR))]
  public class BPKDETRController : ODataController
  {
    private readonly DataContext _ctx;

    public BPKDETRController(DataContext ctx)
    {
      _ctx = ctx;
    }

    [EnableQuery]
    public IActionResult GetBPKDETR() => Ok(_ctx.BPKDETR.AsQueryable());
  }
}
