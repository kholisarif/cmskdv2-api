using AutoMapper;
using ICMSTU.API.Exceptions;
using ICMSTU.API.Infrastructures;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace ICMSTU.API.Commands.NPD
{
  public class NPDCommandHandlers :
    IRequestHandler<NPDCreate, Models.Entities.NPD>,
    IRequestHandler<NPDUpdate, Models.Entities.NPD>,
    IRequestHandler<NPDDelete>, IRequestHandler<NPDBulkDelete>
  {
    private readonly DataContext _ctx;
    private readonly IMapper _mapper;

    public NPDCommandHandlers(DataContext ctx, IMapper mapper)
    {
      _ctx = ctx;
      _mapper = mapper;
    }
    public async Task<Models.Entities.NPD> Handle(NPDCreate request, CancellationToken cancellationToken)
    {
      var model = _mapper.Map<Models.Entities.NPD>(request);

      await _ctx.AddAsync(model, cancellationToken);

      await _ctx.SaveChangesAsync(cancellationToken);

      return model;
    }

    public async Task<Models.Entities.NPD> Handle(NPDUpdate request, CancellationToken cancellationToken)
    {
      var model = await _ctx.NPD.SingleOrDefaultAsync(g => g.Id == request.Id, cancellationToken);

      if (model == null) throw new NoRecordException();

      _mapper.Map(request, model);

      await _ctx.SaveChangesAsync(cancellationToken);

      return model;
    }

    public async Task<Unit> Handle(NPDDelete request, CancellationToken cancellationToken)
    {
      var model = _ctx.NPD.SingleOrDefaultAsync(g => g.Id == request.Id, cancellationToken);

      if (model == null) throw new NoRecordException();

      await _ctx.SaveChangesAsync(cancellationToken);

      return Unit.Value;
    }


    public async Task<Unit> Handle(NPDBulkDelete request, CancellationToken cancellationToken)
    {
      var models = await _ctx.NPD
        .Where(g => request.Ids.Any(id => g.Id == id))
        .ToListAsync(cancellationToken);

      _ctx.RemoveRange(models);

      await _ctx.SaveChangesAsync(cancellationToken);

      return Unit.Value;
    }
  }
}