using Microsoft.EntityFrameworkCore.Migrations;

namespace ICMSTU.API.Migrations
{
    public partial class AlterNamaAsUniqueIndexOnJnsTransaksi : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_JNSTRANSAKSI_Kode",
                table: "JNSTRANSAKSI");

            migrationBuilder.AlterColumn<string>(
                name: "Nama",
                table: "JNSTRANSAKSI",
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_JNSTRANSAKSI_Kode_Nama",
                table: "JNSTRANSAKSI",
                columns: new[] { "Kode", "Nama" },
                unique: true,
                filter: "[Kode] IS NOT NULL AND [Nama] IS NOT NULL");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_JNSTRANSAKSI_Kode_Nama",
                table: "JNSTRANSAKSI");

            migrationBuilder.AlterColumn<string>(
                name: "Nama",
                table: "JNSTRANSAKSI",
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_JNSTRANSAKSI_Kode",
                table: "JNSTRANSAKSI",
                column: "Kode",
                unique: true,
                filter: "[Kode] IS NOT NULL");
        }
    }
}
