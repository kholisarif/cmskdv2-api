using Microsoft.EntityFrameworkCore.Migrations;

namespace ICMSTU.API.Migrations
{
    public partial class RemoveParentIdOnMenu : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MENU_MENU_ParentId",
                table: "MENU");

            migrationBuilder.DropIndex(
                name: "IX_MENU_ParentId",
                table: "MENU");

            migrationBuilder.DropColumn(
                name: "ParentId",
                table: "MENU");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ParentId",
                table: "MENU",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_MENU_ParentId",
                table: "MENU",
                column: "ParentId");

            migrationBuilder.AddForeignKey(
                name: "FK_MENU_MENU_ParentId",
                table: "MENU",
                column: "ParentId",
                principalTable: "MENU",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
