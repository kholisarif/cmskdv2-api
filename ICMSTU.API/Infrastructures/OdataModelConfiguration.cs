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
      builder.EntitySet<BPKDETRDANA>(nameof(BPKDETRDANA));
      builder.EntitySet<MKegiatan>(nameof(MKegiatan));
      builder.EntitySet<MPGRM>(nameof(MPGRM));
      builder.EntitySet<Pegawai>(nameof(Pegawai));
      builder.EntitySet<PGRMUNIT>(nameof(PGRMUNIT));
      builder.EntitySet<MATANGR>(nameof(MATANGR));
      builder.EntitySet<JBAYAR>(nameof(JBAYAR));
      builder.EntitySet<JTRANSFER>(nameof(JTRANSFER));
      builder.EntitySet<JDANA>(nameof(JDANA));
      builder.EntitySet<Berita>(nameof(Berita));
      builder.EntitySet<BERITADETR>(nameof(BERITADETR));
      builder.EntitySet<SP2D>(nameof(SP2D));
      builder.EntitySet<SP2DBPK>(nameof(SP2DBPK));
      builder.EntitySet<SP2DBPK>(nameof(BPKSP2D));
      builder.EntitySet<DASKR>(nameof(DASKR));
      builder.EntitySet<Kontrak>(nameof(Kontrak));
      builder.EntitySet<SBDANAR>(nameof(SBDANAR));
      builder.EntitySet<NPD>(nameof(NPD));
      builder.EntitySet<NPDBPK>(nameof(NPDBPK));
      builder.EntitySet<NPDSTS>(nameof(NPDSTS));
      builder.EntitySet<NPDTBPL>(nameof(NPDTBPL));
      builder.EntitySet<STATTRS>(nameof(STATTRS));
      builder.EntitySet<JCAIR>(nameof(JCAIR));
      builder.EntitySet<JKIRIM>(nameof(JKIRIM));
      builder.EntitySet<JTRNLKAS>(nameof(JTRNLKAS));
      builder.EntitySet<DASKRKEGUNIT>(nameof(DASKRKEGUNIT));
      var dASKRKEGUNIT = builder.Function("GETDASKRKEGUNIT");
      dASKRKEGUNIT.Parameter<string>("unitKey");
      dASKRKEGUNIT.Parameter<string>("kdTahap");
      dASKRKEGUNIT.ReturnsCollectionFromEntitySet<DASKRKEGUNIT>(nameof(DASKRKEGUNIT));
    }
  }
}
