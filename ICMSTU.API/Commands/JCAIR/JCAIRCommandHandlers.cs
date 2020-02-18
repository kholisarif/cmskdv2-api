using AutoMapper;
using ICMSTU.API.Exceptions;
using ICMSTU.API.Infrastructures;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace ICMSTU.API.Commands.JCAIR
{
  public class JCAIRCommandHandlers :
    IRequestHandler<JCAIRCreate, Models.Entities.JCAIR>,
    IRequestHandler<JCAIRUpdate, Models.Entities.JCAIR>,
    IRequestHandler<JCAIRDelete>, IRequestHandler<JCAIRBulkDelete>
  {
    private readonly DataContext _ctx;
    private readonly IMapper _mapper;

    public JCAIRCommandHandlers(DataContext ctx, IMapper mapper)
    {
      _ctx = ctx;
      _mapper = mapper;
    }
    public async Task<Models.Entities.JCAIR> Handle(JCAIRCreate request, CancellationToken cancellationToken)
    {
      var model = _mapper.Map<Models.Entities.JCAIR>(request);

      await _ctx.AddAsync(model, cancellationToken);

      await _ctx.SaveChangesAsync(cancellationToken);

      return model;
    }

    public async Task<Models.Entities.JCAIR> Handle(JCAIRUpdate request, CancellationToken cancellationToken)
    {
      var model = await _ctx.JCAIR.SingleOrDefaultAsync(g => g.Id == request.Id, cancellationToken);

      if (model == null) throw new NoRecordException();

      _mapper.Map(request, model);

      await _ctx.SaveChangesAsync(cancellationToken);

      return model;
    }

    public async Task<Unit> Handle(JCAIRDelete request, CancellationToken cancellationToken)
    {
      var model = _ctx.JCAIR.SingleOrDefaultAsync(g => g.Id == request.Id, cancellationToken);

      if (model == null) throw new NoRecordException();

      await _ctx.SaveChangesAsync(cancellationToken);

      return Unit.Value;
    }


    public async Task<Unit> Handle(JCAIRBulkDelete request, CancellationToken cancellationToken)
    {
      var models = await _ctx.JCAIR
        .Where(g => request.Ids.Any(id => g.Id == id))
        .ToListAsync(cancellationToken);

      _ctx.RemoveRange(models);

      await _ctx.SaveChangesAsync(cancellationToken);

      return Unit.Value;
    }
  }
}