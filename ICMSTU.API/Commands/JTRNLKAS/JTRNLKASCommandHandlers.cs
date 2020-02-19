using AutoMapper;
using ICMSTU.API.Exceptions;
using ICMSTU.API.Infrastructures;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace ICMSTU.API.Commands.JTRNLKAS
{
  public class JTRNLKASCommandHandlers :
    IRequestHandler<JTRNLKASCreate, Models.Entities.JTRNLKAS>,
    IRequestHandler<JTRNLKASUpdate, Models.Entities.JTRNLKAS>,
    IRequestHandler<JTRNLKASDelete>, IRequestHandler<JTRNLKASBulkDelete>
  {
    private readonly DataContext _ctx;
    private readonly IMapper _mapper;

    public JTRNLKASCommandHandlers(DataContext ctx, IMapper mapper)
    {
      _ctx = ctx;
      _mapper = mapper;
    }
    public async Task<Models.Entities.JTRNLKAS> Handle(JTRNLKASCreate request, CancellationToken cancellationToken)
    {
      var model = _mapper.Map<Models.Entities.JTRNLKAS>(request);

      await _ctx.AddAsync(model, cancellationToken);

      await _ctx.SaveChangesAsync(cancellationToken);

      return model;
    }

    public async Task<Models.Entities.JTRNLKAS> Handle(JTRNLKASUpdate request, CancellationToken cancellationToken)
    {
      var model = await _ctx.JTRNLKAS.SingleOrDefaultAsync(g => g.Id == request.Id, cancellationToken);

      if (model == null) throw new NoRecordException();

      _mapper.Map(request, model);

      await _ctx.SaveChangesAsync(cancellationToken);

      return model;
    }

    public async Task<Unit> Handle(JTRNLKASDelete request, CancellationToken cancellationToken)
    {
      var model = _ctx.JTRNLKAS.SingleOrDefaultAsync(g => g.Id == request.Id, cancellationToken);

      if (model == null) throw new NoRecordException();

      await _ctx.SaveChangesAsync(cancellationToken);

      return Unit.Value;
    }


    public async Task<Unit> Handle(JTRNLKASBulkDelete request, CancellationToken cancellationToken)
    {
      var models = await _ctx.JTRNLKAS
        .Where(g => request.Ids.Any(id => g.Id == id))
        .ToListAsync(cancellationToken);

      _ctx.RemoveRange(models);

      await _ctx.SaveChangesAsync(cancellationToken);

      return Unit.Value;
    }
  }
}