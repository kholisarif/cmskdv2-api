using ICMSTU.API.Models.Entities;
using Microsoft.AspNet.OData.Builder;
using Microsoft.AspNetCore.Mvc;

namespace ICMSTU.API.Infrastructures
{
  public class OdataModelConfiguration : IModelConfiguration
  {
    public void Apply(ODataModelBuilder builder, ApiVersion apiVersion)
    {
      builder.EntitySet<Role>(nameof(Role));
      builder.EntitySet<UnitOrganisasi>(nameof(UnitOrganisasi));
      builder.EntitySet<User>(nameof(User));
      builder.EntitySet<Menu>(nameof(Menu));
      builder.EntitySet<Golongan>(nameof(Golongan));
      builder.EntitySet<Pegawai>(nameof(Pegawai));
      builder.EntitySet<Tahun>(nameof(Tahun));
      builder.EntitySet<StrukturRekening>(nameof(StrukturRekening));
      builder.EntitySet<StrukturUnit>(nameof(StrukturUnit));
      builder.EntitySet<Permission>(nameof(Permission))
        .EntityType.HasKey(e => new { e.MenuId, e.RoleId });
      builder.EntitySet<UserRole>(nameof(UserRole))
        .EntityType.HasKey(e => new { e.RoleId, e.UserId });
      builder.EntitySet<SKUP>(nameof(SKUP));
      builder.EntitySet<SKUPDet>(nameof(SKUPDet));
      builder.EntitySet<Bank>(nameof(Bank));
      builder.EntitySet<BPK>(nameof(BPK));
      builder.EntitySet<BEND>(nameof(BEND));
      builder.EntitySet<DAFTUNIT>(nameof(DAFTUNIT));
      builder.EntitySet<DAFTPHK>(nameof(DAFTPHK));
      builder.EntitySet<KEGUNIT>(nameof(KEGUNIT));
      builder.EntitySet<BPKDETR>(nameof(BPKDETR));
      builder.EntitySet<MKegiatan>(nameof(MKegiatan));
      builder.EntitySet<MPGRM>(nameof(MPGRM));
      builder.EntitySet<Pegawai>(nameof(Pegawai));
      builder.EntitySet<PGRMUNIT>(nameof(PGRMUNIT));
    }
  }
}
