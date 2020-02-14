using AutoMapper;
using ICMSTU.API.Exceptions;
using ICMSTU.API.Infrastructures;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace ICMSTU.API.Commands.Kontrak
{
  public class KontrakCommandHandlers :
    IRequestHandler<KontrakCreate, Models.Entities.Kontrak>,
    IRequestHandler<KontrakUpdate, Models.Entities.Kontrak>,
    IRequestHandler<KontrakDelete>, IRequestHandler<KontrakBulkDelete>
  {
    private readonly DataContext _ctx;
    private readonly IMapper _mapper;

    public KontrakCommandHandlers(DataContext ctx, IMapper mapper)
    {
      _ctx = ctx;
      _mapper = mapper;
    }
    public async Task<Models.Entities.Kontrak> Handle(KontrakCreate request, CancellationToken cancellationToken)
    {
      var model = _mapper.Map<Models.Entities.Kontrak>(request);

      await _ctx.AddAsync(model, cancellationToken);

      await _ctx.SaveChangesAsync(cancellationToken);

      return model;
    }

    public async Task<Models.Entities.Kontrak> Handle(KontrakUpdate request, CancellationToken cancellationToken)
    {
      var model = await _ctx.Kontrak.SingleOrDefaultAsync(g => g.Id == request.Id, cancellationToken);

      if (model == null) throw new NoRecordException();

      _mapper.Map(request, model);

      await _ctx.SaveChangesAsync(cancellationToken);

      return model;
    }

    public async Task<Unit> Handle(KontrakDelete request, CancellationToken cancellationToken)
    {
      var model = _ctx.Kontrak.SingleOrDefaultAsync(g => g.Id == request.Id, cancellationToken);

      if (model == null) throw new NoRecordException();

      await _ctx.SaveChangesAsync(cancellationToken);

      return Unit.Value;
    }


    public async Task<Unit> Handle(KontrakBulkDelete request, CancellationToken cancellationToken)
    {
      var models = await _ctx.Kontrak
        .Where(g => request.Ids.Any(id => g.Id == id))
        .ToListAsync(cancellationToken);

      _ctx.RemoveRange(models);

      await _ctx.SaveChangesAsync(cancellationToken);

      return Unit.Value;
    }
  }
}