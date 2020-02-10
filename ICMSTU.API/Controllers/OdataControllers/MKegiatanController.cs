using ICMSTU.API.Infrastructures;
using Microsoft.AspNet.OData;
using Microsoft.AspNet.OData.Routing;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using ICMSTU.API.Models.Entities;

namespace ICMSTU.API.Controllers.OdataControllers
{
  [ODataRoutePrefix(nameof(MKegiatan))]
  public class MKegiatanController : ODataController
  {
    private readonly DataContext _ctx;

    public MKegiatanController(DataContext ctx)
    {
      _ctx = ctx;
    }

    [EnableQuery]
    public IActionResult GetMKegiatan() => Ok(_ctx.MKegiatan.AsQueryable());
  }
}
