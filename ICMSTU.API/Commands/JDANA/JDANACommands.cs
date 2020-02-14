using FluentValidation;
using MediatR;
using System.Collections.Generic;
using System;

namespace ICMSTU.API.Commands.JDANA
{
  public class JDANACreate : IRequest<Models.Entities.JDANA>
  {
    public string KdDana { get; set; }
    public string NmDana { get; set; }
    public string Ket { get; set; }
    public string Type { get; set; }
    public DateTime? DateCreate { get; set; }
    public DateTime? DateUpdate { get; set; }
  }

  public class JDANAUpdate : IRequest<Models.Entities.JDANA>
  {
    public string KdDana { get; set; }
    public string NmDana { get; set; }
    public string Ket { get; set; }
    public int Id { get; set; }
    public string Type { get; set; }
    public DateTime? DateCreate { get; set; }
    public DateTime? DateUpdate { get; set; }
  }

  public class JDANADelete : IRequest
  {
    public int? Id { get; set; }
  }

  public class JDANABulkDelete : IRequest
  {
    public List<int> Ids { get; set; }
  }

  public class JDANACreateValidator : AbstractValidator<JDANACreate>
  {
    public JDANACreateValidator()
    {
      
    }
  }

  public class JDANAUpdateValidator : AbstractValidator<JDANAUpdate>
  {
    public JDANAUpdateValidator()
    {
      
    }
  }

  public class JDANADeleteValidator : AbstractValidator<JDANADelete>
  {
    public JDANADeleteValidator()
    {
      RuleFor(m => m.Id).NotNull();
    }
  }

  public class JDANABulkDeleteValidator : AbstractValidator<JDANABulkDelete>
  {
    public JDANABulkDeleteValidator()
    {
      RuleFor(m => m.Ids).NotEmpty();
    }
  }
}
