using AutoMapper;
using ICMSTU.API.Exceptions;
using ICMSTU.API.Infrastructures;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace ICMSTU.API.Commands.Golongan
{
  public class GolonganCommandHandlers :
    IRequestHandler<GolonganCreate, Models.Entities.Golongan>,
    IRequestHandler<GolonganUpdate, Models.Entities.Golongan>,
    IRequestHandler<GolonganDelete>, IRequestHandler<GolonganBulkDelete>
  {
    private readonly DataContext _ctx;
    private readonly IMapper _mapper;

    public GolonganCommandHandlers(DataContext ctx, IMapper mapper)
    {
      _ctx = ctx;
      _mapper = mapper;
    }
    public async Task<Models.Entities.Golongan> Handle(GolonganCreate request, CancellationToken cancellationToken)
    {
      var model = _mapper.Map<Models.Entities.Golongan>(request);

      await _ctx.AddAsync(model, cancellationToken);

      await _ctx.SaveChangesAsync(cancellationToken);

      return model;
    }

    public async Task<Models.Entities.Golongan> Handle(GolonganUpdate request, CancellationToken cancellationToken)
    {
      var model = await _ctx.Golongan.SingleOrDefaultAsync(g => g.Id == request.Id, cancellationToken);

      if (model == null) throw new NoRecordException();

      _mapper.Map(request, model);

      await _ctx.SaveChangesAsync(cancellationToken);

      return model;
    }

    public async Task<Unit> Handle(GolonganDelete request, CancellationToken cancellationToken)
    {
      var model = _ctx.Golongan.SingleOrDefaultAsync(g => g.Id == request.Id, cancellationToken);

      if (model == null) throw new NoRecordException();

      await _ctx.SaveChangesAsync(cancellationToken);

      return Unit.Value;
    }


    public async Task<Unit> Handle(GolonganBulkDelete request, CancellationToken cancellationToken)
    {
      var models = await _ctx.Golongan
        .Where(g => request.Ids.Any(id => g.Id == id))
        .ToListAsync(cancellationToken);

      _ctx.RemoveRange(models);

      await _ctx.SaveChangesAsync(cancellationToken);

      return Unit.Value;
    }
  }
}