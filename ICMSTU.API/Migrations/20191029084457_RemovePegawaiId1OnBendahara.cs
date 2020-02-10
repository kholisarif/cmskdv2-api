using Microsoft.EntityFrameworkCore.Migrations;

namespace ICMSTU.API.Migrations
{
    public partial class RemovePegawaiId1OnBendahara : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BENDAHARA_PEGAWAI_PegawaiId1",
                table: "BENDAHARA");

            migrationBuilder.DropIndex(
                name: "IX_BENDAHARA_PegawaiId1",
                table: "BENDAHARA");

            migrationBuilder.DropColumn(
                name: "PegawaiId1",
                table: "BENDAHARA");

            migrationBuilder.AddColumn<int>(
                name: "BendaharaId",
                table: "SPP",
                nullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "PegawaiId",
                table: "BENDAHARA",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_SPP_BendaharaId",
                table: "SPP",
                column: "BendaharaId");

            migrationBuilder.CreateIndex(
                name: "IX_BENDAHARA_PegawaiId",
                table: "BENDAHARA",
                column: "PegawaiId");

            migrationBuilder.AddForeignKey(
                name: "FK_BENDAHARA_PEGAWAI_PegawaiId",
                table: "BENDAHARA",
                column: "PegawaiId",
                principalTable: "PEGAWAI",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_SPP_BENDAHARA_BendaharaId",
                table: "SPP",
                column: "BendaharaId",
                principalTable: "BENDAHARA",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BENDAHARA_PEGAWAI_PegawaiId",
                table: "BENDAHARA");

            migrationBuilder.DropForeignKey(
                name: "FK_SPP_BENDAHARA_BendaharaId",
                table: "SPP");

            migrationBuilder.DropIndex(
                name: "IX_SPP_BendaharaId",
                table: "SPP");

            migrationBuilder.DropIndex(
                name: "IX_BENDAHARA_PegawaiId",
                table: "BENDAHARA");

            migrationBuilder.DropColumn(
                name: "BendaharaId",
                table: "SPP");

            migrationBuilder.AlterColumn<string>(
                name: "PegawaiId",
                table: "BENDAHARA",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddColumn<int>(
                name: "PegawaiId1",
                table: "BENDAHARA",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_BENDAHARA_PegawaiId1",
                table: "BENDAHARA",
                column: "PegawaiId1");

            migrationBuilder.AddForeignKey(
                name: "FK_BENDAHARA_PEGAWAI_PegawaiId1",
                table: "BENDAHARA",
                column: "PegawaiId1",
                principalTable: "PEGAWAI",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
