using ICMSTU.API.Infrastructures;
using Microsoft.AspNet.OData;
using Microsoft.AspNet.OData.Routing;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using ICMSTU.API.Models.Entities;

namespace ICMSTU.API.Controllers.OdataControllers
{
  [ODataRoutePrefix(nameof(Berita))]
  public class BeritaController : ODataController
  {
    private readonly DataContext _ctx;

    public BeritaController(DataContext ctx)
    {
      _ctx = ctx;
    }

    [EnableQuery]
    public IActionResult GetBerita() => Ok(_ctx.Berita.AsQueryable());
  }
}
