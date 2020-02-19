using AutoMapper;
using ICMSTU.API.Exceptions;
using ICMSTU.API.Infrastructures;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace ICMSTU.API.Commands.SP2D
{
  public class SP2DCommandHandlers :
    IRequestHandler<SP2DCreate, Models.Entities.SP2D>,
    IRequestHandler<SP2DUpdate, Models.Entities.SP2D>,
    IRequestHandler<SP2DDelete>, IRequestHandler<SP2DBulkDelete>
  {
    private readonly DataContext _ctx;
    private readonly IMapper _mapper;

    public SP2DCommandHandlers(DataContext ctx, IMapper mapper)
    {
      _ctx = ctx;
      _mapper = mapper;
    }
    public async Task<Models.Entities.SP2D> Handle(SP2DCreate request, CancellationToken cancellationToken)
    {
      var model = _mapper.Map<Models.Entities.SP2D>(request);

      await _ctx.AddAsync(model, cancellationToken);

      await _ctx.SaveChangesAsync(cancellationToken);

      return model;
    }

    public async Task<Models.Entities.SP2D> Handle(SP2DUpdate request, CancellationToken cancellationToken)
    {
      var model = await _ctx.SP2D.SingleOrDefaultAsync(g => g.Id == request.Id, cancellationToken);

      if (model == null) throw new NoRecordException();

      _mapper.Map(request, model);

      await _ctx.SaveChangesAsync(cancellationToken);

      return model;
    }

    public async Task<Unit> Handle(SP2DDelete request, CancellationToken cancellationToken)
    {
      var model = _ctx.SP2D.SingleOrDefaultAsync(g => g.Id == request.Id, cancellationToken);

      if (model == null) throw new NoRecordException();

      await _ctx.SaveChangesAsync(cancellationToken);

      return Unit.Value;
    }


    public async Task<Unit> Handle(SP2DBulkDelete request, CancellationToken cancellationToken)
    {
      var models = await _ctx.SP2D
        .Where(g => request.Ids.Any(id => g.Id == id))
        .ToListAsync(cancellationToken);

      _ctx.RemoveRange(models);

      await _ctx.SaveChangesAsync(cancellationToken);

      return Unit.Value;
    }
  }
}