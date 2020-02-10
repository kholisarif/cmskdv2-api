using Microsoft.EntityFrameworkCore.Migrations;

namespace ICMSTU.API.Migrations
{
    public partial class ReplaceKegiatanIdToKegiatanUnitId : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SPP_MKEGIATAN_KegiatanId",
                table: "SPP");

            migrationBuilder.RenameColumn(
                name: "KegiatanId",
                table: "SPP",
                newName: "KegiatanUnitId");

            migrationBuilder.RenameIndex(
                name: "IX_SPP_KegiatanId",
                table: "SPP",
                newName: "IX_SPP_KegiatanUnitId");

            migrationBuilder.AddForeignKey(
                name: "FK_SPP_KEGIATANUNIT_KegiatanUnitId",
                table: "SPP",
                column: "KegiatanUnitId",
                principalTable: "KEGIATANUNIT",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SPP_KEGIATANUNIT_KegiatanUnitId",
                table: "SPP");

            migrationBuilder.RenameColumn(
                name: "KegiatanUnitId",
                table: "SPP",
                newName: "KegiatanId");

            migrationBuilder.RenameIndex(
                name: "IX_SPP_KegiatanUnitId",
                table: "SPP",
                newName: "IX_SPP_KegiatanId");

            migrationBuilder.AddForeignKey(
                name: "FK_SPP_MKEGIATAN_KegiatanId",
                table: "SPP",
                column: "KegiatanId",
                principalTable: "MKEGIATAN",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
