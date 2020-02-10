using AutoMapper;
using ICMSTU.API.Exceptions;
using ICMSTU.API.Infrastructures;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace ICMSTU.API.Commands.DAFTUNIT
{
  public class DAFTUNITCommandHandlers :
    IRequestHandler<DAFTUNITCreate, Models.Entities.DAFTUNIT>,
    IRequestHandler<DAFTUNITUpdate, Models.Entities.DAFTUNIT>,
    IRequestHandler<DAFTUNITDelete>, IRequestHandler<DAFTUNITBulkDelete>
  {
    private readonly DataContext _ctx;
    private readonly IMapper _mapper;

    public DAFTUNITCommandHandlers(DataContext ctx, IMapper mapper)
    {
      _ctx = ctx;
      _mapper = mapper;
    }
    public async Task<Models.Entities.DAFTUNIT> Handle(DAFTUNITCreate request, CancellationToken cancellationToken)
    {
      var model = _mapper.Map<Models.Entities.DAFTUNIT>(request);

      await _ctx.AddAsync(model, cancellationToken);

      await _ctx.SaveChangesAsync(cancellationToken);

      return model;
    }

    public async Task<Models.Entities.DAFTUNIT> Handle(DAFTUNITUpdate request, CancellationToken cancellationToken)
    {
      var model = await _ctx.DAFTUNIT.SingleOrDefaultAsync(g => g.Id == request.Id, cancellationToken);

      if (model == null) throw new NoRecordException();

      _mapper.Map(request, model);

      await _ctx.SaveChangesAsync(cancellationToken);

      return model;
    }

    public async Task<Unit> Handle(DAFTUNITDelete request, CancellationToken cancellationToken)
    {
      var model = _ctx.DAFTUNIT.SingleOrDefaultAsync(g => g.Id == request.Id, cancellationToken);

      if (model == null) throw new NoRecordException();

      await _ctx.SaveChangesAsync(cancellationToken);

      return Unit.Value;
    }


    public async Task<Unit> Handle(DAFTUNITBulkDelete request, CancellationToken cancellationToken)
    {
      var models = await _ctx.DAFTUNIT
        .Where(g => request.Ids.Any(id => g.Id == id))
        .ToListAsync(cancellationToken);

      _ctx.RemoveRange(models);

      await _ctx.SaveChangesAsync(cancellationToken);

      return Unit.Value;
    }
  }
}