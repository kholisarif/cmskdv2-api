using ICMSTU.API.Infrastructures;
using Microsoft.AspNet.OData;
using Microsoft.AspNet.OData.Routing;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using ICMSTU.API.Models.Entities;

namespace ICMSTU.API.Controllers.OdataControllers
{
  [ODataRoutePrefix(nameof(NPDBPK))]
  public class NPDBPKController : ODataController
  {
    private readonly DataContext _ctx;

    public NPDBPKController(DataContext ctx)
    {
      _ctx = ctx;
    }

    [EnableQuery]
    public IActionResult GetNPDBPK() => Ok(_ctx.NPDBPK.AsQueryable());
  }
}
