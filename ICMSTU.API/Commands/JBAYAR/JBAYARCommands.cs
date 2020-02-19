using FluentValidation;
using MediatR;
using System.Collections.Generic;
using System;

namespace ICMSTU.API.Commands.JBAYAR
{
  public class JBAYARCreate : IRequest<Models.Entities.JBAYAR>
  {
    public int KdBayar { get; set; }
    public string UraianBayar { get; set; }
    public DateTime? DateCreate { get; set; }
    public DateTime? DateUpdate { get; set; }
  }

  public class JBAYARUpdate : IRequest<Models.Entities.JBAYAR>
  {
    public int KdBayar { get; set; }
    public string UraianBayar { get; set; }
    public int Id { get; set; }
    public DateTime? DateCreate { get; set; }
    public DateTime? DateUpdate { get; set; }
  }

  public class JBAYARDelete : IRequest
  {
    public int? Id { get; set; }
  }

  public class JBAYARBulkDelete : IRequest
  {
    public List<int> Ids { get; set; }
  }

  public class JBAYARCreateValidator : AbstractValidator<JBAYARCreate>
  {
    public JBAYARCreateValidator()
    {
      
    }
  }

  public class JBAYARUpdateValidator : AbstractValidator<JBAYARUpdate>
  {
    public JBAYARUpdateValidator()
    {
      
    }
  }

  public class JBAYARDeleteValidator : AbstractValidator<JBAYARDelete>
  {
    public JBAYARDeleteValidator()
    {
      RuleFor(m => m.Id).NotNull();
    }
  }

  public class JBAYARBulkDeleteValidator : AbstractValidator<JBAYARBulkDelete>
  {
    public JBAYARBulkDeleteValidator()
    {
      RuleFor(m => m.Ids).NotEmpty();
    }
  }
}
