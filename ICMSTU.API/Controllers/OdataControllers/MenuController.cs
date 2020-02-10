using ICMSTU.API.Infrastructures;
using Microsoft.AspNet.OData;
using Microsoft.AspNet.OData.Routing;
using System.Linq;
using ICMSTU.API.Models.Entities;

namespace ICMSTU.API.Controllers.OdataControllers
{
  [ODataRoutePrefix(nameof(Menu))]
  public class MenuController : ODataController
  {
    private readonly DataContext _ctx;

    public MenuController(DataContext ctx)
    {
      _ctx = ctx;
    }

    [EnableQuery]
    public IQueryable GetMenu() => _ctx.Menu.AsQueryable();
  }
}
