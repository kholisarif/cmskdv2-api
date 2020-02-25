using FluentValidation;
using MediatR;
using System.Collections.Generic;
using System;

namespace ICMSTU.API.Commands.Berita
{
  public class BeritaCreate : IRequest<Models.Entities.Berita>
  {
    public string UnitKey { get; set; }
    public string NoBA { get; set; }
    public DateTime? TglBA { get; set; }
    public string KdKegUnit { get; set; }
    public string NoKon { get; set; }
    public string UraiBA { get; set; }
    public DateTime? TglValid { get; set; }
    public string KdStatus{ get; set; }
    public int IdDAFTUNIT { get; set; }
    public int IdKontrak { get; set; }
    public int IdSTATTRS { get; set; }
    public int IdBeritaDETR { get; set; }
    public DateTime? DateCreate { get; set; }
    public DateTime? DateUpdate { get; set; }
    public string NoKontrak { get; set; }
    public string NoBerita{ get; set; }
  }

  public class BeritaUpdate : IRequest<Models.Entities.Berita>
  {
    public string UnitKey { get; set; }
    public string NoBA { get; set; }
    public DateTime? TglBA { get; set; }
    public string KdKegUnit { get; set; }
    public string NoKon { get; set; }
    public string UraiBA { get; set; }
    public DateTime? TglValid { get; set; }
    public string KdStatus{ get; set; }
    public int Id { get; set; }
    public int IdDAFTUNIT { get; set; }
    public int IdKontrak { get; set; }
    public int IdSTATTRS { get; set; }
    public int IdBeritaDETR { get; set; }
    public DateTime? DateCreate { get; set; }
    public DateTime? DateUpdate { get; set; }
    public string NoKontrak { get; set; }
    public string NoBerita{ get; set; }
  }

  public class BeritaDelete : IRequest
  {
    public int? Id { get; set; }
  }

  public class BeritaBulkDelete : IRequest
  {
    public List<int> Ids { get; set; }
  }

  public class BeritaCreateValidator : AbstractValidator<BeritaCreate>
  {
    public BeritaCreateValidator()
    {
      
    }
  }

  public class BeritaUpdateValidator : AbstractValidator<BeritaUpdate>
  {
    public BeritaUpdateValidator()
    {
      
    }
  }

  public class BeritaDeleteValidator : AbstractValidator<BeritaDelete>
  {
    public BeritaDeleteValidator()
    {
      RuleFor(m => m.Id).NotNull();
    }
  }

  public class BeritaBulkDeleteValidator : AbstractValidator<BeritaBulkDelete>
  {
    public BeritaBulkDeleteValidator()
    {
      RuleFor(m => m.Ids).NotEmpty();
    }
  }
}
