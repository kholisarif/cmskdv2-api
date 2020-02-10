using FluentValidation;
using MediatR;
using System.Collections.Generic;

namespace ICMSTU.API.Commands.Golongan
{
  public class GolonganCreate : IRequest<Models.Entities.Golongan>
  {
    public string Kode { get; set; }
    public string Pangkat { get; set; }
  }

  public class GolonganUpdate : IRequest<Models.Entities.Golongan>
  {
    public int? Id { get; set; }
    public string Kode { get; set; }
    public string Pangkat { get; set; }
  }

  public class GolonganDelete : IRequest
  {
    public int? Id { get; set; }
  }

  public class GolonganBulkDelete : IRequest
  {
    public List<int> Ids { get; set; }
  }

  public class GolonganCreateValidator : AbstractValidator<GolonganCreate>
  {
    public GolonganCreateValidator()
    {
      RuleFor(m => m.Kode).NotEmpty();
      RuleFor(m => m.Pangkat).NotEmpty();
    }
  }

  public class GolonganUpdateValidator : AbstractValidator<GolonganUpdate>
  {
    public GolonganUpdateValidator()
    {
      RuleFor(m => m.Id).NotNull();
      RuleFor(m => m.Kode).NotEmpty();
      RuleFor(m => m.Pangkat).NotEmpty();
    }
  }

  public class GolonganDeleteValidator : AbstractValidator<GolonganDelete>
  {
    public GolonganDeleteValidator()
    {
      RuleFor(m => m.Id).NotNull();
    }
  }

  public class GolonganBulkDeleteValidator : AbstractValidator<GolonganBulkDelete>
  {
    public GolonganBulkDeleteValidator()
    {
      RuleFor(m => m.Ids).NotEmpty();
    }
  }
}
