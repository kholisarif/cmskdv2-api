using AutoMapper;
using ICMSTU.API.Exceptions;
using ICMSTU.API.Infrastructures;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace ICMSTU.API.Commands.BPK
{
  public class BPKCommandHandlers :
    IRequestHandler<BPKCreate, Models.Entities.BPK>,
    IRequestHandler<BPKUpdate, Models.Entities.BPK>,
    IRequestHandler<BPKDelete>, IRequestHandler<BPKBulkDelete>
  {
    private readonly DataContext _ctx;
    private readonly IMapper _mapper;

    public BPKCommandHandlers(DataContext ctx, IMapper mapper)
    {
      _ctx = ctx;
      _mapper = mapper;
    }
    public async Task<Models.Entities.BPK> Handle(BPKCreate request, CancellationToken cancellationToken)
    {
      var model = _mapper.Map<Models.Entities.BPK>(request);

      await _ctx.AddAsync(model, cancellationToken);

      await _ctx.SaveChangesAsync(cancellationToken);

      return model;
    }

    public async Task<Models.Entities.BPK> Handle(BPKUpdate request, CancellationToken cancellationToken)
    {
      var model = await _ctx.BPK.SingleOrDefaultAsync(g => g.Id == request.Id, cancellationToken);

      if (model == null) throw new NoRecordException();

      _mapper.Map(request, model);

      await _ctx.SaveChangesAsync(cancellationToken);

      return model;
    }

    public async Task<Unit> Handle(BPKDelete request, CancellationToken cancellationToken)
    {
      var model = _ctx.BPK.SingleOrDefaultAsync(g => g.Id == request.Id, cancellationToken);

      if (model == null) throw new NoRecordException();

      await _ctx.SaveChangesAsync(cancellationToken);

      return Unit.Value;
    }


    public async Task<Unit> Handle(BPKBulkDelete request, CancellationToken cancellationToken)
    {
      var models = await _ctx.BPK
        .Where(g => request.Ids.Any(id => g.Id == id))
        .ToListAsync(cancellationToken);

      _ctx.RemoveRange(models);

      await _ctx.SaveChangesAsync(cancellationToken);

      return Unit.Value;
    }
  }
}