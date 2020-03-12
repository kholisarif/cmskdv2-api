using AutoMapper;
using ICMSTU.API.Exceptions;
using ICMSTU.API.Infrastructures;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace ICMSTU.API.Commands.SP2DBPK
{
  public class SP2DBPKCommandHandlers :
    IRequestHandler<SP2DBPKCreate, Models.Entities.SP2DBPK>,
    IRequestHandler<SP2DBPKUpdate, Models.Entities.SP2DBPK>,
    IRequestHandler<SP2DBPKDelete>, IRequestHandler<SP2DBPKBulkDelete>
  {
    private readonly DataContext _ctx;
    private readonly IMapper _mapper;

    public SP2DBPKCommandHandlers(DataContext ctx, IMapper mapper)
    {
      _ctx = ctx;
      _mapper = mapper;
    }
    public async Task<Models.Entities.SP2DBPK> Handle(SP2DBPKCreate request, CancellationToken cancellationToken)
    {
      var model = _mapper.Map<Models.Entities.SP2DBPK>(request);

      await _ctx.AddAsync(model, cancellationToken);

      await _ctx.SaveChangesAsync(cancellationToken);

      return model;
    }

    public async Task<Models.Entities.SP2DBPK> Handle(SP2DBPKUpdate request, CancellationToken cancellationToken)
    {
      var model = await _ctx.SP2DBPK.SingleOrDefaultAsync(g => g.Id == request.Id, cancellationToken);

      if (model == null) throw new NoRecordException();

      _mapper.Map(request, model);

      await _ctx.SaveChangesAsync(cancellationToken);

      return model;
    }

    public async Task<Unit> Handle(SP2DBPKDelete request, CancellationToken cancellationToken)
    {
      var model = _ctx.SP2DBPK.SingleOrDefaultAsync(g => g.Id == request.Id, cancellationToken);

      if (model == null) throw new NoRecordException();

      await _ctx.SaveChangesAsync(cancellationToken);

      return Unit.Value;
    }


    public async Task<Unit> Handle(SP2DBPKBulkDelete request, CancellationToken cancellationToken)
    {
      var models = await _ctx.SP2DBPK
        .Where(g => request.Ids.Any(id => g.Id == id))
        .ToListAsync(cancellationToken);

      _ctx.RemoveRange(models);

      await _ctx.SaveChangesAsync(cancellationToken);

      return Unit.Value;
    }
  }
}