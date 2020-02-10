using ICMSTU.API.Infrastructures;
using Microsoft.AspNet.OData;
using Microsoft.AspNet.OData.Routing;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using ICMSTU.API.Models.Entities;

namespace ICMSTU.API.Controllers.OdataControllers
{
  [ODataRoutePrefix(nameof(DAFTPHK))]
  public class DAFTPHKController : ODataController
  {
    private readonly DataContext _ctx;

    public DAFTPHKController(DataContext ctx)
    {
      _ctx = ctx;
    }

    [EnableQuery]
    public IActionResult GetDAFTPHK() => Ok(_ctx.DAFTPHK.AsQueryable());
  }
}
