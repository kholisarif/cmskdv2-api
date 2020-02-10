﻿// <auto-generated />
using System;
using ICMSTU.API.Infrastructures;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace ICMSTU.API.Migrations
{
    [DbContext(typeof(DataContext))]
    [Migration("20191028101911_RenamingTahapan")]
    partial class RenamingTahapan
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.6-servicing-10079")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("ICMSTU.API.Models.Entities.Golongan", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Kode");

                    b.Property<string>("Pangkat");

                    b.HasKey("Id");

                    b.ToTable("GOLONGAN");
                });

            modelBuilder.Entity("ICMSTU.API.Models.Entities.JnsTransaksi", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Kode");

                    b.Property<string>("Nama");

                    b.HasKey("Id");

                    b.HasIndex("Kode", "Nama")
                        .IsUnique()
                        .HasFilter("[Kode] IS NOT NULL AND [Nama] IS NOT NULL");

                    b.ToTable("JNSTRANSAKSI");
                });

            modelBuilder.Entity("ICMSTU.API.Models.Entities.KegiatanUnit", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<decimal>("JumlahMin1")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("JumlahPlus1")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("Lokasi");

                    b.Property<decimal>("Pagu")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int>("ProgramUnitId");

                    b.Property<string>("Sasaran");

                    b.Property<int>("TahapanId");

                    b.Property<decimal>("TargetP")
                        .HasColumnType("decimal(18,2)");

                    b.Property<DateTime?>("TglAkhir");

                    b.Property<DateTime?>("TglAwal");

                    b.Property<string>("TolakUkur");

                    b.Property<int>("UnitOrganisasiId");

                    b.HasKey("Id");

                    b.HasIndex("ProgramUnitId");

                    b.HasIndex("UnitOrganisasiId");

                    b.HasIndex("TahapanId", "ProgramUnitId", "UnitOrganisasiId");

                    b.ToTable("KEGIATANUNIT");
                });

            modelBuilder.Entity("ICMSTU.API.Models.Entities.MKegiatan", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Kode");

                    b.Property<int>("Lvl");

                    b.Property<string>("Nama");

                    b.Property<int>("ProgramId");

                    b.Property<string>("Tipe");

                    b.HasKey("Id");

                    b.HasIndex("ProgramId", "Kode", "Nama")
                        .IsUnique()
                        .HasFilter("[Kode] IS NOT NULL AND [Nama] IS NOT NULL");

                    b.ToTable("MKEGIATAN");
                });

            modelBuilder.Entity("ICMSTU.API.Models.Entities.MProgram", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Kode");

                    b.Property<string>("Nama");

                    b.Property<int?>("UrusanId");

                    b.HasKey("Id");

                    b.HasIndex("UrusanId", "Kode", "Nama")
                        .IsUnique()
                        .HasFilter("[UrusanId] IS NOT NULL AND [Kode] IS NOT NULL AND [Nama] IS NOT NULL");

                    b.ToTable("MPROGRAM");
                });

            modelBuilder.Entity("ICMSTU.API.Models.Entities.Menu", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Configuration");

                    b.Property<string>("Icon");

                    b.Property<string>("Kode");

                    b.Property<string>("Label");

                    b.Property<int>("Lvl");

                    b.Property<string>("QueryParams");

                    b.Property<string>("Resource");

                    b.Property<string>("RouterLink");

                    b.Property<string>("Tipe");

                    b.HasKey("Id");

                    b.HasIndex("Kode")
                        .IsUnique()
                        .HasFilter("[Kode] IS NOT NULL");

                    b.ToTable("MENU");
                });

            modelBuilder.Entity("ICMSTU.API.Models.Entities.Pajak", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("JnsAkun");

                    b.Property<int>("JnsSetoran");

                    b.Property<string>("Kode");

                    b.Property<int>("KodeMap");

                    b.Property<int>("Lvl");

                    b.Property<int>("NmMap");

                    b.Property<string>("Tipe");

                    b.HasKey("Id");

                    b.ToTable("PAJAK");
                });

            modelBuilder.Entity("ICMSTU.API.Models.Entities.Pegawai", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Alamat");

                    b.Property<int>("GolonganId");

                    b.Property<string>("Jabatan");

                    b.Property<string>("Nama");

                    b.Property<string>("Nip");

                    b.Property<string>("Pendidikan");

                    b.HasKey("Id");

                    b.HasIndex("GolonganId");

                    b.ToTable("PEGAWAI");
                });

            modelBuilder.Entity("ICMSTU.API.Models.Entities.Permission", b =>
                {
                    b.Property<int>("RoleId");

                    b.Property<int>("MenuId");

                    b.Property<bool>("Approver");

                    b.Property<bool>("Checker");

                    b.Property<bool>("Maker");

                    b.HasKey("RoleId", "MenuId");

                    b.HasIndex("MenuId");

                    b.ToTable("PERMISSION");
                });

            modelBuilder.Entity("ICMSTU.API.Models.Entities.ProgramUnit", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Indikator");

                    b.Property<int>("ProgramId");

                    b.Property<string>("Sasaran");

                    b.Property<int>("TahapanId");

                    b.Property<string>("Target");

                    b.Property<int>("UnitOrganisasiId");

                    b.HasKey("Id");

                    b.HasIndex("ProgramId");

                    b.HasIndex("UnitOrganisasiId");

                    b.HasIndex("TahapanId", "ProgramId", "UnitOrganisasiId")
                        .IsUnique();

                    b.ToTable("PROGRAMUNIT");
                });

            modelBuilder.Entity("ICMSTU.API.Models.Entities.RefreshToken", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("ExpireAt");

                    b.Property<DateTime>("IssuedAt");

                    b.Property<string>("Token");

                    b.Property<int>("UserId");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("REFRESHTOKEN");
                });

            modelBuilder.Entity("ICMSTU.API.Models.Entities.Rekening", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("JnsAkun");

                    b.Property<int>("JnsRek");

                    b.Property<int>("KdKhusus");

                    b.Property<string>("Kode");

                    b.Property<int>("Lvl");

                    b.Property<string>("Nama");

                    b.Property<int>("Tipe");

                    b.HasKey("Id");

                    b.HasIndex("Kode", "Nama")
                        .IsUnique()
                        .HasFilter("[Kode] IS NOT NULL AND [Nama] IS NOT NULL");

                    b.ToTable("REKENING");
                });

            modelBuilder.Entity("ICMSTU.API.Models.Entities.Role", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Deskripsi");

                    b.Property<string>("Nama");

                    b.HasKey("Id");

                    b.ToTable("ROLE");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Deskripsi = "System Administrator",
                            Nama = "admin"
                        });
                });

            modelBuilder.Entity("ICMSTU.API.Models.Entities.Spp", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("ApprovedById");

                    b.Property<string>("ApprovedByName");

                    b.Property<DateTime?>("ApprovedDate");

                    b.Property<int?>("CheckedById");

                    b.Property<string>("CheckedByName");

                    b.Property<DateTime?>("CheckedDate");

                    b.Property<int?>("CreatedById");

                    b.Property<string>("CreatedByName");

                    b.Property<DateTime?>("CreatedDate");

                    b.Property<int>("JnsTransaksiId");

                    b.Property<int?>("KegiatanId");

                    b.Property<string>("Keperluan");

                    b.Property<int?>("NoPengajuan");

                    b.Property<string>("NoRegister");

                    b.Property<int>("SignedById");

                    b.Property<string>("SignedByName");

                    b.Property<DateTime?>("SignedDate");

                    b.Property<DateTime?>("TglPengajuan");

                    b.Property<int>("UnitOrganisasiId");

                    b.HasKey("Id");

                    b.HasIndex("JnsTransaksiId");

                    b.HasIndex("KegiatanId");

                    b.HasIndex("UnitOrganisasiId");

                    b.ToTable("SPP");
                });

            modelBuilder.Entity("ICMSTU.API.Models.Entities.SppPajak", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("PajakId");

                    b.Property<int>("SppRincianId");

                    b.HasKey("Id");

                    b.HasIndex("PajakId");

                    b.HasIndex("SppRincianId");

                    b.ToTable("SPPPAJAK");
                });

            modelBuilder.Entity("ICMSTU.API.Models.Entities.SppRincian", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("RekeningId");

                    b.Property<int>("SppId");

                    b.HasKey("Id");

                    b.HasIndex("RekeningId");

                    b.HasIndex("SppId");

                    b.ToTable("SPPRINCIAN");
                });

            modelBuilder.Entity("ICMSTU.API.Models.Entities.StrukturRekening", b =>
                {
                    b.Property<int>("Id");

                    b.Property<string>("Nama");

                    b.HasKey("Id");

                    b.ToTable("STUKTURREKENING");
                });

            modelBuilder.Entity("ICMSTU.API.Models.Entities.StrukturUnit", b =>
                {
                    b.Property<int>("Id");

                    b.Property<string>("Nama");

                    b.HasKey("Id");

                    b.ToTable("STRUKTURUNIT");
                });

            modelBuilder.Entity("ICMSTU.API.Models.Entities.Tahapan", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("Kode");

                    b.Property<int>("Lvl");

                    b.Property<string>("Nama");

                    b.Property<int?>("ParentId");

                    b.Property<string>("Tipe");

                    b.HasKey("Id");

                    b.HasIndex("ParentId");

                    b.HasIndex("Kode", "Nama")
                        .IsUnique()
                        .HasFilter("[Nama] IS NOT NULL");

                    b.ToTable("TAHAPAN");
                });

            modelBuilder.Entity("ICMSTU.API.Models.Entities.Tahun", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("Nilai");

                    b.HasKey("Id");

                    b.HasIndex("Nilai")
                        .IsUnique();

                    b.ToTable("TAHUN");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Nilai = 2019
                        },
                        new
                        {
                            Id = 2,
                            Nilai = 2020
                        });
                });

            modelBuilder.Entity("ICMSTU.API.Models.Entities.UnitOrganisasi", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Akronim");

                    b.Property<string>("Alamat");

                    b.Property<string>("Kode");

                    b.Property<int>("Lvl");

                    b.Property<string>("Nama");

                    b.Property<string>("Telepon");

                    b.Property<string>("Tipe");

                    b.HasKey("Id");

                    b.HasIndex("Kode", "Nama")
                        .IsUnique()
                        .HasFilter("[Kode] IS NOT NULL AND [Nama] IS NOT NULL");

                    b.ToTable("UNITORGANISASI");
                });

            modelBuilder.Entity("ICMSTU.API.Models.Entities.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Deskripsi");

                    b.Property<byte>("FalseLoginCount");

                    b.Property<bool>("LockedOut");

                    b.Property<string>("Password");

                    b.Property<int?>("PegawaiId");

                    b.Property<int?>("UnitOrganisasiId");

                    b.Property<string>("Username");

                    b.HasKey("Id");

                    b.HasIndex("PegawaiId");

                    b.HasIndex("UnitOrganisasiId");

                    b.HasIndex("Username")
                        .IsUnique()
                        .HasFilter("[Username] IS NOT NULL");

                    b.ToTable("USER");
                });

            modelBuilder.Entity("ICMSTU.API.Models.Entities.UserRole", b =>
                {
                    b.Property<int>("RoleId");

                    b.Property<int>("UserId");

                    b.HasKey("RoleId", "UserId");

                    b.HasIndex("UserId");

                    b.ToTable("USERROLE");
                });

            modelBuilder.Entity("ICMSTU.API.Models.Entities.KegiatanUnit", b =>
                {
                    b.HasOne("ICMSTU.API.Models.Entities.ProgramUnit", "ProgramUnit")
                        .WithMany()
                        .HasForeignKey("ProgramUnitId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("ICMSTU.API.Models.Entities.Tahapan", "Tahapan")
                        .WithMany("KegiatanUnit")
                        .HasForeignKey("TahapanId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("ICMSTU.API.Models.Entities.UnitOrganisasi", "UnitOrganisasi")
                        .WithMany("KegiatanUnit")
                        .HasForeignKey("UnitOrganisasiId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("ICMSTU.API.Models.Entities.MKegiatan", b =>
                {
                    b.HasOne("ICMSTU.API.Models.Entities.MProgram", "Program")
                        .WithMany("MKegiatan")
                        .HasForeignKey("ProgramId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("ICMSTU.API.Models.Entities.MProgram", b =>
                {
                    b.HasOne("ICMSTU.API.Models.Entities.UnitOrganisasi", "UnitOrganisasi")
                        .WithMany("MProgram")
                        .HasForeignKey("UrusanId");
                });

            modelBuilder.Entity("ICMSTU.API.Models.Entities.Pegawai", b =>
                {
                    b.HasOne("ICMSTU.API.Models.Entities.Golongan", "Golongan")
                        .WithMany()
                        .HasForeignKey("GolonganId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("ICMSTU.API.Models.Entities.Permission", b =>
                {
                    b.HasOne("ICMSTU.API.Models.Entities.Menu", "Menu")
                        .WithMany("Permissions")
                        .HasForeignKey("MenuId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("ICMSTU.API.Models.Entities.Role", "Role")
                        .WithMany("Permissions")
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("ICMSTU.API.Models.Entities.ProgramUnit", b =>
                {
                    b.HasOne("ICMSTU.API.Models.Entities.MProgram", "Program")
                        .WithMany()
                        .HasForeignKey("ProgramId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("ICMSTU.API.Models.Entities.Tahapan", "Tahapan")
                        .WithMany("ProgramUnit")
                        .HasForeignKey("TahapanId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("ICMSTU.API.Models.Entities.UnitOrganisasi", "UnitOrganisasi")
                        .WithMany("ProgramUnit")
                        .HasForeignKey("UnitOrganisasiId")
                        .OnDelete(DeleteBehavior.Restrict);
                });

            modelBuilder.Entity("ICMSTU.API.Models.Entities.RefreshToken", b =>
                {
                    b.HasOne("ICMSTU.API.Models.Entities.User", "User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("ICMSTU.API.Models.Entities.Spp", b =>
                {
                    b.HasOne("ICMSTU.API.Models.Entities.JnsTransaksi", "JnsTransaksi")
                        .WithMany()
                        .HasForeignKey("JnsTransaksiId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("ICMSTU.API.Models.Entities.MKegiatan", "Kegiatan")
                        .WithMany()
                        .HasForeignKey("KegiatanId");

                    b.HasOne("ICMSTU.API.Models.Entities.UnitOrganisasi", "UnitOrganisasi")
                        .WithMany()
                        .HasForeignKey("UnitOrganisasiId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("ICMSTU.API.Models.Entities.SppPajak", b =>
                {
                    b.HasOne("ICMSTU.API.Models.Entities.Pajak", "Pajak")
                        .WithMany()
                        .HasForeignKey("PajakId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("ICMSTU.API.Models.Entities.SppRincian", "SppRincian")
                        .WithMany("SppPajak")
                        .HasForeignKey("SppRincianId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("ICMSTU.API.Models.Entities.SppRincian", b =>
                {
                    b.HasOne("ICMSTU.API.Models.Entities.Rekening", "Rekening")
                        .WithMany("SppRincian")
                        .HasForeignKey("RekeningId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("ICMSTU.API.Models.Entities.Spp", "Spp")
                        .WithMany("SppRincian")
                        .HasForeignKey("SppId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("ICMSTU.API.Models.Entities.Tahapan", b =>
                {
                    b.HasOne("ICMSTU.API.Models.Entities.Tahapan", "Parent")
                        .WithMany("Children")
                        .HasForeignKey("ParentId")
                        .OnDelete(DeleteBehavior.Restrict);
                });

            modelBuilder.Entity("ICMSTU.API.Models.Entities.User", b =>
                {
                    b.HasOne("ICMSTU.API.Models.Entities.Pegawai", "Pegawai")
                        .WithMany()
                        .HasForeignKey("PegawaiId");

                    b.HasOne("ICMSTU.API.Models.Entities.UnitOrganisasi", "UnitOrganisasi")
                        .WithMany()
                        .HasForeignKey("UnitOrganisasiId");
                });

            modelBuilder.Entity("ICMSTU.API.Models.Entities.UserRole", b =>
                {
                    b.HasOne("ICMSTU.API.Models.Entities.Role", "Role")
                        .WithMany("UserRolesCollection")
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("ICMSTU.API.Models.Entities.User", "User")
                        .WithMany("UserRoleCollection")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
