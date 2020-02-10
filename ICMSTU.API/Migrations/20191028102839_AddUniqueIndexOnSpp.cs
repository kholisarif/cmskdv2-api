using Microsoft.EntityFrameworkCore.Migrations;

namespace ICMSTU.API.Migrations
{
    public partial class AddUniqueIndexOnSpp : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_SPP_UnitOrganisasiId",
                table: "SPP");

            migrationBuilder.AlterColumn<string>(
                name: "NoRegister",
                table: "SPP",
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_SPP_UnitOrganisasiId_JnsTransaksiId_KegiatanUnitId_NoPengajuan_NoRegister",
                table: "SPP",
                columns: new[] { "UnitOrganisasiId", "JnsTransaksiId", "KegiatanUnitId", "NoPengajuan", "NoRegister" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_SPP_UnitOrganisasiId_JnsTransaksiId_KegiatanUnitId_NoPengajuan_NoRegister",
                table: "SPP");

            migrationBuilder.AlterColumn<string>(
                name: "NoRegister",
                table: "SPP",
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_SPP_UnitOrganisasiId",
                table: "SPP",
                column: "UnitOrganisasiId");
        }
    }
}
