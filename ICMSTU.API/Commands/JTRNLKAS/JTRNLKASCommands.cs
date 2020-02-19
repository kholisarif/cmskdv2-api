using FluentValidation;
using MediatR;
using System.Collections.Generic;
using System;

namespace ICMSTU.API.Commands.JTRNLKAS
{
  public class JTRNLKASCreate : IRequest<Models.Entities.JTRNLKAS>
  {
    public string NoJetra { get; set; }
    public string NmJetra { get; set; }
    public string KdPers { get; set; }
    public DateTime? DateCreate { get; set; }
    public DateTime? DateUpdate { get; set; }
    
  }

  public class JTRNLKASUpdate : IRequest<Models.Entities.JTRNLKAS>
  {
    public string NoJetra { get; set; }
    public string NmJetra { get; set; }
    public string KdPers { get; set; }
    public int Id { get; set; }
    public DateTime? DateCreate { get; set; }
    public DateTime? DateUpdate { get; set; }
    
  }

  public class JTRNLKASDelete : IRequest
  {
    public int? Id { get; set; }
  }

  public class JTRNLKASBulkDelete : IRequest
  {
    public List<int> Ids { get; set; }
  }

  public class JTRNLKASCreateValidator : AbstractValidator<JTRNLKASCreate>
  {
    public JTRNLKASCreateValidator()
    {
      
    }
  }

  public class JTRNLKASUpdateValidator : AbstractValidator<JTRNLKASUpdate>
  {
    public JTRNLKASUpdateValidator()
    {
      
    }
  }

  public class JTRNLKASDeleteValidator : AbstractValidator<JTRNLKASDelete>
  {
    public JTRNLKASDeleteValidator()
    {
      RuleFor(m => m.Id).NotNull();
    }
  }

  public class JTRNLKASBulkDeleteValidator : AbstractValidator<JTRNLKASBulkDelete>
  {
    public JTRNLKASBulkDeleteValidator()
    {
      RuleFor(m => m.Ids).NotEmpty();
    }
  }
}
