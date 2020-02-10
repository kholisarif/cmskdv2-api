using AutoMapper;
using ICMSTU.API.Exceptions;
using ICMSTU.API.Infrastructures;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace ICMSTU.API.Commands.MKegiatan
{
  public class MKegiatanCommandHandlers :
    IRequestHandler<MKegiatanCreate, Models.Entities.MKegiatan>,
    IRequestHandler<MKegiatanUpdate, Models.Entities.MKegiatan>,
    IRequestHandler<MKegiatanDelete>, IRequestHandler<MKegiatanBulkDelete>
  {
    private readonly DataContext _ctx;
    private readonly IMapper _mapper;

    public MKegiatanCommandHandlers(DataContext ctx, IMapper mapper)
    {
      _ctx = ctx;
      _mapper = mapper;
    }
    public async Task<Models.Entities.MKegiatan> Handle(MKegiatanCreate request, CancellationToken cancellationToken)
    {
      var model = _mapper.Map<Models.Entities.MKegiatan>(request);

      await _ctx.AddAsync(model, cancellationToken);

      await _ctx.SaveChangesAsync(cancellationToken);

      return model;
    }

    public async Task<Models.Entities.MKegiatan> Handle(MKegiatanUpdate request, CancellationToken cancellationToken)
    {
      var model = await _ctx.MKegiatan.SingleOrDefaultAsync(g => g.Id == request.Id, cancellationToken);

      if (model == null) throw new NoRecordException();

      _mapper.Map(request, model);

      await _ctx.SaveChangesAsync(cancellationToken);

      return model;
    }

    public async Task<Unit> Handle(MKegiatanDelete request, CancellationToken cancellationToken)
    {
      var model = _ctx.MKegiatan.SingleOrDefaultAsync(g => g.Id == request.Id, cancellationToken);

      if (model == null) throw new NoRecordException();

      await _ctx.SaveChangesAsync(cancellationToken);

      return Unit.Value;
    }


    public async Task<Unit> Handle(MKegiatanBulkDelete request, CancellationToken cancellationToken)
    {
      var models = await _ctx.MKegiatan
        .Where(g => request.Ids.Any(id => g.Id == id))
        .ToListAsync(cancellationToken);

      _ctx.RemoveRange(models);

      await _ctx.SaveChangesAsync(cancellationToken);

      return Unit.Value;
    }
  }
}