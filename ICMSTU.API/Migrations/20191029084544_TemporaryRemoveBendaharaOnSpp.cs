using Microsoft.EntityFrameworkCore.Migrations;

namespace ICMSTU.API.Migrations
{
    public partial class TemporaryRemoveBendaharaOnSpp : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SPP_BENDAHARA_BendaharaId",
                table: "SPP");

            migrationBuilder.DropIndex(
                name: "IX_SPP_BendaharaId",
                table: "SPP");

            migrationBuilder.DropColumn(
                name: "BendaharaId",
                table: "SPP");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "BendaharaId",
                table: "SPP",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_SPP_BendaharaId",
                table: "SPP",
                column: "BendaharaId");

            migrationBuilder.AddForeignKey(
                name: "FK_SPP_BENDAHARA_BendaharaId",
                table: "SPP",
                column: "BendaharaId",
                principalTable: "BENDAHARA",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
