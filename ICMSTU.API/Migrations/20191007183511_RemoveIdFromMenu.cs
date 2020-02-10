using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ICMSTU.API.Migrations
{
    public partial class RemoveIdFromMenu : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MENU_MENU_ParentId",
                table: "MENU");

            migrationBuilder.DropForeignKey(
                name: "FK_PERMISSION_MENU_MenuId",
                table: "PERMISSION");

            migrationBuilder.DropForeignKey(
                name: "FK_UNITORGANISASI_UNITORGANISASI_ParentId",
                table: "UNITORGANISASI");

            migrationBuilder.DropIndex(
                name: "IX_UNITORGANISASI_ParentId",
                table: "UNITORGANISASI");

            migrationBuilder.DropPrimaryKey(
                name: "PK_MENU",
                table: "MENU");

            migrationBuilder.DropColumn(
                name: "ParentId",
                table: "UNITORGANISASI");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "MENU");

            migrationBuilder.RenameColumn(
                name: "Nama",
                table: "MENU",
                newName: "Resource");

            migrationBuilder.AddColumn<int>(
                name: "MenuId",
                table: "MENU",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            migrationBuilder.AddColumn<string>(
                name: "Kode",
                table: "MENU",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Label",
                table: "MENU",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_MENU",
                table: "MENU",
                column: "MenuId");

            migrationBuilder.CreateIndex(
                name: "IX_MENU_Kode",
                table: "MENU",
                column: "Kode",
                unique: true,
                filter: "[Kode] IS NOT NULL");

            migrationBuilder.AddForeignKey(
                name: "FK_MENU_MENU_ParentId",
                table: "MENU",
                column: "ParentId",
                principalTable: "MENU",
                principalColumn: "MenuId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_PERMISSION_MENU_MenuId",
                table: "PERMISSION",
                column: "MenuId",
                principalTable: "MENU",
                principalColumn: "MenuId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MENU_MENU_ParentId",
                table: "MENU");

            migrationBuilder.DropForeignKey(
                name: "FK_PERMISSION_MENU_MenuId",
                table: "PERMISSION");

            migrationBuilder.DropPrimaryKey(
                name: "PK_MENU",
                table: "MENU");

            migrationBuilder.DropIndex(
                name: "IX_MENU_Kode",
                table: "MENU");

            migrationBuilder.DropColumn(
                name: "MenuId",
                table: "MENU");

            migrationBuilder.DropColumn(
                name: "Kode",
                table: "MENU");

            migrationBuilder.DropColumn(
                name: "Label",
                table: "MENU");

            migrationBuilder.RenameColumn(
                name: "Resource",
                table: "MENU",
                newName: "Nama");

            migrationBuilder.AddColumn<int>(
                name: "ParentId",
                table: "UNITORGANISASI",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "MENU",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddPrimaryKey(
                name: "PK_MENU",
                table: "MENU",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_UNITORGANISASI_ParentId",
                table: "UNITORGANISASI",
                column: "ParentId");

            migrationBuilder.AddForeignKey(
                name: "FK_MENU_MENU_ParentId",
                table: "MENU",
                column: "ParentId",
                principalTable: "MENU",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_PERMISSION_MENU_MenuId",
                table: "PERMISSION",
                column: "MenuId",
                principalTable: "MENU",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UNITORGANISASI_UNITORGANISASI_ParentId",
                table: "UNITORGANISASI",
                column: "ParentId",
                principalTable: "UNITORGANISASI",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
