using FluentValidation;
using ICMSTU.API.Dtos;
using MediatR;
using System.Collections.Generic;

namespace ICMSTU.API.Commands.User
{
  public class UserCreate : IRequest<UserDto>
  {
    public string Username { get; set; }
    public int? UnitOrganisasiId { get; set; }
    public int? PegawaiId { get; set; }
    public string Password { get; set; }
    public string Deskripsi { get; set; }
    public ICollection<int> RoleId { get; set; }
  }

  public class UserUpdate : IRequest<UserDto>
  {
    public int? Id { get; set; }
    public int? UnitOrganisasiId { get; set; }
    public int? PegawaiId { get; set; }
    public string OldPassword { get; set; }
    public string NewPassword { get; set; }
    public string PasswordConfirmation { get; set; }
    public string Deskripsi { get; set; }
  }

  public class UserLogin : IRequest<object>
  {
    public string Username { get; set; }
    public string Password { get; set; }
  }

  public class UserDelete : IRequest
  {
    public int? Id { get; set; }
  }

  public class UserBulkDelete : IRequest
  {
    public List<int> Ids { get; set; }
  }

  public class ValidateRefreshToken : IRequest<object>
  {
    public string Token { get; set; }
  }

  public class UserCreateValidator : AbstractValidator<UserCreate>
  {
    public UserCreateValidator()
    {
      RuleFor(u => u.Username).NotEmpty().MaximumLength(20).MinimumLength(4);
      RuleFor(u => u.Password).NotEmpty().MaximumLength(20).MinimumLength(6);
      RuleFor(u => u.RoleId).NotEmpty();
    }
  }

  public class UserUpdateValidator : AbstractValidator<UserUpdate>
  {
    public UserUpdateValidator()
    {
      RuleFor(u => u.Id).NotEmpty();
      RuleFor(u => u.NewPassword).Equal(u => u.PasswordConfirmation);
      RuleFor(u => u.PasswordConfirmation).Equal(u => u.NewPassword);
    }
  }

  public class UserDeleteValidator : AbstractValidator<UserDelete>
  {
    public UserDeleteValidator()
    {
      RuleFor(u => u.Id).NotEmpty();
    }
  }

  public class UserBulkDeleteValidator : AbstractValidator<UserBulkDelete>
  {
    public UserBulkDeleteValidator()
    {
      RuleFor(u => u.Ids).NotEmpty();
    }
  }

  public class UserLoginValidator : AbstractValidator<UserLogin>
  {
    public UserLoginValidator()
    {
      RuleFor(m => m.Username).NotEmpty();
      RuleFor(m => m.Password).NotEmpty();
    }
  }

  public class ValidateRefreshTokenValidator : AbstractValidator<ValidateRefreshToken>
  {
    public ValidateRefreshTokenValidator()
    {
      RuleFor(m => m.Token).NotEmpty();
    }
  }
}
