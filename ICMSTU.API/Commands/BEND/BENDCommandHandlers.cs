using AutoMapper;
using ICMSTU.API.Exceptions;
using ICMSTU.API.Infrastructures;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace ICMSTU.API.Commands.BEND
{
  public class BENDCommandHandlers :
    IRequestHandler<BENDCreate, Models.Entities.BEND>,
    IRequestHandler<BENDUpdate, Models.Entities.BEND>,
    IRequestHandler<BENDDelete>, IRequestHandler<BENDBulkDelete>
  {
    private readonly DataContext _ctx;
    private readonly IMapper _mapper;

    public BENDCommandHandlers(DataContext ctx, IMapper mapper)
    {
      _ctx = ctx;
      _mapper = mapper;
    }
    public async Task<Models.Entities.BEND> Handle(BENDCreate request, CancellationToken cancellationToken)
    {
      var model = _mapper.Map<Models.Entities.BEND>(request);

      await _ctx.AddAsync(model, cancellationToken);

      await _ctx.SaveChangesAsync(cancellationToken);

      return model;
    }

    public async Task<Models.Entities.BEND> Handle(BENDUpdate request, CancellationToken cancellationToken)
    {
      var model = await _ctx.BEND.SingleOrDefaultAsync(g => g.Id == request.Id, cancellationToken);

      if (model == null) throw new NoRecordException();

      _mapper.Map(request, model);

      await _ctx.SaveChangesAsync(cancellationToken);

      return model;
    }

    public async Task<Unit> Handle(BENDDelete request, CancellationToken cancellationToken)
    {
      var model = _ctx.BEND.SingleOrDefaultAsync(g => g.Id == request.Id, cancellationToken);

      if (model == null) throw new NoRecordException();

      await _ctx.SaveChangesAsync(cancellationToken);

      return Unit.Value;
    }


    public async Task<Unit> Handle(BENDBulkDelete request, CancellationToken cancellationToken)
    {
      var models = await _ctx.BEND
        .Where(g => request.Ids.Any(id => g.Id == id))
        .ToListAsync(cancellationToken);

      _ctx.RemoveRange(models);

      await _ctx.SaveChangesAsync(cancellationToken);

      return Unit.Value;
    }
  }
}