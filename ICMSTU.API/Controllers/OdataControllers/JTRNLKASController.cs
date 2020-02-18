using ICMSTU.API.Infrastructures;
using Microsoft.AspNet.OData;
using Microsoft.AspNet.OData.Routing;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using ICMSTU.API.Models.Entities;

namespace ICMSTU.API.Controllers.OdataControllers
{
  [ODataRoutePrefix(nameof(JTRNLKAS))]
  public class JTRNLKASController : ODataController
  {
    private readonly DataContext _ctx;

    public JTRNLKASController(DataContext ctx)
    {
      _ctx = ctx;
    }

    [EnableQuery]
    public IActionResult GetJTRNLKAS() => Ok(_ctx.JTRNLKAS.AsQueryable());
  }
}
