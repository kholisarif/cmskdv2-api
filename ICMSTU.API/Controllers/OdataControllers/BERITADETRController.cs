using ICMSTU.API.Infrastructures;
using Microsoft.AspNet.OData;
using Microsoft.AspNet.OData.Routing;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using ICMSTU.API.Models.Entities;

namespace ICMSTU.API.Controllers.OdataControllers
{
  [ODataRoutePrefix(nameof(BERITADETR))]
  public class BERITADETRController : ODataController
  {
    private readonly DataContext _ctx;

    public BERITADETRController(DataContext ctx)
    {
      _ctx = ctx;
    }

    [EnableQuery]
    public IActionResult GetBERITADETR() => Ok(_ctx.BERITADETR.AsQueryable());
  }
}
