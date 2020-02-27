using ICMSTU.API.Infrastructures;
using Microsoft.AspNet.OData;
using Microsoft.AspNet.OData.Routing;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using ICMSTU.API.Models.Entities;

namespace ICMSTU.API.Controllers.OdataControllers
{
  [ODataRoutePrefix(nameof(NPDTBPL))]
  public class NPDTBPLController : ODataController
  {
    private readonly DataContext _ctx;

    public NPDTBPLController(DataContext ctx)
    {
      _ctx = ctx;
    }

    [EnableQuery]
    public IActionResult GetNPDTBPL() => Ok(_ctx.NPDTBPL.AsQueryable());
  }
}
