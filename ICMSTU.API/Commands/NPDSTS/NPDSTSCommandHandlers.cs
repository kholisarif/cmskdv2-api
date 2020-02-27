using AutoMapper;
using ICMSTU.API.Exceptions;
using ICMSTU.API.Infrastructures;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace ICMSTU.API.Commands.NPDSTS
{
  public class NPDSTSCommandHandlers :
    IRequestHandler<NPDSTSCreate, Models.Entities.NPDSTS>,
    IRequestHandler<NPDSTSUpdate, Models.Entities.NPDSTS>,
    IRequestHandler<NPDSTSDelete>, IRequestHandler<NPDSTSBulkDelete>
  {
    private readonly DataContext _ctx;
    private readonly IMapper _mapper;

    public NPDSTSCommandHandlers(DataContext ctx, IMapper mapper)
    {
      _ctx = ctx;
      _mapper = mapper;
    }
    public async Task<Models.Entities.NPDSTS> Handle(NPDSTSCreate request, CancellationToken cancellationToken)
    {
      var model = _mapper.Map<Models.Entities.NPDSTS>(request);

      await _ctx.AddAsync(model, cancellationToken);

      await _ctx.SaveChangesAsync(cancellationToken);

      return model;
    }

    public async Task<Models.Entities.NPDSTS> Handle(NPDSTSUpdate request, CancellationToken cancellationToken)
    {
      var model = await _ctx.NPDSTS.SingleOrDefaultAsync(g => g.Id == request.Id, cancellationToken);

      if (model == null) throw new NoRecordException();

      _mapper.Map(request, model);

      await _ctx.SaveChangesAsync(cancellationToken);

      return model;
    }

    public async Task<Unit> Handle(NPDSTSDelete request, CancellationToken cancellationToken)
    {
      var model = _ctx.NPDSTS.SingleOrDefaultAsync(g => g.Id == request.Id, cancellationToken);

      if (model == null) throw new NoRecordException();

      await _ctx.SaveChangesAsync(cancellationToken);

      return Unit.Value;
    }


    public async Task<Unit> Handle(NPDSTSBulkDelete request, CancellationToken cancellationToken)
    {
      var models = await _ctx.NPDSTS
        .Where(g => request.Ids.Any(id => g.Id == id))
        .ToListAsync(cancellationToken);

      _ctx.RemoveRange(models);

      await _ctx.SaveChangesAsync(cancellationToken);

      return Unit.Value;
    }
  }
}