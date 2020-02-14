using ICMSTU.API.Infrastructures;
using Microsoft.AspNet.OData;
using Microsoft.AspNet.OData.Routing;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using ICMSTU.API.Models.Entities;

namespace ICMSTU.API.Controllers.OdataControllers
{
  [ODataRoutePrefix(nameof(Kontrak))]
  public class KontrakController : ODataController
  {
    private readonly DataContext _ctx;

    public KontrakController(DataContext ctx)
    {
      _ctx = ctx;
    }

    [EnableQuery]
    public IActionResult GetKontrak() => Ok(_ctx.Kontrak.AsQueryable());
  }
}
