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
    [Migration("20191002061856_InitialCommit")]
    partial class InitialCommit
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.6-servicing-10079")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("ICMSTU.API.Models.Golongan", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Kode");

                    b.Property<string>("Pangkat");

                    b.HasKey("Id");

                    b.ToTable("GOLONGAN");
                });

            modelBuilder.Entity("ICMSTU.API.Models.Menu", b =>
                {
                    b.Property<int>("Id");

                    b.Property<string>("Configuration");

                    b.Property<int>("Lvl");

                    b.Property<string>("Nama");

                    b.Property<int?>("ParentId");

                    b.Property<string>("QueryParams");

                    b.Property<string>("RouterLink");

                    b.Property<string>("Tipe");

                    b.HasKey("Id");

                    b.HasIndex("ParentId");

                    b.ToTable("MENU");
                });

            modelBuilder.Entity("ICMSTU.API.Models.Pegawai", b =>
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

            modelBuilder.Entity("ICMSTU.API.Models.Permission", b =>
                {
                    b.Property<int>("RoleId");

                    b.Property<int>("MenuId");

                    b.HasKey("RoleId", "MenuId");

                    b.HasIndex("MenuId");

                    b.ToTable("PERMISSION");
                });

            modelBuilder.Entity("ICMSTU.API.Models.Role", b =>
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

            modelBuilder.Entity("ICMSTU.API.Models.Tahun", b =>
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

            modelBuilder.Entity("ICMSTU.API.Models.UnitOrganisasi", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Akronim");

                    b.Property<string>("Alamat");

                    b.Property<string>("Kode");

                    b.Property<int>("Lvl");

                    b.Property<string>("Nama");

                    b.Property<int?>("ParentId");

                    b.Property<string>("Telepon");

                    b.Property<string>("Tipe");

                    b.HasKey("Id");

                    b.HasIndex("ParentId");

                    b.HasIndex("Kode", "Nama")
                        .IsUnique()
                        .HasFilter("[Kode] IS NOT NULL AND [Nama] IS NOT NULL");

                    b.ToTable("UNITORGANISASI");
                });

            modelBuilder.Entity("ICMSTU.API.Models.User", b =>
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

            modelBuilder.Entity("ICMSTU.API.Models.UserRole", b =>
                {
                    b.Property<int>("RoleId");

                    b.Property<int>("UserId");

                    b.HasKey("RoleId", "UserId");

                    b.HasIndex("UserId");

                    b.ToTable("USERROLE");
                });

            modelBuilder.Entity("ICMSTU.API.Models.Menu", b =>
                {
                    b.HasOne("ICMSTU.API.Models.Menu", "Parent")
                        .WithMany("MenuCollection")
                        .HasForeignKey("ParentId")
                        .OnDelete(DeleteBehavior.Restrict);
                });

            modelBuilder.Entity("ICMSTU.API.Models.Pegawai", b =>
                {
                    b.HasOne("ICMSTU.API.Models.Golongan", "Golongan")
                        .WithMany()
                        .HasForeignKey("GolonganId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("ICMSTU.API.Models.Permission", b =>
                {
                    b.HasOne("ICMSTU.API.Models.Menu", "Menu")
                        .WithMany("Permissions")
                        .HasForeignKey("MenuId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("ICMSTU.API.Models.Role", "Role")
                        .WithMany("Permissions")
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("ICMSTU.API.Models.UnitOrganisasi", b =>
                {
                    b.HasOne("ICMSTU.API.Models.UnitOrganisasi", "Parent")
                        .WithMany("OPDCollection")
                        .HasForeignKey("ParentId");
                });

            modelBuilder.Entity("ICMSTU.API.Models.User", b =>
                {
                    b.HasOne("ICMSTU.API.Models.Pegawai", "Pegawai")
                        .WithMany()
                        .HasForeignKey("PegawaiId");

                    b.HasOne("ICMSTU.API.Models.UnitOrganisasi", "UnitOrganisasi")
                        .WithMany()
                        .HasForeignKey("UnitOrganisasiId");
                });

            modelBuilder.Entity("ICMSTU.API.Models.UserRole", b =>
                {
                    b.HasOne("ICMSTU.API.Models.Role", "Role")
                        .WithMany("UserRolesCollection")
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("ICMSTU.API.Models.User", "User")
                        .WithMany("UserRoleCollection")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
