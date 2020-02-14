using AutoMapper;
using ICMSTU.API.Exceptions;
using ICMSTU.API.Infrastructures;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace ICMSTU.API.Commands.JTRANSFER
{
  public class JTRANSFERCommandHandlers :
    IRequestHandler<JTRANSFERCreate, Models.Entities.JTRANSFER>,
    IRequestHandler<JTRANSFERUpdate, Models.Entities.JTRANSFER>,
    IRequestHandler<JTRANSFERDelete>, IRequestHandler<JTRANSFERBulkDelete>
  {
    private readonly DataContext _ctx;
    private readonly IMapper _mapper;

    public JTRANSFERCommandHandlers(DataContext ctx, IMapper mapper)
    {
      _ctx = ctx;
      _mapper = mapper;
    }
    public async Task<Models.Entities.JTRANSFER> Handle(JTRANSFERCreate request, CancellationToken cancellationToken)
    {
      var model = _mapper.Map<Models.Entities.JTRANSFER>(request);

      await _ctx.AddAsync(model, cancellationToken);

      await _ctx.SaveChangesAsync(cancellationToken);

      return model;
    }

    public async Task<Models.Entities.JTRANSFER> Handle(JTRANSFERUpdate request, CancellationToken cancellationToken)
    {
      var model = await _ctx.JTRANSFER.SingleOrDefaultAsync(g => g.Id == request.Id, cancellationToken);

      if (model == null) throw new NoRecordException();

      _mapper.Map(request, model);

      await _ctx.SaveChangesAsync(cancellationToken);

      return model;
    }

    public async Task<Unit> Handle(JTRANSFERDelete request, CancellationToken cancellationToken)
    {
      var model = _ctx.JTRANSFER.SingleOrDefaultAsync(g => g.Id == request.Id, cancellationToken);

      if (model == null) throw new NoRecordException();

      await _ctx.SaveChangesAsync(cancellationToken);

      return Unit.Value;
    }


    public async Task<Unit> Handle(JTRANSFERBulkDelete request, CancellationToken cancellationToken)
    {
      var models = await _ctx.JTRANSFER
        .Where(g => request.Ids.Any(id => g.Id == id))
        .ToListAsync(cancellationToken);

      _ctx.RemoveRange(models);

      await _ctx.SaveChangesAsync(cancellationToken);

      return Unit.Value;
    }
  }
}