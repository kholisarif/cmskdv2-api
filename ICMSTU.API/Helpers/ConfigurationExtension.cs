using Microsoft.Extensions.Configuration;
using System.Data.SqlClient;

namespace ICMSTU.API.Helpers
{
  public static class ConfigurationExtension
  {
    public static string SetDbYear(this IConfiguration config, int? tahun = null)
    {
      var builder = new SqlConnectionStringBuilder(config.GetConnectionString("DefaultConnection"));

      if (tahun == null) return builder.ToString();

      var db = builder.InitialCatalog.Split('_')[0];

      builder.InitialCatalog = $"{db}_{tahun}";

      return builder.ToString();
    }
  }
}
