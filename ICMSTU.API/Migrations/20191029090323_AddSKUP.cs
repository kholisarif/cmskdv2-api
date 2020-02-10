using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ICMSTU.API.Migrations
{
    public partial class AddSKUP : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "SKUP",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    NoSK = table.Column<string>(nullable: true),
                    TglSK = table.Column<DateTime>(nullable: true),
                    Keperluan = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SKUP", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SKUPDET",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    SKUPId = table.Column<int>(nullable: false),
                    UnitOrganisasiId = table.Column<int>(nullable: false),
                    Nilai = table.Column<decimal>(type: "decimal(18, 2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SKUPDET", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SKUPDET_SKUP_SKUPId",
                        column: x => x.SKUPId,
                        principalTable: "SKUP",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SKUPDET_UNITORGANISASI_UnitOrganisasiId",
                        column: x => x.UnitOrganisasiId,
                        principalTable: "UNITORGANISASI",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_SKUP_NoSK",
                table: "SKUP",
                column: "NoSK",
                unique: true,
                filter: "[NoSK] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_SKUPDET_UnitOrganisasiId",
                table: "SKUPDET",
                column: "UnitOrganisasiId");

            migrationBuilder.CreateIndex(
                name: "IX_SKUPDET_SKUPId_UnitOrganisasiId",
                table: "SKUPDET",
                columns: new[] { "SKUPId", "UnitOrganisasiId" },
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SKUPDET");

            migrationBuilder.DropTable(
                name: "SKUP");
        }
    }
}
