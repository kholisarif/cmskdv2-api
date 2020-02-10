using FluentValidation;
using ICMSTU.API.Dtos;
using MediatR;

namespace ICMSTU.API.Commands.UserRole
{
  public class UserRoleCreate : IRequest<UserRoleDto>
  {
    public int? UserId { get; set; }
    public int? RoleId { get; set; }
  }

  public class UserRoleDelete : IRequest
  {
    public int? UserId { get; set; }
    public int? RoleId { get; set; }
  }

  public class UserRoleCreateValidator : AbstractValidator<UserRoleCreate>
  {
    public UserRoleCreateValidator()
    {
      RuleFor(m => m.UserId).NotNull();
      RuleFor(m => m.RoleId).NotNull();
    }
  }

  public class UserRoleDeleteValidator : AbstractValidator<UserRoleDelete>
  {
    public UserRoleDeleteValidator()
    {
      RuleFor(m => m.UserId).NotNull();
      RuleFor(m => m.RoleId).NotNull();
    }
  }
}
