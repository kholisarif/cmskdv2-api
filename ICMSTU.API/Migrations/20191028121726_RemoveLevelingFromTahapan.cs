using Microsoft.EntityFrameworkCore.Migrations;

namespace ICMSTU.API.Migrations
{
    public partial class RemoveLevelingFromTahapan : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TAHAPAN_TAHAPAN_ParentId",
                table: "TAHAPAN");

            migrationBuilder.DropIndex(
                name: "IX_TAHAPAN_ParentId",
                table: "TAHAPAN");

            migrationBuilder.DropColumn(
                name: "Lvl",
                table: "TAHAPAN");

            migrationBuilder.DropColumn(
                name: "ParentId",
                table: "TAHAPAN");

            migrationBuilder.DropColumn(
                name: "Tipe",
                table: "TAHAPAN");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Lvl",
                table: "TAHAPAN",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "ParentId",
                table: "TAHAPAN",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Tipe",
                table: "TAHAPAN",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_TAHAPAN_ParentId",
                table: "TAHAPAN",
                column: "ParentId");

            migrationBuilder.AddForeignKey(
                name: "FK_TAHAPAN_TAHAPAN_ParentId",
                table: "TAHAPAN",
                column: "ParentId",
                principalTable: "TAHAPAN",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
