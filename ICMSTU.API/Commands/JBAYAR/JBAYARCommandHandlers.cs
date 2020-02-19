using AutoMapper;
using ICMSTU.API.Exceptions;
using ICMSTU.API.Infrastructures;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace ICMSTU.API.Commands.JBAYAR
{
  public class JBAYARCommandHandlers :
    IRequestHandler<JBAYARCreate, Models.Entities.JBAYAR>,
    IRequestHandler<JBAYARUpdate, Models.Entities.JBAYAR>,
    IRequestHandler<JBAYARDelete>, IRequestHandler<JBAYARBulkDelete>
  {
    private readonly DataContext _ctx;
    private readonly IMapper _mapper;

    public JBAYARCommandHandlers(DataContext ctx, IMapper mapper)
    {
      _ctx = ctx;
      _mapper = mapper;
    }
    public async Task<Models.Entities.JBAYAR> Handle(JBAYARCreate request, CancellationToken cancellationToken)
    {
      var model = _mapper.Map<Models.Entities.JBAYAR>(request);

      await _ctx.AddAsync(model, cancellationToken);

      await _ctx.SaveChangesAsync(cancellationToken);

      return model;
    }

    public async Task<Models.Entities.JBAYAR> Handle(JBAYARUpdate request, CancellationToken cancellationToken)
    {
      var model = await _ctx.JBAYAR.SingleOrDefaultAsync(g => g.Id == request.Id, cancellationToken);

      if (model == null) throw new NoRecordException();

      _mapper.Map(request, model);

      await _ctx.SaveChangesAsync(cancellationToken);

      return model;
    }

    public async Task<Unit> Handle(JBAYARDelete request, CancellationToken cancellationToken)
    {
      var model = _ctx.JBAYAR.SingleOrDefaultAsync(g => g.Id == request.Id, cancellationToken);

      if (model == null) throw new NoRecordException();

      await _ctx.SaveChangesAsync(cancellationToken);

      return Unit.Value;
    }


    public async Task<Unit> Handle(JBAYARBulkDelete request, CancellationToken cancellationToken)
    {
      var models = await _ctx.JBAYAR
        .Where(g => request.Ids.Any(id => g.Id == id))
        .ToListAsync(cancellationToken);

      _ctx.RemoveRange(models);

      await _ctx.SaveChangesAsync(cancellationToken);

      return Unit.Value;
    }
  }
}