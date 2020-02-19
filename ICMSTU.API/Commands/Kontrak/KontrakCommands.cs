using FluentValidation;
using MediatR;
using System.Collections.Generic;
using System;

namespace ICMSTU.API.Commands.Kontrak
{
  public class KontrakCreate : IRequest<Models.Entities.Kontrak>
  {
    public int KdTransfer { get; set; }
    public string NmTransfer { get; set; }
    public string UraianTrans { get; set; }
    public Decimal? MinNominal { get; set; }
    public string FlagsNom { get; set; }
  }

  public class KontrakUpdate : IRequest<Models.Entities.Kontrak>
  {
    public int KdTransfer { get; set; }
    public string NmTransfer { get; set; }
    public string UraianTrans { get; set; }
    public int Id { get; set; }
    public Decimal? MinNominal { get; set; }
    public string FlagsNom { get; set; }
  }

  public class KontrakDelete : IRequest
  {
    public int? Id { get; set; }
  }

  public class KontrakBulkDelete : IRequest
  {
    public List<int> Ids { get; set; }
  }

  public class KontrakCreateValidator : AbstractValidator<KontrakCreate>
  {
    public KontrakCreateValidator()
    {
      
    }
  }

  public class KontrakUpdateValidator : AbstractValidator<KontrakUpdate>
  {
    public KontrakUpdateValidator()
    {
      
    }
  }

  public class KontrakDeleteValidator : AbstractValidator<KontrakDelete>
  {
    public KontrakDeleteValidator()
    {
      RuleFor(m => m.Id).NotNull();
    }
  }

  public class KontrakBulkDeleteValidator : AbstractValidator<KontrakBulkDelete>
  {
    public KontrakBulkDeleteValidator()
    {
      RuleFor(m => m.Ids).NotEmpty();
    }
  }
}
