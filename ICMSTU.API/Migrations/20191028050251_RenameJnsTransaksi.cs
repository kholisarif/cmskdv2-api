using Microsoft.EntityFrameworkCore.Migrations;

namespace ICMSTU.API.Migrations
{
    public partial class RenameJnsTransaksi : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SPP_JnsTransaksi_JnsTransaksiId",
                table: "SPP");

            migrationBuilder.DropPrimaryKey(
                name: "PK_JnsTransaksi",
                table: "JnsTransaksi");

            migrationBuilder.RenameTable(
                name: "JnsTransaksi",
                newName: "JNSTRANSAKSI");

            migrationBuilder.RenameIndex(
                name: "IX_JnsTransaksi_Kode",
                table: "JNSTRANSAKSI",
                newName: "IX_JNSTRANSAKSI_Kode");

            migrationBuilder.AddPrimaryKey(
                name: "PK_JNSTRANSAKSI",
                table: "JNSTRANSAKSI",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_SPP_JNSTRANSAKSI_JnsTransaksiId",
                table: "SPP",
                column: "JnsTransaksiId",
                principalTable: "JNSTRANSAKSI",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SPP_JNSTRANSAKSI_JnsTransaksiId",
                table: "SPP");

            migrationBuilder.DropPrimaryKey(
                name: "PK_JNSTRANSAKSI",
                table: "JNSTRANSAKSI");

            migrationBuilder.RenameTable(
                name: "JNSTRANSAKSI",
                newName: "JnsTransaksi");

            migrationBuilder.RenameIndex(
                name: "IX_JNSTRANSAKSI_Kode",
                table: "JnsTransaksi",
                newName: "IX_JnsTransaksi_Kode");

            migrationBuilder.AddPrimaryKey(
                name: "PK_JnsTransaksi",
                table: "JnsTransaksi",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_SPP_JnsTransaksi_JnsTransaksiId",
                table: "SPP",
                column: "JnsTransaksiId",
                principalTable: "JnsTransaksi",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
