using AutoMapper;
using ICMSTU.API.Exceptions;
using ICMSTU.API.Infrastructures;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace ICMSTU.API.Commands.Role
{
  public class RoleCommandHandlers : IRequestHandler<RoleCreate, Models.Entities.Role>,
    IRequestHandler<RoleUpdate, Models.Entities.Role>,
    IRequestHandler<RoleDelete>, IRequestHandler<RoleBulkDelete>
  {
    private readonly DataContext _ctx;
    private readonly IMapper _mapper;

    public RoleCommandHandlers(DataContext ctx, IMapper mapper)
    {
      _ctx = ctx;
      _mapper = mapper;
    }

    public async Task<Models.Entities.Role> Handle(RoleCreate request, CancellationToken cancellationToken)
    {
      var model = _mapper.Map<Models.Entities.Role>(request);

      await _ctx.AddAsync(model, cancellationToken);

      await _ctx.SaveChangesAsync(cancellationToken);

      return model;
    }

    public async Task<Models.Entities.Role> Handle(RoleUpdate request, CancellationToken cancellationToken)
    {
      var model = await _ctx.Role.SingleOrDefaultAsync(r => r.Id == request.Id, cancellationToken);

      if (model == null) throw new NoRecordException();

      _mapper.Map(request, model);

      await _ctx.SaveChangesAsync(cancellationToken);

      return model;
    }

    public async Task<Unit> Handle(RoleDelete request, CancellationToken cancellationToken)
    {
      var model = await _ctx.Role.SingleOrDefaultAsync(r => r.Id == request.Id, cancellationToken);

      if (model == null) throw new NoRecordException();

      _ctx.Remove(model);

      await _ctx.SaveChangesAsync(cancellationToken);

      return Unit.Value;
    }

    public async Task<Unit> Handle(RoleBulkDelete request, CancellationToken cancellationToken)
    {
      var models = await _ctx.Role.Where(r => request.Ids.Any(id => r.Id == id)).ToListAsync(cancellationToken);

      _ctx.RemoveRange(models);

      await _ctx.SaveChangesAsync(cancellationToken);

      return Unit.Value;
    }
  }
}
