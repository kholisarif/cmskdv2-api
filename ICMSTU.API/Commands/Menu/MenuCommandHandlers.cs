using AutoMapper;
using ICMSTU.API.Exceptions;
using ICMSTU.API.Infrastructures;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Threading;
using System.Threading.Tasks;

namespace ICMSTU.API.Commands.Menu
{
  public class MenuCommandHandlers :
    IRequestHandler<MenuCreateCommand, Models.Entities.Menu>,
    IRequestHandler<MenuUpdateCommand, Models.Entities.Menu>,
    IRequestHandler<MenuDeleteCommand>
  {
    private readonly DataContext _ctx;
    private readonly IMapper _mapper;

    public MenuCommandHandlers(DataContext ctx, IMapper mapper)
    {
      _ctx = ctx;
      _mapper = mapper;
    }
    public async Task<Models.Entities.Menu> Handle(MenuCreateCommand request, CancellationToken cancellationToken)
    {
      var model = _mapper.Map<Models.Entities.Menu>(request);

      await _ctx.AddAsync(model, cancellationToken);

      await _ctx.SaveChangesAsync(cancellationToken);

      return model;
    }

    public async Task<Models.Entities.Menu> Handle(MenuUpdateCommand request, CancellationToken cancellationToken)
    {
      var model = await _ctx.Menu.SingleOrDefaultAsync(m => m.Id == request.Id, cancellationToken);

      if (model == null) throw new NoRecordException();

      _mapper.Map(request, model);

      await _ctx.SaveChangesAsync(cancellationToken);

      return model;
    }

    public async Task<Unit> Handle(MenuDeleteCommand request, CancellationToken cancellationToken)
    {
      var model = await _ctx.Menu.SingleOrDefaultAsync(m => m.Id == request.Id, cancellationToken);

      if (model == null) throw new NoRecordException();

      await _ctx.SaveChangesAsync(cancellationToken);

      return Unit.Value;
    }
  }
}
