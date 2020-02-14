using AutoMapper;
using ICMSTU.API.Exceptions;
using ICMSTU.API.Infrastructures;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace ICMSTU.API.Commands.STATTRS
{
  public class STATTRSCommandHandlers :
    IRequestHandler<STATTRSCreate, Models.Entities.STATTRS>,
    IRequestHandler<STATTRSUpdate, Models.Entities.STATTRS>,
    IRequestHandler<STATTRSDelete>, IRequestHandler<STATTRSBulkDelete>
  {
    private readonly DataContext _ctx;
    private readonly IMapper _mapper;

    public STATTRSCommandHandlers(DataContext ctx, IMapper mapper)
    {
      _ctx = ctx;
      _mapper = mapper;
    }
    public async Task<Models.Entities.STATTRS> Handle(STATTRSCreate request, CancellationToken cancellationToken)
    {
      var model = _mapper.Map<Models.Entities.STATTRS>(request);

      await _ctx.AddAsync(model, cancellationToken);

      await _ctx.SaveChangesAsync(cancellationToken);

      return model;
    }

    public async Task<Models.Entities.STATTRS> Handle(STATTRSUpdate request, CancellationToken cancellationToken)
    {
      var model = await _ctx.STATTRS.SingleOrDefaultAsync(g => g.Id == request.Id, cancellationToken);

      if (model == null) throw new NoRecordException();

      _mapper.Map(request, model);

      await _ctx.SaveChangesAsync(cancellationToken);

      return model;
    }

    public async Task<Unit> Handle(STATTRSDelete request, CancellationToken cancellationToken)
    {
      var model = _ctx.STATTRS.SingleOrDefaultAsync(g => g.Id == request.Id, cancellationToken);

      if (model == null) throw new NoRecordException();

      await _ctx.SaveChangesAsync(cancellationToken);

      return Unit.Value;
    }


    public async Task<Unit> Handle(STATTRSBulkDelete request, CancellationToken cancellationToken)
    {
      var models = await _ctx.STATTRS
        .Where(g => request.Ids.Any(id => g.Id == id))
        .ToListAsync(cancellationToken);

      _ctx.RemoveRange(models);

      await _ctx.SaveChangesAsync(cancellationToken);

      return Unit.Value;
    }
  }
}