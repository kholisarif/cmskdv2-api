using ICMSTU.API.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace ICMSTU.API.Infrastructures
{
  public partial class DataContext : DbContext
  {
    public DataContext(DbContextOptions<DataContext> options)
      : base(options)
    {
    }

    public DbSet<UnitOrganisasi> UnitOrganisasi { get; set; }
    public DbSet<Golongan> Golongan { get; set; }
    public DbSet<Pegawai> Pegawai { get; set; }
    public DbSet<Role> Role { get; set; }
    public DbSet<User> User { get; set; }
    public DbSet<UserRole> UserRole { get; set; }
    public DbSet<Menu> Menu { get; set; }
    public DbSet<Permission> Permission { get; set; }
    public DbSet<Tahun> Tahun { get; set; }
    public DbSet<StrukturRekening> StrukturRekening { get; set; }
    public DbSet<StrukturUnit> StrukturUnit { get; set; }
    public DbSet<RefreshToken> RefreshToken { get; set; }
    public DbSet<SPP> SPP { get; set; }
    public DbSet<SPPRincian> SPPRincian { get; set; }
    public DbSet<SPPPajak> SPPPajak { get; set; }
    public DbSet<JnsTransaksi> JnsTransaksi { get; set; }
    public DbSet<Rekening> Rekening { get; set; }
    public DbSet<MProgram> MProgram { get; set; }
    public DbSet<MKegiatan> MKegiatan { get; set; }
    public DbSet<Tahapan> Tahapan { get; set; }
    public DbSet<ProgramUnit> ProgramUnit { get; set; }
    public DbSet<KegiatanUnit> KegiatanUnit { get; set; }
    public DbSet<Bank> Bank { get; set; }
    public DbSet<RKUD> RKUD { get; set; }
    public DbSet<JnsBend> JnsBend { get; set; }
    public DbSet<Bendahara> Bendahara { get; set; }
    public DbSet<SKUP> SKUP { get; set; }
    public DbSet<SKUPDet> SKUPDet { get; set; }
    public DbSet<BPK> BPK { get; set; }
    public DbSet<BEND> BEND { get; set; }
    public DbSet<DAFTUNIT> DAFTUNIT { get; set; }
    public DbSet<DAFTPHK> DAFTPHK { get; set; }
    public DbSet<KEGUNIT> KEGUNIT { get; set; }
    public DbSet<BPKDETR> BPKDETR { get; set; }
    public DbSet<MPGRM> MPGRM { get; set; }
    public DbSet<PGRMUNIT> PGRMUNIT { get; set; }
    public DbSet<MATANGR> MATANGR { get; set; }
    public DbSet<JBAYAR> JBAYAR { get; set; }
    public DbSet<JTRANSFER> JTRANSFER { get; set; }
    public DbSet<JDANA> JDANA { get; set; }
    public DbSet<BPKDETRDANA> BPKDETRDANA { get; set; }
    public DbSet<Berita> Berita { get; set; }
    public DbSet<BERITADETR> BERITADETR { get; set; }
    public DbSet<SP2D> SP2D { get; set; }
    public DbSet<DASKR> DASKR { get; set; }
    public DbSet<Kontrak> Kontrak { get; set; }
    public DbSet<STATTRS> STATTRS { get; set; }
    public DbSet<JCAIR> JCAIR { get; set; }
    public DbSet<JKIRIM> JKIRIM { get; set; }
    public DbSet<JTRNLKAS> JTRNLKAS { get; set; }


    protected override void OnModelCreating(ModelBuilder builder)
    {
      //base.OnModelCreating(builder);

      //foreach (var property in builder.Model.GetEntityTypes()
      //  .SelectMany(t => t.GetProperties())
      //  .Where(p => p.ClrType == typeof(decimal)))
      //{
      //  property.Relational().ColumnType = "decimal(18, 2)";
      //}

      builder.Entity<UnitOrganisasi>(e =>
      {
        e.HasIndex(u => new { u.Kode, u.Nama }).IsUnique();
      });

      builder.Entity<JnsTransaksi>(e => { e.HasIndex(j => new { j.Kode, j.Nama }).IsUnique(); });

      builder.Entity<Rekening>(e =>
      {
        e.HasIndex(j => new { j.Kode, j.Nama }).IsUnique();
      });

      // builder.Entity<MProgram>(e =>
      // {
      //   e.HasOne(m => m.UnitOrganisasi)
      //     .WithMany(u => u.MProgram)
      //     .HasForeignKey(u => u.UrusanId)
      //     .IsRequired(false);

      //   e.HasIndex(m => new { m.UrusanId, m.Kode, m.Nama }).IsUnique();
      // });

      // builder.Entity<MKegiatan>(e =>
      // {
      //   e.HasOne(m => m.Program)
      //     .WithMany(m => m.MKegiatan)
      //     .HasForeignKey(m => m.ProgramId)
      //     .IsRequired();

      //   e.HasIndex(m => new { m.ProgramId, m.Kode, m.Nama }).IsUnique();
      // });

      builder.Entity<ProgramUnit>(e =>
      {
        e.HasIndex(p => new { p.TahapanId, p.ProgramId, p.UnitOrganisasiId }).IsUnique();

        e.HasOne(p => p.UnitOrganisasi)
          .WithMany(p => p.ProgramUnit)
          .HasForeignKey(p => p.UnitOrganisasiId)
          .IsRequired()
          .OnDelete(DeleteBehavior.Restrict);
      });

      builder.Entity<KegiatanUnit>(e =>
      {
        e.HasIndex(k => new { k.TahapanId, k.ProgramUnitId, k.UnitOrganisasiId });

        e.Property(k => k.TargetP).HasColumnType("decimal(18,2)");
        e.Property(k => k.JumlahMin1).HasColumnType("decimal(18,2)");
        e.Property(k => k.Pagu).HasColumnType("decimal(18,2)");
        e.Property(k => k.JumlahPlus1).HasColumnType("decimal(18,2)");
      });

      builder.Entity<Tahapan>(e =>
      {
        e.HasIndex(t => new { t.Kode, t.Nama }).IsUnique();

        //e.HasOne(t => t.Parent)
        //  .WithMany(t => t.Children)
        //  .HasForeignKey(t => t.ParentId)
        //  .IsRequired(false)
        //  .OnDelete(DeleteBehavior.Restrict);

        e.HasMany(t => t.ProgramUnit)
          .WithOne(k => k.Tahapan)
          .HasForeignKey(k => k.TahapanId)
          .OnDelete(DeleteBehavior.Restrict);

        e.HasMany(t => t.KegiatanUnit)
          .WithOne(k => k.Tahapan)
          .HasForeignKey(k => k.TahapanId)
          .OnDelete(DeleteBehavior.Restrict);
      });

      builder.Entity<User>(e =>
      {
        e.HasIndex(u => u.Username).IsUnique();
      });

      builder.Entity<UserRole>(ur =>
      {
        ur.HasKey(e => new { e.RoleId, e.UserId });

        ur.HasOne(e => e.User)
          .WithMany(r => r.UserRoleCollection)
          .HasForeignKey(u => u.UserId)
          .IsRequired();

        ur.HasOne(e => e.Role)
          .WithMany(r => r.UserRolesCollection)
          .HasForeignKey(r => r.RoleId)
          .IsRequired();
      });

      builder.Entity<Menu>(e =>
      {
        e.HasKey(m => m.Id);

        e.HasIndex(m => m.Kode).IsUnique();

        //e.HasOne(m => m.Parent)
        //  .WithMany(m => m.MenuCollection)
        //  .OnDelete(DeleteBehavior.Restrict);
      });

      builder.Entity<Permission>(e =>
      {
        e.HasKey(p => new { p.RoleId, p.MenuId });
      });

      builder.Entity<Tahun>(e =>
      {
        e.HasIndex(t => t.Nilai).IsUnique();
        e.HasData(new Tahun { Id = 1, Nilai = 2019 }, new Tahun { Id = 2, Nilai = 2020 });
      });

      builder.Entity<Role>(e =>
      {
        e.HasData(new Role { Id = 1, Nama = "admin", Deskripsi = "System Administrator" });
      });

      builder.Entity<StrukturRekening>(e =>
      {
        e.Property(s => s.Id).ValueGeneratedNever();
      });

      builder.Entity<StrukturUnit>(e =>
      {
        e.Property(s => s.Id).ValueGeneratedNever();
      });

      builder.Entity<Bank>(e => { e.HasIndex(b => new { b.KodeBank, b.Nama }).IsUnique(); });

      builder.Entity<RKUD>(e =>
      {
        e.HasIndex(r => new { r.BankId, r.NamaRekening, r.NoRekening }).IsUnique();

        e.Property(r => r.SaldoAwal).HasColumnType("decimal(18, 2)");
      });

      builder.Entity<JnsBend>(e => { e.HasIndex(j => j.Nama).IsUnique(); });

      builder.Entity<Bendahara>(e =>
      {
        e.HasIndex(b => new { b.NoSK, b.UnitOrganisasiId, b.BankId, b.JnsBendId, b.PegawaiId });

        e.Property(b => b.SaldoBend).HasColumnType("decimal(18, 2)");

        e.Property(b => b.SaldoBendt).HasColumnType("decimal(18, 2)");
      });

      builder.Entity<BEND>(e =>
      {
        e.Property(b => b.SaldoBend).HasColumnType("decimal(18, 2)");

        e.Property(b => b.SaldoBendT).HasColumnType("decimal(18, 2)");
      });

      builder.Entity<BERITADETR>(e =>
      {
        e.Property(b => b.Nilai).HasColumnType("decimal(18, 2)");
      });

      // builder.Entity<PGRMUNIT>()
      //       .HasKey(t => new { t.UnitKey, t.IdPrgrm });

      // builder.Entity<PGRMUNIT>()
      //     .HasOne(pt => pt.MPGRM)
      //     .WithMany(p => p.PGRMUNITs)
      //     .HasForeignKey(pt => pt.IdPrgrm);
      
      // builder.Entity<PGRMUNIT>()
      // .HasOne(pt => pt.DAFTUNIT)
      // .WithMany(t => t.PGRMUNITs)
      // .HasForeignKey(pt => pt.UnitKey);

      // builder.Entity<KEGUNIT>()
      //   .HasKey(c => new { c.KdTahap, c.UnitKey, c.KdKegUnit });

      // builder.Entity<MKegiatan>()
      //             .HasOne(p => p.KEGUNIT)
      //             .WithMany(b => b.MKegiatans);
      builder.Entity<KEGUNIT>(e =>
      {
        e.HasIndex(b => new { b.KdKegUnit, b.UnitKey, b.IdPrgrm });

        e.Property(b => b.TargetP).HasColumnType("decimal(18, 2)");

        e.Property(b => b.JumlahMin1).HasColumnType("decimal(18, 2)");

        e.Property(b => b.Pagu).HasColumnType("decimal(18, 2)");

        e.Property(b => b.JumlahPls1).HasColumnType("decimal(18, 2)");
      });

      builder.Entity<BPKDETR>(e =>
      {
        e.Property(b => b.Nilai).HasColumnType("decimal(18, 2)");
      });

      builder.Entity<BPKDETRDANA>(e =>
      {
        e.Property(b => b.Nilai).HasColumnType("decimal(18, 2)");
      });

      builder.Entity<DASKR>(e =>
      {
        e.Property(b => b.Nilai).HasColumnType("decimal(18, 2)");
      });

      builder.Entity<Kontrak>(e =>
      {
        e.Property(b => b.Nilai).HasColumnType("decimal(18, 2)");
      });

      builder.Entity<JTRANSFER>(e =>
      {
        e.Property(b => b.MinNominal).HasColumnType("decimal(18, 2)");
      });

      builder.Entity<SKUP>(e =>
      {
        e.HasIndex(b => b.NoSK).IsUnique();
      });

      builder.Entity<SKUPDet>(e =>
      {
        e.HasIndex(b => new { b.SKUPId, b.UnitOrganisasiId }).IsUnique();

        e.Property(b => b.Nilai).HasColumnType("decimal(18, 2)");
      });

      builder.Entity<SPP>(e =>
      {
        e.HasIndex(s => new { s.UnitOrganisasiId, s.JnsTransaksiId, s.KegiatanUnitId, s.NoPengajuan, s.NoRegister });
      });

      builder.Entity<BPK>(e =>
      {
        e.HasKey(o => new { o.UnitKey, o.NoBPK });
      });
    }
  }
}
