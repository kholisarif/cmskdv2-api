using FluentValidation;
using MediatR;
using System.Collections.Generic;

namespace ICMSTU.API.Commands.Role
{
  public class RoleCreate : IRequest<Models.Entities.Role>
  {
    public string Nama { get; set; }
    public string Deskripsi { get; set; }
  }

  public class RoleUpdate : IRequest<Models.Entities.Role>
  {
    public int? Id { get; set; }
    public string Nama { get; set; }
    public string Deskripsi { get; set; }
  }

  public class RoleDelete : IRequest
  {
    public int? Id { get; set; }
  }

  public class RoleBulkDelete : IRequest
  {
    public List<int> Ids { get; set; }
  }

  public class RoleCreateValidator : AbstractValidator<RoleCreate>
  {
    public RoleCreateValidator()
    {
      RuleFor(m => m.Nama).NotEmpty();
    }
  }

  public class RoleUpdateValidator : AbstractValidator<RoleUpdate>
  {
    public RoleUpdateValidator()
    {
      RuleFor(m => m.Id).NotNull();
      RuleFor(m => m.Nama).NotEmpty();
    }
  }

  public class RoleDeleteValidator : AbstractValidator<RoleDelete>
  {
    public RoleDeleteValidator()
    {
      RuleFor(m => m.Id).NotNull();
    }
  }

  public class RoleBulkDeleteValidator : AbstractValidator<RoleBulkDelete>
  {
    public RoleBulkDeleteValidator()
    {
      RuleFor(m => m.Ids).NotEmpty();
    }
  }
}
