using AutoMapper;
using ICMSTU.API.Exceptions;
using ICMSTU.API.Infrastructures;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace ICMSTU.API.Commands.MPGRM
{
  public class MPGRMCommandHandlers :
    IRequestHandler<MPGRMCreate, Models.Entities.MPGRM>,
    IRequestHandler<MPGRMUpdate, Models.Entities.MPGRM>,
    IRequestHandler<MPGRMDelete>, IRequestHandler<MPGRMBulkDelete>
  {
    private readonly DataContext _ctx;
    private readonly IMapper _mapper;

    public MPGRMCommandHandlers(DataContext ctx, IMapper mapper)
    {
      _ctx = ctx;
      _mapper = mapper;
    }
    public async Task<Models.Entities.MPGRM> Handle(MPGRMCreate request, CancellationToken cancellationToken)
    {
      var model = _mapper.Map<Models.Entities.MPGRM>(request);

      await _ctx.AddAsync(model, cancellationToken);

      await _ctx.SaveChangesAsync(cancellationToken);

      return model;
    }

    public async Task<Models.Entities.MPGRM> Handle(MPGRMUpdate request, CancellationToken cancellationToken)
    {
      var model = await _ctx.MPGRM.SingleOrDefaultAsync(g => g.Id == request.Id, cancellationToken);

      if (model == null) throw new NoRecordException();

      _mapper.Map(request, model);

      await _ctx.SaveChangesAsync(cancellationToken);

      return model;
    }

    public async Task<Unit> Handle(MPGRMDelete request, CancellationToken cancellationToken)
    {
      var model = _ctx.MPGRM.SingleOrDefaultAsync(g => g.Id == request.Id, cancellationToken);

      if (model == null) throw new NoRecordException();

      await _ctx.SaveChangesAsync(cancellationToken);

      return Unit.Value;
    }


    public async Task<Unit> Handle(MPGRMBulkDelete request, CancellationToken cancellationToken)
    {
      var models = await _ctx.MPGRM
        .Where(g => request.Ids.Any(id => g.Id == id))
        .ToListAsync(cancellationToken);

      _ctx.RemoveRange(models);

      await _ctx.SaveChangesAsync(cancellationToken);

      return Unit.Value;
    }
  }
}