using AutoMapper;
using ICMSTU.API.Exceptions;
using ICMSTU.API.Infrastructures;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace ICMSTU.API.Commands.BERITADETR
{
  public class BERITADETRCommandHandlers :
    IRequestHandler<BERITADETRCreate, Models.Entities.BERITADETR>,
    IRequestHandler<BERITADETRUpdate, Models.Entities.BERITADETR>,
    IRequestHandler<BERITADETRDelete>, IRequestHandler<BERITADETRBulkDelete>
  {
    private readonly DataContext _ctx;
    private readonly IMapper _mapper;

    public BERITADETRCommandHandlers(DataContext ctx, IMapper mapper)
    {
      _ctx = ctx;
      _mapper = mapper;
    }
    public async Task<Models.Entities.BERITADETR> Handle(BERITADETRCreate request, CancellationToken cancellationToken)
    {
      var model = _mapper.Map<Models.Entities.BERITADETR>(request);

      await _ctx.AddAsync(model, cancellationToken);

      await _ctx.SaveChangesAsync(cancellationToken);

      return model;
    }

    public async Task<Models.Entities.BERITADETR> Handle(BERITADETRUpdate request, CancellationToken cancellationToken)
    {
      var model = await _ctx.BERITADETR.SingleOrDefaultAsync(g => g.Id == request.Id, cancellationToken);

      if (model == null) throw new NoRecordException();

      _mapper.Map(request, model);

      await _ctx.SaveChangesAsync(cancellationToken);

      return model;
    }

    public async Task<Unit> Handle(BERITADETRDelete request, CancellationToken cancellationToken)
    {
      var model = _ctx.BERITADETR.SingleOrDefaultAsync(g => g.Id == request.Id, cancellationToken);

      if (model == null) throw new NoRecordException();

      await _ctx.SaveChangesAsync(cancellationToken);

      return Unit.Value;
    }


    public async Task<Unit> Handle(BERITADETRBulkDelete request, CancellationToken cancellationToken)
    {
      var models = await _ctx.BERITADETR
        .Where(g => request.Ids.Any(id => g.Id == id))
        .ToListAsync(cancellationToken);

      _ctx.RemoveRange(models);

      await _ctx.SaveChangesAsync(cancellationToken);

      return Unit.Value;
    }
  }
}