using ICMSTU.API.Infrastructures;
using Microsoft.AspNet.OData;
using Microsoft.AspNet.OData.Routing;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using ICMSTU.API.Models.Entities;

namespace ICMSTU.API.Controllers.OdataControllers
{
  [ODataRoutePrefix(nameof(JTRANSFER))]
  public class JTRANSFERController : ODataController
  {
    private readonly DataContext _ctx;

    public JTRANSFERController(DataContext ctx)
    {
      _ctx = ctx;
    }

    [EnableQuery]
    public IActionResult GetJTRANSFER() => Ok(_ctx.JTRANSFER.AsQueryable());
  }
}
