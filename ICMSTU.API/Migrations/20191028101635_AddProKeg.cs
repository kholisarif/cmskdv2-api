using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ICMSTU.API.Migrations
{
    public partial class AddProKeg : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "KegiatanId",
                table: "SPP",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Lvl",
                table: "MKEGIATAN",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "Tipe",
                table: "MKEGIATAN",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Tahapan",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ParentId = table.Column<int>(nullable: true),
                    Kode = table.Column<int>(nullable: false),
                    Nama = table.Column<string>(nullable: true),
                    Lvl = table.Column<int>(nullable: false),
                    Tipe = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tahapan", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Tahapan_Tahapan_ParentId",
                        column: x => x.ParentId,
                        principalTable: "Tahapan",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "PROGRAMUNIT",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    TahapanId = table.Column<int>(nullable: false),
                    ProgramId = table.Column<int>(nullable: false),
                    UnitOrganisasiId = table.Column<int>(nullable: false),
                    Target = table.Column<string>(nullable: true),
                    Sasaran = table.Column<string>(nullable: true),
                    Indikator = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PROGRAMUNIT", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PROGRAMUNIT_MPROGRAM_ProgramId",
                        column: x => x.ProgramId,
                        principalTable: "MPROGRAM",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PROGRAMUNIT_Tahapan_TahapanId",
                        column: x => x.TahapanId,
                        principalTable: "Tahapan",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PROGRAMUNIT_UNITORGANISASI_UnitOrganisasiId",
                        column: x => x.UnitOrganisasiId,
                        principalTable: "UNITORGANISASI",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "KEGIATANUNIT",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ProgramUnitId = table.Column<int>(nullable: false),
                    UnitOrganisasiId = table.Column<int>(nullable: false),
                    TahapanId = table.Column<int>(nullable: false),
                    TglAwal = table.Column<DateTime>(nullable: true),
                    TglAkhir = table.Column<DateTime>(nullable: true),
                    Lokasi = table.Column<string>(nullable: true),
                    TolakUkur = table.Column<string>(nullable: true),
                    Sasaran = table.Column<string>(nullable: true),
                    TargetP = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    JumlahMin1 = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Pagu = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    JumlahPlus1 = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_KEGIATANUNIT", x => x.Id);
                    table.ForeignKey(
                        name: "FK_KEGIATANUNIT_PROGRAMUNIT_ProgramUnitId",
                        column: x => x.ProgramUnitId,
                        principalTable: "PROGRAMUNIT",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_KEGIATANUNIT_Tahapan_TahapanId",
                        column: x => x.TahapanId,
                        principalTable: "Tahapan",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_KEGIATANUNIT_UNITORGANISASI_UnitOrganisasiId",
                        column: x => x.UnitOrganisasiId,
                        principalTable: "UNITORGANISASI",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_SPP_KegiatanId",
                table: "SPP",
                column: "KegiatanId");

            migrationBuilder.CreateIndex(
                name: "IX_KEGIATANUNIT_ProgramUnitId",
                table: "KEGIATANUNIT",
                column: "ProgramUnitId");

            migrationBuilder.CreateIndex(
                name: "IX_KEGIATANUNIT_UnitOrganisasiId",
                table: "KEGIATANUNIT",
                column: "UnitOrganisasiId");

            migrationBuilder.CreateIndex(
                name: "IX_KEGIATANUNIT_TahapanId_ProgramUnitId_UnitOrganisasiId",
                table: "KEGIATANUNIT",
                columns: new[] { "TahapanId", "ProgramUnitId", "UnitOrganisasiId" });

            migrationBuilder.CreateIndex(
                name: "IX_PROGRAMUNIT_ProgramId",
                table: "PROGRAMUNIT",
                column: "ProgramId");

            migrationBuilder.CreateIndex(
                name: "IX_PROGRAMUNIT_UnitOrganisasiId",
                table: "PROGRAMUNIT",
                column: "UnitOrganisasiId");

            migrationBuilder.CreateIndex(
                name: "IX_PROGRAMUNIT_TahapanId_ProgramId_UnitOrganisasiId",
                table: "PROGRAMUNIT",
                columns: new[] { "TahapanId", "ProgramId", "UnitOrganisasiId" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Tahapan_ParentId",
                table: "Tahapan",
                column: "ParentId");

            migrationBuilder.CreateIndex(
                name: "IX_Tahapan_Kode_Nama",
                table: "Tahapan",
                columns: new[] { "Kode", "Nama" },
                unique: true,
                filter: "[Nama] IS NOT NULL");

            migrationBuilder.AddForeignKey(
                name: "FK_SPP_MKEGIATAN_KegiatanId",
                table: "SPP",
                column: "KegiatanId",
                principalTable: "MKEGIATAN",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SPP_MKEGIATAN_KegiatanId",
                table: "SPP");

            migrationBuilder.DropTable(
                name: "KEGIATANUNIT");

            migrationBuilder.DropTable(
                name: "PROGRAMUNIT");

            migrationBuilder.DropTable(
                name: "Tahapan");

            migrationBuilder.DropIndex(
                name: "IX_SPP_KegiatanId",
                table: "SPP");

            migrationBuilder.DropColumn(
                name: "KegiatanId",
                table: "SPP");

            migrationBuilder.DropColumn(
                name: "Lvl",
                table: "MKEGIATAN");

            migrationBuilder.DropColumn(
                name: "Tipe",
                table: "MKEGIATAN");
        }
    }
}
