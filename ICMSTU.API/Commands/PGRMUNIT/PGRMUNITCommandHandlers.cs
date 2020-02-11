using AutoMapper;
using ICMSTU.API.Exceptions;
using ICMSTU.API.Infrastructures;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace ICMSTU.API.Commands.PGRMUNIT
{
  public class PGRMUNITCommandHandlers :
    IRequestHandler<PGRMUNITCreate, Models.Entities.PGRMUNIT>,
    IRequestHandler<PGRMUNITUpdate, Models.Entities.PGRMUNIT>,
    IRequestHandler<PGRMUNITDelete>, IRequestHandler<PGRMUNITBulkDelete>
  {
    private readonly DataContext _ctx;
    private readonly IMapper _mapper;

    public PGRMUNITCommandHandlers(DataContext ctx, IMapper mapper)
    {
      _ctx = ctx;
      _mapper = mapper;
    }
    public async Task<Models.Entities.PGRMUNIT> Handle(PGRMUNITCreate request, CancellationToken cancellationToken)
    {
      var model = _mapper.Map<Models.Entities.PGRMUNIT>(request);

      await _ctx.AddAsync(model, cancellationToken);

      await _ctx.SaveChangesAsync(cancellationToken);

      return model;
    }

    public async Task<Models.Entities.PGRMUNIT> Handle(PGRMUNITUpdate request, CancellationToken cancellationToken)
    {
      var model = await _ctx.PGRMUNIT.SingleOrDefaultAsync(g => g.Id == request.Id, cancellationToken);

      if (model == null) throw new NoRecordException();

      _mapper.Map(request, model);

      await _ctx.SaveChangesAsync(cancellationToken);

      return model;
    }

    public async Task<Unit> Handle(PGRMUNITDelete request, CancellationToken cancellationToken)
    {
      var model = _ctx.PGRMUNIT.SingleOrDefaultAsync(g => g.Id == request.Id, cancellationToken);

      if (model == null) throw new NoRecordException();

      await _ctx.SaveChangesAsync(cancellationToken);

      return Unit.Value;
    }


    public async Task<Unit> Handle(PGRMUNITBulkDelete request, CancellationToken cancellationToken)
    {
      var models = await _ctx.PGRMUNIT
        .Where(g => request.Ids.Any(id => g.Id == id))
        .ToListAsync(cancellationToken);

      _ctx.RemoveRange(models);

      await _ctx.SaveChangesAsync(cancellationToken);

      return Unit.Value;
    }
  }
}