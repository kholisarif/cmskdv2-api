using AutoMapper;
using ICMSTU.API.Exceptions;
using ICMSTU.API.Infrastructures;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace ICMSTU.API.Commands.KEGUNIT
{
  public class KEGUNITCommandHandlers :
    IRequestHandler<KEGUNITCreate, Models.Entities.KEGUNIT>,
    IRequestHandler<KEGUNITUpdate, Models.Entities.KEGUNIT>,
    IRequestHandler<KEGUNITDelete>, IRequestHandler<KEGUNITBulkDelete>
  {
    private readonly DataContext _ctx;
    private readonly IMapper _mapper;

    public KEGUNITCommandHandlers(DataContext ctx, IMapper mapper)
    {
      _ctx = ctx;
      _mapper = mapper;
    }
    public async Task<Models.Entities.KEGUNIT> Handle(KEGUNITCreate request, CancellationToken cancellationToken)
    {
      var model = _mapper.Map<Models.Entities.KEGUNIT>(request);

      await _ctx.AddAsync(model, cancellationToken);

      await _ctx.SaveChangesAsync(cancellationToken);

      return model;
    }

    public async Task<Models.Entities.KEGUNIT> Handle(KEGUNITUpdate request, CancellationToken cancellationToken)
    {
      var model = await _ctx.KEGUNIT.SingleOrDefaultAsync(g => g.Id == request.Id, cancellationToken);

      if (model == null) throw new NoRecordException();

      _mapper.Map(request, model);

      await _ctx.SaveChangesAsync(cancellationToken);

      return model;
    }

    public async Task<Unit> Handle(KEGUNITDelete request, CancellationToken cancellationToken)
    {
      var model = _ctx.KEGUNIT.SingleOrDefaultAsync(g => g.Id == request.Id, cancellationToken);

      if (model == null) throw new NoRecordException();

      await _ctx.SaveChangesAsync(cancellationToken);

      return Unit.Value;
    }


    public async Task<Unit> Handle(KEGUNITBulkDelete request, CancellationToken cancellationToken)
    {
      var models = await _ctx.KEGUNIT
        .Where(g => request.Ids.Any(id => g.Id == id))
        .ToListAsync(cancellationToken);

      _ctx.RemoveRange(models);

      await _ctx.SaveChangesAsync(cancellationToken);

      return Unit.Value;
    }
  }
}