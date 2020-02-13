using FluentValidation;
using MediatR;
using System.Collections.Generic;
using System;

namespace ICMSTU.API.Commands.MATANGR
{
  public class MATANGRCreate : IRequest<Models.Entities.MATANGR>
  {
    public string MtgKey { get; set; }
    public string kdPer { get; set; }
    public string nmPer { get; set; }
    public string mtgLevel { get; set; }
    public string kdKhusus { get; set; }
    public string type { get; set; }
    public int jnsRek { get; set; }
    public int stAktif { get; set; }
    public DateTime? DateCreate { get; set; }
    public DateTime? DateUpdate { get; set; }
  }

  public class MATANGRUpdate : IRequest<Models.Entities.MATANGR>
  {
    public string MtgKey { get; set; }
    public string kdPer { get; set; }
    public string nmPer { get; set; }
    public string mtgLevel { get; set; }
    public string kdKhusus { get; set; }
    public string type { get; set; }
    public int Id { get; set; }
    public int jnsRek { get; set; }
    public int stAktif { get; set; }
    public DateTime? DateCreate { get; set; }
    public DateTime? DateUpdate { get; set; }
  }

  public class MATANGRDelete : IRequest
  {
    public int? Id { get; set; }
  }

  public class MATANGRBulkDelete : IRequest
  {
    public List<int> Ids { get; set; }
  }

  public class MATANGRCreateValidator : AbstractValidator<MATANGRCreate>
  {
    public MATANGRCreateValidator()
    {
      
    }
  }

  public class MATANGRUpdateValidator : AbstractValidator<MATANGRUpdate>
  {
    public MATANGRUpdateValidator()
    {
      
    }
  }

  public class MATANGRDeleteValidator : AbstractValidator<MATANGRDelete>
  {
    public MATANGRDeleteValidator()
    {
      RuleFor(m => m.Id).NotNull();
    }
  }

  public class MATANGRBulkDeleteValidator : AbstractValidator<MATANGRBulkDelete>
  {
    public MATANGRBulkDeleteValidator()
    {
      RuleFor(m => m.Ids).NotEmpty();
    }
  }
}
