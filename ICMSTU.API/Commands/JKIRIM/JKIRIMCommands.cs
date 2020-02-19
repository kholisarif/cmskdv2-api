using FluentValidation;
using MediatR;
using System.Collections.Generic;
using System;

namespace ICMSTU.API.Commands.JKIRIM
{
  public class JKIRIMCreate : IRequest<Models.Entities.JKIRIM>
  {
    public int StKirim { get; set; }
    public string UraiKirim { get; set; }
    public DateTime? DateCreate { get; set; }
    public DateTime? DateUpdate { get; set; }
  }

  public class JKIRIMUpdate : IRequest<Models.Entities.JKIRIM>
  {
    public int StKirim { get; set; }
    public string UraiKirim { get; set; }
    public int Id { get; set; }
    public DateTime? DateCreate { get; set; }
    public DateTime? DateUpdate { get; set; }
  }

  public class JKIRIMDelete : IRequest
  {
    public int? Id { get; set; }
  }

  public class JKIRIMBulkDelete : IRequest
  {
    public List<int> Ids { get; set; }
  }

  public class JKIRIMCreateValidator : AbstractValidator<JKIRIMCreate>
  {
    public JKIRIMCreateValidator()
    {
      
    }
  }

  public class JKIRIMUpdateValidator : AbstractValidator<JKIRIMUpdate>
  {
    public JKIRIMUpdateValidator()
    {
      
    }
  }

  public class JKIRIMDeleteValidator : AbstractValidator<JKIRIMDelete>
  {
    public JKIRIMDeleteValidator()
    {
      RuleFor(m => m.Id).NotNull();
    }
  }

  public class JKIRIMBulkDeleteValidator : AbstractValidator<JKIRIMBulkDelete>
  {
    public JKIRIMBulkDeleteValidator()
    {
      RuleFor(m => m.Ids).NotEmpty();
    }
  }
}
