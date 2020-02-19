using AutoMapper;
using ICMSTU.API.Exceptions;
using ICMSTU.API.Infrastructures;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace ICMSTU.API.Commands.BPKDETRDANA
{
  public class BPKDETRDANACommandHandlers :
    IRequestHandler<BPKDETRDANACreate, Models.Entities.BPKDETRDANA>,
    IRequestHandler<BPKDETRDANAUpdate, Models.Entities.BPKDETRDANA>,
    IRequestHandler<BPKDETRDANADelete>, IRequestHandler<BPKDETRDANABulkDelete>
  {
    private readonly DataContext _ctx;
    private readonly IMapper _mapper;

    public BPKDETRDANACommandHandlers(DataContext ctx, IMapper mapper)
    {
      _ctx = ctx;
      _mapper = mapper;
    }
    public async Task<Models.Entities.BPKDETRDANA> Handle(BPKDETRDANACreate request, CancellationToken cancellationToken)
    {
      var model = _mapper.Map<Models.Entities.BPKDETRDANA>(request);

      await _ctx.AddAsync(model, cancellationToken);

      await _ctx.SaveChangesAsync(cancellationToken);

      return model;
    }

    public async Task<Models.Entities.BPKDETRDANA> Handle(BPKDETRDANAUpdate request, CancellationToken cancellationToken)
    {
      var model = await _ctx.BPKDETRDANA.SingleOrDefaultAsync(g => g.Id == request.Id, cancellationToken);

      if (model == null) throw new NoRecordException();

      _mapper.Map(request, model);

      await _ctx.SaveChangesAsync(cancellationToken);

      return model;
    }

    public async Task<Unit> Handle(BPKDETRDANADelete request, CancellationToken cancellationToken)
    {
      var model = _ctx.BPKDETRDANA.SingleOrDefaultAsync(g => g.Id == request.Id, cancellationToken);

      if (model == null) throw new NoRecordException();

      await _ctx.SaveChangesAsync(cancellationToken);

      return Unit.Value;
    }


    public async Task<Unit> Handle(BPKDETRDANABulkDelete request, CancellationToken cancellationToken)
    {
      var models = await _ctx.BPKDETRDANA
        .Where(g => request.Ids.Any(id => g.Id == id))
        .ToListAsync(cancellationToken);

      _ctx.RemoveRange(models);

      await _ctx.SaveChangesAsync(cancellationToken);

      return Unit.Value;
    }
  }
}