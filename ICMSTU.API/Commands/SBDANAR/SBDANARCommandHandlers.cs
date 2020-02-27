using AutoMapper;
using ICMSTU.API.Exceptions;
using ICMSTU.API.Infrastructures;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace ICMSTU.API.Commands.SBDANAR
{
  public class SBDANARCommandHandlers :
    IRequestHandler<SBDANARCreate, Models.Entities.SBDANAR>,
    IRequestHandler<SBDANARUpdate, Models.Entities.SBDANAR>,
    IRequestHandler<SBDANARDelete>, IRequestHandler<SBDANARBulkDelete>
  {
    private readonly DataContext _ctx;
    private readonly IMapper _mapper;

    public SBDANARCommandHandlers(DataContext ctx, IMapper mapper)
    {
      _ctx = ctx;
      _mapper = mapper;
    }
    public async Task<Models.Entities.SBDANAR> Handle(SBDANARCreate request, CancellationToken cancellationToken)
    {
      var model = _mapper.Map<Models.Entities.SBDANAR>(request);

      await _ctx.AddAsync(model, cancellationToken);

      await _ctx.SaveChangesAsync(cancellationToken);

      return model;
    }

    public async Task<Models.Entities.SBDANAR> Handle(SBDANARUpdate request, CancellationToken cancellationToken)
    {
      var model = await _ctx.SBDANAR.SingleOrDefaultAsync(g => g.Id == request.Id, cancellationToken);

      if (model == null) throw new NoRecordException();

      _mapper.Map(request, model);

      await _ctx.SaveChangesAsync(cancellationToken);

      return model;
    }

    public async Task<Unit> Handle(SBDANARDelete request, CancellationToken cancellationToken)
    {
      var model = _ctx.SBDANAR.SingleOrDefaultAsync(g => g.Id == request.Id, cancellationToken);

      if (model == null) throw new NoRecordException();

      await _ctx.SaveChangesAsync(cancellationToken);

      return Unit.Value;
    }


    public async Task<Unit> Handle(SBDANARBulkDelete request, CancellationToken cancellationToken)
    {
      var models = await _ctx.SBDANAR
        .Where(g => request.Ids.Any(id => g.Id == id))
        .ToListAsync(cancellationToken);

      _ctx.RemoveRange(models);

      await _ctx.SaveChangesAsync(cancellationToken);

      return Unit.Value;
    }
  }
}