using AutoMapper;
using ICMSTU.API.Exceptions;
using ICMSTU.API.Infrastructures;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace ICMSTU.API.Commands.Berita
{
  public class BeritaCommandHandlers :
    IRequestHandler<BeritaCreate, Models.Entities.Berita>,
    IRequestHandler<BeritaUpdate, Models.Entities.Berita>,
    IRequestHandler<BeritaDelete>, IRequestHandler<BeritaBulkDelete>
  {
    private readonly DataContext _ctx;
    private readonly IMapper _mapper;

    public BeritaCommandHandlers(DataContext ctx, IMapper mapper)
    {
      _ctx = ctx;
      _mapper = mapper;
    }
    public async Task<Models.Entities.Berita> Handle(BeritaCreate request, CancellationToken cancellationToken)
    {
      var model = _mapper.Map<Models.Entities.Berita>(request);

      await _ctx.AddAsync(model, cancellationToken);

      await _ctx.SaveChangesAsync(cancellationToken);

      return model;
    }

    public async Task<Models.Entities.Berita> Handle(BeritaUpdate request, CancellationToken cancellationToken)
    {
      var model = await _ctx.Berita.SingleOrDefaultAsync(g => g.Id == request.Id, cancellationToken);

      if (model == null) throw new NoRecordException();

      _mapper.Map(request, model);

      await _ctx.SaveChangesAsync(cancellationToken);

      return model;
    }

    public async Task<Unit> Handle(BeritaDelete request, CancellationToken cancellationToken)
    {
      var model = _ctx.Berita.SingleOrDefaultAsync(g => g.Id == request.Id, cancellationToken);

      if (model == null) throw new NoRecordException();

      await _ctx.SaveChangesAsync(cancellationToken);

      return Unit.Value;
    }


    public async Task<Unit> Handle(BeritaBulkDelete request, CancellationToken cancellationToken)
    {
      var models = await _ctx.Berita
        .Where(g => request.Ids.Any(id => g.Id == id))
        .ToListAsync(cancellationToken);

      _ctx.RemoveRange(models);

      await _ctx.SaveChangesAsync(cancellationToken);

      return Unit.Value;
    }
  }
}