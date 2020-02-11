using AutoMapper;
using ICMSTU.API.Exceptions;
using ICMSTU.API.Infrastructures;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace ICMSTU.API.Commands.Pegawai
{
  public class PegawaiCommandHandlers :
    IRequestHandler<PegawaiCreate, Models.Entities.Pegawai>,
    IRequestHandler<PegawaiUpdate, Models.Entities.Pegawai>,
    IRequestHandler<PegawaiDelete>, IRequestHandler<PegawaiBulkDelete>
  {
    private readonly DataContext _ctx;
    private readonly IMapper _mapper;

    public PegawaiCommandHandlers(DataContext ctx, IMapper mapper)
    {
      _ctx = ctx;
      _mapper = mapper;
    }
    public async Task<Models.Entities.Pegawai> Handle(PegawaiCreate request, CancellationToken cancellationToken)
    {
      var model = _mapper.Map<Models.Entities.Pegawai>(request);

      await _ctx.AddAsync(model, cancellationToken);

      await _ctx.SaveChangesAsync(cancellationToken);

      return model;
    }

    public async Task<Models.Entities.Pegawai> Handle(PegawaiUpdate request, CancellationToken cancellationToken)
    {
      var model = await _ctx.Pegawai.SingleOrDefaultAsync(g => g.Id == request.Id, cancellationToken);

      if (model == null) throw new NoRecordException();

      _mapper.Map(request, model);

      await _ctx.SaveChangesAsync(cancellationToken);

      return model;
    }

    public async Task<Unit> Handle(PegawaiDelete request, CancellationToken cancellationToken)
    {
      var model = _ctx.Pegawai.SingleOrDefaultAsync(g => g.Id == request.Id, cancellationToken);

      if (model == null) throw new NoRecordException();

      await _ctx.SaveChangesAsync(cancellationToken);

      return Unit.Value;
    }


    public async Task<Unit> Handle(PegawaiBulkDelete request, CancellationToken cancellationToken)
    {
      var models = await _ctx.Pegawai
        .Where(g => request.Ids.Any(id => g.Id == id))
        .ToListAsync(cancellationToken);

      _ctx.RemoveRange(models);

      await _ctx.SaveChangesAsync(cancellationToken);

      return Unit.Value;
    }
  }
}