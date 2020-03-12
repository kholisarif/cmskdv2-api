using AutoMapper;
using ICMSTU.API.Exceptions;
using ICMSTU.API.Infrastructures;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace ICMSTU.API.Commands.BPKSP2D
{
  public class BPKSP2DCommandHandlers :
    IRequestHandler<BPKSP2DCreate, Models.Entities.BPKSP2D>,
    IRequestHandler<BPKSP2DUpdate, Models.Entities.BPKSP2D>,
    IRequestHandler<BPKSP2DDelete>, IRequestHandler<BPKSP2DBulkDelete>
  {
    private readonly DataContext _ctx;
    private readonly IMapper _mapper;

    public BPKSP2DCommandHandlers(DataContext ctx, IMapper mapper)
    {
      _ctx = ctx;
      _mapper = mapper;
    }
    public async Task<Models.Entities.BPKSP2D> Handle(BPKSP2DCreate request, CancellationToken cancellationToken)
    {
      var model = _mapper.Map<Models.Entities.BPKSP2D>(request);

      await _ctx.AddAsync(model, cancellationToken);

      await _ctx.SaveChangesAsync(cancellationToken);

      return model;
    }

    public async Task<Models.Entities.BPKSP2D> Handle(BPKSP2DUpdate request, CancellationToken cancellationToken)
    {
      var model = await _ctx.BPKSP2D.SingleOrDefaultAsync(g => g.Id == request.Id, cancellationToken);

      if (model == null) throw new NoRecordException();

      _mapper.Map(request, model);

      await _ctx.SaveChangesAsync(cancellationToken);

      return model;
    }

    public async Task<Unit> Handle(BPKSP2DDelete request, CancellationToken cancellationToken)
    {
      var model = _ctx.BPKSP2D.SingleOrDefaultAsync(g => g.Id == request.Id, cancellationToken);

      if (model == null) throw new NoRecordException();

      await _ctx.SaveChangesAsync(cancellationToken);

      return Unit.Value;
    }


    public async Task<Unit> Handle(BPKSP2DBulkDelete request, CancellationToken cancellationToken)
    {
      var models = await _ctx.BPKSP2D
        .Where(g => request.Ids.Any(id => g.Id == id))
        .ToListAsync(cancellationToken);

      _ctx.RemoveRange(models);

      await _ctx.SaveChangesAsync(cancellationToken);

      return Unit.Value;
    }
  }
}