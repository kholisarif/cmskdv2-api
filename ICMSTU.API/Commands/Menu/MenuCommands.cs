using FluentValidation;
using MediatR;

namespace ICMSTU.API.Commands.Menu
{
  public class MenuCreateCommand : IRequest<Models.Entities.Menu>
  {
    public int? Id { get; set; }
    //public int? ParentId { get; set; }
    public string Kode { get; set; }
    public string Label { get; set; }
    public string Icon { get; set; }
    public string Resource { get; set; }
    public string RouterLink { get; set; }
    public string QueryParams { get; set; }
    public string Configuration { get; set; }
    public int Lvl { get; set; }
    public string Tipe { get; set; }
  }

  public class MenuUpdateCommand : IRequest<Models.Entities.Menu>
  {
    public int? Id { get; set; }
    //public int? ParentId { get; set; }
    public string Kode { get; set; }
    public string Label { get; set; }
    public string Icon { get; set; }
    public string Resource { get; set; }
    public string RouterLink { get; set; }
    public string QueryParams { get; set; }
    public string Configuration { get; set; }
    public int Lvl { get; set; }
    public string Tipe { get; set; }
  }

  public class MenuDeleteCommand : IRequest
  {
    public int? Id { get; set; }
  }

  public class MenuCreateValidator : AbstractValidator<MenuCreateCommand>
  {
    public MenuCreateValidator()
    {
      RuleFor(m => m.Id).NotNull();
      RuleFor(m => m.Kode).NotEmpty();
      RuleFor(m => m.Label).NotEmpty();
      RuleFor(m => m.Tipe).NotEmpty();
    }
  }

  public class MenuUpdateValidator : AbstractValidator<MenuUpdateCommand>
  {
    public MenuUpdateValidator()
    {
      RuleFor(m => m.Id).NotNull();
      RuleFor(m => m.Kode).NotEmpty();
      RuleFor(m => m.Label).NotEmpty();
      RuleFor(m => m.Tipe).NotEmpty();
    }
  }

  public class MenuDeleteValidator : AbstractValidator<MenuDeleteCommand>
  {
    public MenuDeleteValidator()
    {
      RuleFor(m => m.Id).NotNull();
    }
  }
}
