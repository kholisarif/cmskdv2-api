using ICMSTU.API.Infrastructures;
using Microsoft.AspNet.OData;
using Microsoft.AspNet.OData.Routing;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using ICMSTU.API.Models.Entities;

namespace ICMSTU.API.Controllers.OdataControllers
{
  public class DASKRKEGUNITController : ODataController
  {
    private readonly DataContext _ctx;

    public DASKRKEGUNITController(DataContext ctx)
    {
      _ctx = ctx;
    }

    [HttpGet]
    [ODataRoute("DASKRKEGUNIT({unitKey}, {kdTahap})")]
    [EnableQuery]
    public IActionResult DASKRKEGUNIT(string unitKey,string kdTahap) {
        return Ok(_ctx.DASKRKEGUNIT.AsNoTracking().FromSql("EXEC [dbo].[GETDASKRKEGUNIT] {0}, {1}", unitKey, kdTahap).AsQueryable());
    }
  }
}
