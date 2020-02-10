using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ICMSTU.API.Migrations
{
    public partial class AddProgramKegiatan : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "MPROGRAM",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    UrusanId = table.Column<int>(nullable: true),
                    Kode = table.Column<string>(nullable: true),
                    Nama = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MPROGRAM", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MPROGRAM_UNITORGANISASI_UrusanId",
                        column: x => x.UrusanId,
                        principalTable: "UNITORGANISASI",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "MKEGIATAN",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ProgramId = table.Column<int>(nullable: false),
                    Kode = table.Column<string>(nullable: true),
                    Nama = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MKEGIATAN", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MKEGIATAN_MPROGRAM_ProgramId",
                        column: x => x.ProgramId,
                        principalTable: "MPROGRAM",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_MKEGIATAN_ProgramId_Kode_Nama",
                table: "MKEGIATAN",
                columns: new[] { "ProgramId", "Kode", "Nama" },
                unique: true,
                filter: "[Kode] IS NOT NULL AND [Nama] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_MPROGRAM_UrusanId_Kode_Nama",
                table: "MPROGRAM",
                columns: new[] { "UrusanId", "Kode", "Nama" },
                unique: true,
                filter: "[UrusanId] IS NOT NULL AND [Kode] IS NOT NULL AND [Nama] IS NOT NULL");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MKEGIATAN");

            migrationBuilder.DropTable(
                name: "MPROGRAM");
        }
    }
}
