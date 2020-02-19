using FluentValidation;
using MediatR;
using System.Collections.Generic;
using System;

namespace ICMSTU.API.Commands.JTRANSFER
{
  public class JTRANSFERCreate : IRequest<Models.Entities.JTRANSFER>
  {
    public int KdTransfer { get; set; }
    public string NmTransfer { get; set; }
    public string UraianTrans { get; set; }
    public Decimal? MinNominal { get; set; }
    public string FlagsNom { get; set; }
  }

  public class JTRANSFERUpdate : IRequest<Models.Entities.JTRANSFER>
  {
    public int KdTransfer { get; set; }
    public string NmTransfer { get; set; }
    public string UraianTrans { get; set; }
    public int Id { get; set; }
    public Decimal? MinNominal { get; set; }
    public string FlagsNom { get; set; }
  }

  public class JTRANSFERDelete : IRequest
  {
    public int? Id { get; set; }
  }

  public class JTRANSFERBulkDelete : IRequest
  {
    public List<int> Ids { get; set; }
  }

  public class JTRANSFERCreateValidator : AbstractValidator<JTRANSFERCreate>
  {
    public JTRANSFERCreateValidator()
    {
      
    }
  }

  public class JTRANSFERUpdateValidator : AbstractValidator<JTRANSFERUpdate>
  {
    public JTRANSFERUpdateValidator()
    {
      
    }
  }

  public class JTRANSFERDeleteValidator : AbstractValidator<JTRANSFERDelete>
  {
    public JTRANSFERDeleteValidator()
    {
      RuleFor(m => m.Id).NotNull();
    }
  }

  public class JTRANSFERBulkDeleteValidator : AbstractValidator<JTRANSFERBulkDelete>
  {
    public JTRANSFERBulkDeleteValidator()
    {
      RuleFor(m => m.Ids).NotEmpty();
    }
  }
}
