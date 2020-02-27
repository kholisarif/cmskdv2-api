using AutoMapper;
using ICMSTU.API.Exceptions;
using ICMSTU.API.Infrastructures;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace ICMSTU.API.Commands.NPDTBPL
{
  public class NPDTBPLCommandHandlers :
    IRequestHandler<NPDTBPLCreate, Models.Entities.NPDTBPL>,
    IRequestHandler<NPDTBPLUpdate, Models.Entities.NPDTBPL>,
    IRequestHandler<NPDTBPLDelete>, IRequestHandler<NPDTBPLBulkDelete>
  {
    private readonly DataContext _ctx;
    private readonly IMapper _mapper;

    public NPDTBPLCommandHandlers(DataContext ctx, IMapper mapper)
    {
      _ctx = ctx;
      _mapper = mapper;
    }
    public async Task<Models.Entities.NPDTBPL> Handle(NPDTBPLCreate request, CancellationToken cancellationToken)
    {
      var model = _mapper.Map<Models.Entities.NPDTBPL>(request);

      await _ctx.AddAsync(model, cancellationToken);

      await _ctx.SaveChangesAsync(cancellationToken);

      return model;
    }

    public async Task<Models.Entities.NPDTBPL> Handle(NPDTBPLUpdate request, CancellationToken cancellationToken)
    {
      var model = await _ctx.NPDTBPL.SingleOrDefaultAsync(g => g.Id == request.Id, cancellationToken);

      if (model == null) throw new NoRecordException();

      _mapper.Map(request, model);

      await _ctx.SaveChangesAsync(cancellationToken);

      return model;
    }

    public async Task<Unit> Handle(NPDTBPLDelete request, CancellationToken cancellationToken)
    {
      var model = _ctx.NPDTBPL.SingleOrDefaultAsync(g => g.Id == request.Id, cancellationToken);

      if (model == null) throw new NoRecordException();

      await _ctx.SaveChangesAsync(cancellationToken);

      return Unit.Value;
    }


    public async Task<Unit> Handle(NPDTBPLBulkDelete request, CancellationToken cancellationToken)
    {
      var models = await _ctx.NPDTBPL
        .Where(g => request.Ids.Any(id => g.Id == id))
        .ToListAsync(cancellationToken);

      _ctx.RemoveRange(models);

      await _ctx.SaveChangesAsync(cancellationToken);

      return Unit.Value;
    }
  }
}