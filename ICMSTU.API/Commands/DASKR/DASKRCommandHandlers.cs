using AutoMapper;
using ICMSTU.API.Exceptions;
using ICMSTU.API.Infrastructures;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace ICMSTU.API.Commands.DASKR
{
  public class DASKRCommandHandlers :
    IRequestHandler<DASKRCreate, Models.Entities.DASKR>,
    IRequestHandler<DASKRUpdate, Models.Entities.DASKR>,
    IRequestHandler<DASKRDelete>, IRequestHandler<DASKRBulkDelete>
  {
    private readonly DataContext _ctx;
    private readonly IMapper _mapper;

    public DASKRCommandHandlers(DataContext ctx, IMapper mapper)
    {
      _ctx = ctx;
      _mapper = mapper;
    }
    public async Task<Models.Entities.DASKR> Handle(DASKRCreate request, CancellationToken cancellationToken)
    {
      var model = _mapper.Map<Models.Entities.DASKR>(request);

      await _ctx.AddAsync(model, cancellationToken);

      await _ctx.SaveChangesAsync(cancellationToken);

      return model;
    }

    public async Task<Models.Entities.DASKR> Handle(DASKRUpdate request, CancellationToken cancellationToken)
    {
      var model = await _ctx.DASKR.SingleOrDefaultAsync(g => g.Id == request.Id, cancellationToken);

      if (model == null) throw new NoRecordException();

      _mapper.Map(request, model);

      await _ctx.SaveChangesAsync(cancellationToken);

      return model;
    }

    public async Task<Unit> Handle(DASKRDelete request, CancellationToken cancellationToken)
    {
      var model = _ctx.DASKR.SingleOrDefaultAsync(g => g.Id == request.Id, cancellationToken);

      if (model == null) throw new NoRecordException();

      await _ctx.SaveChangesAsync(cancellationToken);

      return Unit.Value;
    }


    public async Task<Unit> Handle(DASKRBulkDelete request, CancellationToken cancellationToken)
    {
      var models = await _ctx.DASKR
        .Where(g => request.Ids.Any(id => g.Id == id))
        .ToListAsync(cancellationToken);

      _ctx.RemoveRange(models);

      await _ctx.SaveChangesAsync(cancellationToken);

      return Unit.Value;
    }
  }
}