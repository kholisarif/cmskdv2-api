using FluentValidation;
using MediatR;
using System.Collections.Generic;

namespace ICMSTU.API.Commands.Bank
{
  public class BankCreate : IRequest<Models.Entities.Bank>
  {
    public string NamaLengkap { get; set; }
    public string Nama { get; set; }
    public string KodeBank { get; set; }
    public string KodeSKN { get; set; }
    public string KodeRTGS { get; set; }
    public string KodeKota { get; set; }
    public string KodeSwift { get; set; }
  }

  public class BankUpdate : IRequest<Models.Entities.Bank>
  {
    public int? Id { get; set; }
    public string NamaLengkap { get; set; }
    public string Nama { get; set; }
    public string KodeBank { get; set; }
    public string KodeSKN { get; set; }
    public string KodeRTGS { get; set; }
    public string KodeKota { get; set; }
    public string KodeSwift { get; set; }
  }

  public class BankDelete : IRequest
  {
    public int? Id { get; set; }
  }

  public class BankBulkDelete : IRequest
  {
    public List<int> Ids { get; set; }
  }

  public class BankCreateValidator : AbstractValidator<BankCreate>
  {
    public BankCreateValidator()
    {
      RuleFor(m => m.NamaLengkap).NotEmpty();
      RuleFor(m => m.Nama).NotEmpty();
      RuleFor(m => m.KodeBank).NotEmpty();
      RuleFor(m => m.KodeSKN).NotEmpty();
      RuleFor(m => m.KodeRTGS).NotEmpty();
      RuleFor(m => m.KodeKota).NotEmpty();
      RuleFor(m => m.KodeSwift).NotEmpty();
    }
  }

  public class BankUpdateValidator : AbstractValidator<BankUpdate>
  {
    public BankUpdateValidator()
    {
      RuleFor(m => m.Id).NotNull();
      RuleFor(m => m.NamaLengkap).NotEmpty();
      RuleFor(m => m.Nama).NotEmpty();
      RuleFor(m => m.KodeBank).NotEmpty();
      RuleFor(m => m.KodeSKN).NotEmpty();
      RuleFor(m => m.KodeRTGS).NotEmpty();
      RuleFor(m => m.KodeKota).NotEmpty();
      RuleFor(m => m.KodeSwift).NotEmpty();
    }
  }

  public class BankDeleteValidator : AbstractValidator<BankDelete>
  {
    public BankDeleteValidator()
    {
      RuleFor(m => m.Id).NotNull();
    }
  }

  public class BankBulkDeleteValidator : AbstractValidator<BankBulkDelete>
  {
    public BankBulkDeleteValidator()
    {
      RuleFor(m => m.Ids).NotEmpty();
    }
  }
}
