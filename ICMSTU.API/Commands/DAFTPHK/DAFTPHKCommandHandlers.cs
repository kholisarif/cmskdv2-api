using AutoMapper;
using ICMSTU.API.Exceptions;
using ICMSTU.API.Infrastructures;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace ICMSTU.API.Commands.DAFTPHK
{
  public class DAFTPHKCommandHandlers :
    IRequestHandler<DAFTPHKCreate, Models.Entities.DAFTPHK>,
    IRequestHandler<DAFTPHKUpdate, Models.Entities.DAFTPHK>,
    IRequestHandler<DAFTPHKDelete>, IRequestHandler<DAFTPHKBulkDelete>
  {
    private readonly DataContext _ctx;
    private readonly IMapper _mapper;

    public DAFTPHKCommandHandlers(DataContext ctx, IMapper mapper)
    {
      _ctx = ctx;
      _mapper = mapper;
    }
    public async Task<Models.Entities.DAFTPHK> Handle(DAFTPHKCreate request, CancellationToken cancellationToken)
    {
      var model = _mapper.Map<Models.Entities.DAFTPHK>(request);

      await _ctx.AddAsync(model, cancellationToken);

      await _ctx.SaveChangesAsync(cancellationToken);

      return model;
    }

    public async Task<Models.Entities.DAFTPHK> Handle(DAFTPHKUpdate request, CancellationToken cancellationToken)
    {
      var model = await _ctx.DAFTPHK.SingleOrDefaultAsync(g => g.Id == request.Id, cancellationToken);

      if (model == null) throw new NoRecordException();

      _mapper.Map(request, model);

      await _ctx.SaveChangesAsync(cancellationToken);

      return model;
    }

    public async Task<Unit> Handle(DAFTPHKDelete request, CancellationToken cancellationToken)
    {
      var model = _ctx.DAFTPHK.SingleOrDefaultAsync(g => g.Id == request.Id, cancellationToken);

      if (model == null) throw new NoRecordException();

      await _ctx.SaveChangesAsync(cancellationToken);

      return Unit.Value;
    }


    public async Task<Unit> Handle(DAFTPHKBulkDelete request, CancellationToken cancellationToken)
    {
      var models = await _ctx.DAFTPHK
        .Where(g => request.Ids.Any(id => g.Id == id))
        .ToListAsync(cancellationToken);

      _ctx.RemoveRange(models);

      await _ctx.SaveChangesAsync(cancellationToken);

      return Unit.Value;
    }
  }
}