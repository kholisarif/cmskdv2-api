using AutoMapper;
using ICMSTU.API.Exceptions;
using ICMSTU.API.Infrastructures;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace ICMSTU.API.Commands.JKIRIM
{
  public class JKIRIMCommandHandlers :
    IRequestHandler<JKIRIMCreate, Models.Entities.JKIRIM>,
    IRequestHandler<JKIRIMUpdate, Models.Entities.JKIRIM>,
    IRequestHandler<JKIRIMDelete>, IRequestHandler<JKIRIMBulkDelete>
  {
    private readonly DataContext _ctx;
    private readonly IMapper _mapper;

    public JKIRIMCommandHandlers(DataContext ctx, IMapper mapper)
    {
      _ctx = ctx;
      _mapper = mapper;
    }
    public async Task<Models.Entities.JKIRIM> Handle(JKIRIMCreate request, CancellationToken cancellationToken)
    {
      var model = _mapper.Map<Models.Entities.JKIRIM>(request);

      await _ctx.AddAsync(model, cancellationToken);

      await _ctx.SaveChangesAsync(cancellationToken);

      return model;
    }

    public async Task<Models.Entities.JKIRIM> Handle(JKIRIMUpdate request, CancellationToken cancellationToken)
    {
      var model = await _ctx.JKIRIM.SingleOrDefaultAsync(g => g.Id == request.Id, cancellationToken);

      if (model == null) throw new NoRecordException();

      _mapper.Map(request, model);

      await _ctx.SaveChangesAsync(cancellationToken);

      return model;
    }

    public async Task<Unit> Handle(JKIRIMDelete request, CancellationToken cancellationToken)
    {
      var model = _ctx.JKIRIM.SingleOrDefaultAsync(g => g.Id == request.Id, cancellationToken);

      if (model == null) throw new NoRecordException();

      await _ctx.SaveChangesAsync(cancellationToken);

      return Unit.Value;
    }


    public async Task<Unit> Handle(JKIRIMBulkDelete request, CancellationToken cancellationToken)
    {
      var models = await _ctx.JKIRIM
        .Where(g => request.Ids.Any(id => g.Id == id))
        .ToListAsync(cancellationToken);

      _ctx.RemoveRange(models);

      await _ctx.SaveChangesAsync(cancellationToken);

      return Unit.Value;
    }
  }
}