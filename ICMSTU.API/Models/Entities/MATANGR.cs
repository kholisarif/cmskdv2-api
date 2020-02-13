using System.ComponentModel.DataAnnotations.Schema;
using System;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;

namespace ICMSTU.API.Models.Entities
{
  [Table("MATANGR")]
  public class MATANGR
  {
    [Key]
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
    public List<BPKDETR> BPKDETRs { get; set; }
  }
}
