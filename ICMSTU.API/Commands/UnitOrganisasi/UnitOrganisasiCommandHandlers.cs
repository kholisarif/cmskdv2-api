using AutoMapper;
using ICMSTU.API.Exceptions;
using ICMSTU.API.Infrastructures;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace ICMSTU.API.Commands.UnitOrganisasi
{
  public class UnitOrganisasiCommandHandler :
    IRequestHandler<UnitOrganisasiCreate, Models.Entities.UnitOrganisasi>,
    IRequestHandler<UnitOrganisasiUpdate, Models.Entities.UnitOrganisasi>,
    IRequestHandler<UnitOrganisasiDelete>, IRequestHandler<UnitOrganisasiBulkDelete>
  {
    private readonly DataContext _ctx;
    private readonly IMapper _mapper;

    public UnitOrganisasiCommandHandler(DataContext ctx, IMapper mapper)
    {
      _ctx = ctx;
      _mapper = mapper;
    }

    public async Task<Models.Entities.UnitOrganisasi> Handle(UnitOrganisasiCreate message, CancellationToken cancellationToken)
    {
      var model = _mapper.Map<Models.Entities.UnitOrganisasi>(message);

      await _ctx.AddAsync(model, cancellationToken);

      await _ctx.SaveChangesAsync(cancellationToken);

      return model;
    }

    public async Task<Models.Entities.UnitOrganisasi> Handle(UnitOrganisasiUpdate message, CancellationToken cancellationToken)
    {
      var model = await _ctx.UnitOrganisasi.SingleOrDefaultAsync(o => o.Id == message.Id, cancellationToken);

      if (model == null) throw new NoRecordException();

      _mapper.Map(message, model);

      await _ctx.SaveChangesAsync(cancellationToken);

      return model;
    }

    public async Task<Unit> Handle(UnitOrganisasiDelete message, CancellationToken cancellationToken)
    {
      var model = await _ctx.UnitOrganisasi.SingleOrDefaultAsync(o => o.Id == message.Id, cancellationToken);

      if (model == null) throw new NoRecordException();

      _ctx.Remove(model);

      await _ctx.SaveChangesAsync(cancellationToken);

      return Unit.Value;
    }

    public async Task<Unit> Handle(UnitOrganisasiBulkDelete request, CancellationToken cancellationToken)
    {
      var models = await _ctx.UnitOrganisasi
        .Where(u => request.Ids.Any(id => u.Id == id))
        .ToListAsync(cancellationToken);

      models.ForEach(m =>
      {
        if (_ctx.UnitOrganisasi.Any(u => u.Kode.StartsWith(m.Kode) && u.Lvl > m.Lvl))
          throw new ParentConstrainViolationException();
      });

      _ctx.RemoveRange(models);

      await _ctx.SaveChangesAsync(cancellationToken);

      return Unit.Value;
    }
  }
}
