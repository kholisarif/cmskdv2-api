using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ICMSTU.API.Migrations
{
    public partial class AddSpp : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "JnsTransaksi",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Kode = table.Column<string>(nullable: true),
                    Nama = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_JnsTransaksi", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PAJAK",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Kode = table.Column<string>(nullable: true),
                    KodeMap = table.Column<int>(nullable: false),
                    NmMap = table.Column<int>(nullable: false),
                    JnsSetoran = table.Column<int>(nullable: false),
                    JnsAkun = table.Column<int>(nullable: false),
                    Lvl = table.Column<int>(nullable: false),
                    Tipe = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PAJAK", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "REKENING",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Kode = table.Column<string>(nullable: true),
                    Nama = table.Column<string>(nullable: true),
                    Lvl = table.Column<int>(nullable: false),
                    KdKhusus = table.Column<int>(nullable: false),
                    JnsRek = table.Column<int>(nullable: false),
                    JnsAkun = table.Column<int>(nullable: false),
                    Tipe = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_REKENING", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SPP",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CreatedById = table.Column<int>(nullable: true),
                    CreatedDate = table.Column<DateTime>(nullable: true),
                    CreatedByName = table.Column<string>(nullable: true),
                    CheckedById = table.Column<int>(nullable: true),
                    CheckedDate = table.Column<DateTime>(nullable: true),
                    CheckedByName = table.Column<string>(nullable: true),
                    ApprovedById = table.Column<int>(nullable: true),
                    ApprovedDate = table.Column<DateTime>(nullable: true),
                    ApprovedByName = table.Column<string>(nullable: true),
                    SignedById = table.Column<int>(nullable: false),
                    SignedDate = table.Column<DateTime>(nullable: true),
                    SignedByName = table.Column<string>(nullable: true),
                    UnitOrganisasiId = table.Column<int>(nullable: false),
                    JnsTransaksiId = table.Column<int>(nullable: false),
                    NoPengajuan = table.Column<int>(nullable: true),
                    TglPengajuan = table.Column<DateTime>(nullable: true),
                    NoRegister = table.Column<string>(nullable: true),
                    Keperluan = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SPP", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SPP_JnsTransaksi_JnsTransaksiId",
                        column: x => x.JnsTransaksiId,
                        principalTable: "JnsTransaksi",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SPP_UNITORGANISASI_UnitOrganisasiId",
                        column: x => x.UnitOrganisasiId,
                        principalTable: "UNITORGANISASI",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SPPRINCIAN",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    SppId = table.Column<int>(nullable: false),
                    RekeningId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SPPRINCIAN", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SPPRINCIAN_REKENING_RekeningId",
                        column: x => x.RekeningId,
                        principalTable: "REKENING",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SPPRINCIAN_SPP_SppId",
                        column: x => x.SppId,
                        principalTable: "SPP",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SPPPAJAK",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    SppRincianId = table.Column<int>(nullable: false),
                    PajakId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SPPPAJAK", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SPPPAJAK_PAJAK_PajakId",
                        column: x => x.PajakId,
                        principalTable: "PAJAK",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SPPPAJAK_SPPRINCIAN_SppRincianId",
                        column: x => x.SppRincianId,
                        principalTable: "SPPRINCIAN",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_JnsTransaksi_Kode",
                table: "JnsTransaksi",
                column: "Kode",
                unique: true,
                filter: "[Kode] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_REKENING_Kode_Nama",
                table: "REKENING",
                columns: new[] { "Kode", "Nama" },
                unique: true,
                filter: "[Kode] IS NOT NULL AND [Nama] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_SPP_JnsTransaksiId",
                table: "SPP",
                column: "JnsTransaksiId");

            migrationBuilder.CreateIndex(
                name: "IX_SPP_UnitOrganisasiId",
                table: "SPP",
                column: "UnitOrganisasiId");

            migrationBuilder.CreateIndex(
                name: "IX_SPPPAJAK_PajakId",
                table: "SPPPAJAK",
                column: "PajakId");

            migrationBuilder.CreateIndex(
                name: "IX_SPPPAJAK_SppRincianId",
                table: "SPPPAJAK",
                column: "SppRincianId");

            migrationBuilder.CreateIndex(
                name: "IX_SPPRINCIAN_RekeningId",
                table: "SPPRINCIAN",
                column: "RekeningId");

            migrationBuilder.CreateIndex(
                name: "IX_SPPRINCIAN_SppId",
                table: "SPPRINCIAN",
                column: "SppId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SPPPAJAK");

            migrationBuilder.DropTable(
                name: "PAJAK");

            migrationBuilder.DropTable(
                name: "SPPRINCIAN");

            migrationBuilder.DropTable(
                name: "REKENING");

            migrationBuilder.DropTable(
                name: "SPP");

            migrationBuilder.DropTable(
                name: "JnsTransaksi");
        }
    }
}
