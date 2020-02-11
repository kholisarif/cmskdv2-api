using ICMSTU.API.Infrastructures;
using Microsoft.AspNet.OData;
using Microsoft.AspNet.OData.Routing;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using ICMSTU.API.Models.Entities;

namespace ICMSTU.API.Controllers.OdataControllers
{
  [ODataRoutePrefix(nameof(MPGRM))]
  public class MPGRMController : ODataController
  {
    private readonly DataContext _ctx;

    public MPGRMController(DataContext ctx)
    {
      _ctx = ctx;
    }

    [EnableQuery]
    public IActionResult GetMPGRM() => Ok(_ctx.MPGRM.AsQueryable());
  }
}
