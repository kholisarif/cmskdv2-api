using AutoMapper;
using ICMSTU.API.Dtos;
using ICMSTU.API.Exceptions;
using ICMSTU.API.Infrastructures;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace ICMSTU.API.Commands.UserRole
{
  public class UserRoleCommandHandlers : IRequestHandler<UserRoleCreate, UserRoleDto>, IRequestHandler<UserRoleDelete>
  {
    private readonly DataContext _ctx;
    private readonly IMapper _mapper;

    public UserRoleCommandHandlers(DataContext ctx, IMapper mapper)
    {
      _ctx = ctx;
      _mapper = mapper;
    }

    public async Task<UserRoleDto> Handle(UserRoleCreate request, CancellationToken cancellationToken)
    {
      if (!_ctx.User.Any(u => u.Id == request.UserId))
        throw new NoRecordException("Id User tidak ditemukan");

      if (!_ctx.Role.Any(r => r.Id == request.RoleId))
        throw new NoRecordException("Id Role tidak ditemukan");

      var model = _mapper.Map<Models.Entities.UserRole>(request);

      await _ctx.AddAsync(model, cancellationToken);

      await _ctx.SaveChangesAsync(cancellationToken);

      return _mapper.Map<UserRoleDto>(model);
    }

    public async Task<Unit> Handle(UserRoleDelete request, CancellationToken cancellationToken)
    {
      var model = await _ctx.UserRole.SingleOrDefaultAsync(
        u => u.UserId == request.UserId && u.RoleId == request.RoleId, cancellationToken);

      if (model == null) throw new NoRecordException();

      _ctx.Remove(model);

      await _ctx.SaveChangesAsync(cancellationToken);

      return Unit.Value;
    }
  }
}
