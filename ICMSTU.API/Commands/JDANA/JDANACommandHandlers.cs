using AutoMapper;
using ICMSTU.API.Exceptions;
using ICMSTU.API.Infrastructures;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace ICMSTU.API.Commands.JDANA
{
  public class JDANACommandHandlers :
    IRequestHandler<JDANACreate, Models.Entities.JDANA>,
    IRequestHandler<JDANAUpdate, Models.Entities.JDANA>,
    IRequestHandler<JDANADelete>, IRequestHandler<JDANABulkDelete>
  {
    private readonly DataContext _ctx;
    private readonly IMapper _mapper;

    public JDANACommandHandlers(DataContext ctx, IMapper mapper)
    {
      _ctx = ctx;
      _mapper = mapper;
    }
    public async Task<Models.Entities.JDANA> Handle(JDANACreate request, CancellationToken cancellationToken)
    {
      var model = _mapper.Map<Models.Entities.JDANA>(request);

      await _ctx.AddAsync(model, cancellationToken);

      await _ctx.SaveChangesAsync(cancellationToken);

      return model;
    }

    public async Task<Models.Entities.JDANA> Handle(JDANAUpdate request, CancellationToken cancellationToken)
    {
      var model = await _ctx.JDANA.SingleOrDefaultAsync(g => g.Id == request.Id, cancellationToken);

      if (model == null) throw new NoRecordException();

      _mapper.Map(request, model);

      await _ctx.SaveChangesAsync(cancellationToken);

      return model;
    }

    public async Task<Unit> Handle(JDANADelete request, CancellationToken cancellationToken)
    {
      var model = _ctx.JDANA.SingleOrDefaultAsync(g => g.Id == request.Id, cancellationToken);

      if (model == null) throw new NoRecordException();

      await _ctx.SaveChangesAsync(cancellationToken);

      return Unit.Value;
    }


    public async Task<Unit> Handle(JDANABulkDelete request, CancellationToken cancellationToken)
    {
      var models = await _ctx.JDANA
        .Where(g => request.Ids.Any(id => g.Id == id))
        .ToListAsync(cancellationToken);

      _ctx.RemoveRange(models);

      await _ctx.SaveChangesAsync(cancellationToken);

      return Unit.Value;
    }
  }
}