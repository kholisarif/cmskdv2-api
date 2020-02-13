using AutoMapper;
using ICMSTU.API.Exceptions;
using ICMSTU.API.Infrastructures;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace ICMSTU.API.Commands.MATANGR
{
  public class MATANGRCommandHandlers :
    IRequestHandler<MATANGRCreate, Models.Entities.MATANGR>,
    IRequestHandler<MATANGRUpdate, Models.Entities.MATANGR>,
    IRequestHandler<MATANGRDelete>, IRequestHandler<MATANGRBulkDelete>
  {
    private readonly DataContext _ctx;
    private readonly IMapper _mapper;

    public MATANGRCommandHandlers(DataContext ctx, IMapper mapper)
    {
      _ctx = ctx;
      _mapper = mapper;
    }
    public async Task<Models.Entities.MATANGR> Handle(MATANGRCreate request, CancellationToken cancellationToken)
    {
      var model = _mapper.Map<Models.Entities.MATANGR>(request);

      await _ctx.AddAsync(model, cancellationToken);

      await _ctx.SaveChangesAsync(cancellationToken);

      return model;
    }

    public async Task<Models.Entities.MATANGR> Handle(MATANGRUpdate request, CancellationToken cancellationToken)
    {
      var model = await _ctx.MATANGR.SingleOrDefaultAsync(g => g.Id == request.Id, cancellationToken);

      if (model == null) throw new NoRecordException();

      _mapper.Map(request, model);

      await _ctx.SaveChangesAsync(cancellationToken);

      return model;
    }

    public async Task<Unit> Handle(MATANGRDelete request, CancellationToken cancellationToken)
    {
      var model = _ctx.MATANGR.SingleOrDefaultAsync(g => g.Id == request.Id, cancellationToken);

      if (model == null) throw new NoRecordException();

      await _ctx.SaveChangesAsync(cancellationToken);

      return Unit.Value;
    }


    public async Task<Unit> Handle(MATANGRBulkDelete request, CancellationToken cancellationToken)
    {
      var models = await _ctx.MATANGR
        .Where(g => request.Ids.Any(id => g.Id == id))
        .ToListAsync(cancellationToken);

      _ctx.RemoveRange(models);

      await _ctx.SaveChangesAsync(cancellationToken);

      return Unit.Value;
    }
  }
}