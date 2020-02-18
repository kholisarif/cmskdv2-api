using ICMSTU.API.Infrastructures;
using Microsoft.AspNet.OData;
using Microsoft.AspNet.OData.Routing;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using ICMSTU.API.Models.Entities;

namespace ICMSTU.API.Controllers.OdataControllers
{
  [ODataRoutePrefix(nameof(JCAIR))]
  public class JCAIRController : ODataController
  {
    private readonly DataContext _ctx;

    public JCAIRController(DataContext ctx)
    {
      _ctx = ctx;
    }

    [EnableQuery]
    public IActionResult GetJCAIR() => Ok(_ctx.JCAIR.AsQueryable());
  }
}
