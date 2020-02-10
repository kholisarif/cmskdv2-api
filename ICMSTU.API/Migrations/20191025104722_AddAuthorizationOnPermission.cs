using Microsoft.EntityFrameworkCore.Migrations;

namespace ICMSTU.API.Migrations
{
    public partial class AddAuthorizationOnPermission : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "Approver",
                table: "PERMISSION",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "Checker",
                table: "PERMISSION",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "Maker",
                table: "PERMISSION",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Approver",
                table: "PERMISSION");

            migrationBuilder.DropColumn(
                name: "Checker",
                table: "PERMISSION");

            migrationBuilder.DropColumn(
                name: "Maker",
                table: "PERMISSION");
        }
    }
}
