using FluentValidation;
using MediatR;
using System.Collections.Generic;
using System;

namespace ICMSTU.API.Commands.DAFTUNIT
{
  public class DAFTUNITCreate : IRequest<Models.Entities.DAFTUNIT>
  {
    public string UnitKey { get; set; }
    public string KdLevel { get; set; }
    public string KdUnit { get; set; }
    public string NmUnit { get; set; }
    public string AkroUnit { get; set; }
    public string Alamat { get; set; }
    public string Telepon{ get; set; }
    public string Type { get; set; }
    public DateTime DateCreate { get; set; }
    public DateTime DateUpdate { get; set; }
  }

  public class DAFTUNITUpdate : IRequest<Models.Entities.DAFTUNIT>
  {
    public string UnitKey { get; set; }
    public string KdLevel { get; set; }
    public string KdUnit { get; set; }
    public string NmUnit { get; set; }
    public string AkroUnit { get; set; }
    public string Alamat { get; set; }
    public string Telepon{ get; set; }
    public string Type { get; set; }
    public int Id { get; set; }
    public DateTime DateCreate { get; set; }
    public DateTime DateUpdate { get; set; }
  }

  public class DAFTUNITDelete : IRequest
  {
    public int? Id { get; set; }
  }

  public class DAFTUNITBulkDelete : IRequest
  {
    public List<int> Ids { get; set; }
  }

  public class DAFTUNITCreateValidator : AbstractValidator<DAFTUNITCreate>
  {
    public DAFTUNITCreateValidator()
    {
      
    }
  }

  public class DAFTUNITUpdateValidator : AbstractValidator<DAFTUNITUpdate>
  {
    public DAFTUNITUpdateValidator()
    {
      
    }
  }

  public class DAFTUNITDeleteValidator : AbstractValidator<DAFTUNITDelete>
  {
    public DAFTUNITDeleteValidator()
    {
      RuleFor(m => m.Id).NotNull();
    }
  }

  public class DAFTUNITBulkDeleteValidator : AbstractValidator<DAFTUNITBulkDelete>
  {
    public DAFTUNITBulkDeleteValidator()
    {
      RuleFor(m => m.Ids).NotEmpty();
    }
  }
}
