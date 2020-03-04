using ICMSTU.API.Infrastructures;
using Microsoft.AspNet.OData;
using Microsoft.AspNet.OData.Routing;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

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
    public IActionResult DASKRKEGUNIT(string unitKey,string kdTahap) {
        // return Ok(_ctx.DASKRKEGUNIT.AsNoTracking().FromSql("EXEC [dbo].[DASKRKEGUNIT] {0}, {1}", unitKey, kdTahap)
        return Ok(_ctx.DASKRKEGUNIT.AsNoTracking().FromSql("EXEC [dbo].[DASKRKEGUNIT] @p0, @p1", parameters: new[] { "4_", "1" })
        );
    }
  }
}
