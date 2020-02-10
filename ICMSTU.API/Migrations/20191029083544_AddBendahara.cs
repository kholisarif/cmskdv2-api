using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ICMSTU.API.Migrations
{
    public partial class AddBendahara : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "JNSBEND",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Nama = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_JNSBEND", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Bendahara",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    NoSK = table.Column<string>(nullable: true),
                    UnitOrganisasiId = table.Column<int>(nullable: false),
                    JnsBendId = table.Column<int>(nullable: false),
                    PegawaiId = table.Column<string>(nullable: true),
                    PegawaiId1 = table.Column<int>(nullable: true),
                    BankId = table.Column<int>(nullable: false),
                    KodeRekening = table.Column<string>(nullable: true),
                    NPWP = table.Column<string>(nullable: true),
                    SaldoBend = table.Column<decimal>(type: "decimal(18, 2)", nullable: false),
                    SaldoBendt = table.Column<decimal>(type: "decimal(18, 2)", nullable: false),
                    TglAwal = table.Column<DateTime>(nullable: true),
                    TglAkhir = table.Column<DateTime>(nullable: true),
                    StatusAktif = table.Column<bool>(nullable: false),
                    TglNonAktif = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Bendahara", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Bendahara_BANK_BankId",
                        column: x => x.BankId,
                        principalTable: "BANK",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Bendahara_JNSBEND_JnsBendId",
                        column: x => x.JnsBendId,
                        principalTable: "JNSBEND",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Bendahara_PEGAWAI_PegawaiId1",
                        column: x => x.PegawaiId1,
                        principalTable: "PEGAWAI",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Bendahara_UNITORGANISASI_UnitOrganisasiId",
                        column: x => x.UnitOrganisasiId,
                        principalTable: "UNITORGANISASI",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Bendahara_BankId",
                table: "Bendahara",
                column: "BankId");

            migrationBuilder.CreateIndex(
                name: "IX_Bendahara_JnsBendId",
                table: "Bendahara",
                column: "JnsBendId");

            migrationBuilder.CreateIndex(
                name: "IX_Bendahara_PegawaiId1",
                table: "Bendahara",
                column: "PegawaiId1");

            migrationBuilder.CreateIndex(
                name: "IX_Bendahara_UnitOrganisasiId",
                table: "Bendahara",
                column: "UnitOrganisasiId");

            migrationBuilder.CreateIndex(
                name: "IX_Bendahara_NoSK_UnitOrganisasiId_BankId_JnsBendId_PegawaiId",
                table: "Bendahara",
                columns: new[] { "NoSK", "UnitOrganisasiId", "BankId", "JnsBendId", "PegawaiId" });

            migrationBuilder.CreateIndex(
                name: "IX_JNSBEND_Nama",
                table: "JNSBEND",
                column: "Nama",
                unique: true,
                filter: "[Nama] IS NOT NULL");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Bendahara");

            migrationBuilder.DropTable(
                name: "JNSBEND");
        }
    }
}
