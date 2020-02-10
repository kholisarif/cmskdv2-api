using Microsoft.EntityFrameworkCore.Migrations;

namespace ICMSTU.API.Migrations
{
    public partial class ChangeKodeToStringTypeOnTahapan : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_TAHAPAN_Kode_Nama",
                table: "TAHAPAN");

            migrationBuilder.AlterColumn<string>(
                name: "Kode",
                table: "TAHAPAN",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.CreateIndex(
                name: "IX_TAHAPAN_Kode_Nama",
                table: "TAHAPAN",
                columns: new[] { "Kode", "Nama" },
                unique: true,
                filter: "[Kode] IS NOT NULL AND [Nama] IS NOT NULL");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_TAHAPAN_Kode_Nama",
                table: "TAHAPAN");

            migrationBuilder.AlterColumn<int>(
                name: "Kode",
                table: "TAHAPAN",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_TAHAPAN_Kode_Nama",
                table: "TAHAPAN",
                columns: new[] { "Kode", "Nama" },
                unique: true,
                filter: "[Nama] IS NOT NULL");
        }
    }
}
