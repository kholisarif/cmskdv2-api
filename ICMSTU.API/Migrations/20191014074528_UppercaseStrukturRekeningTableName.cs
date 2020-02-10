using Microsoft.EntityFrameworkCore.Migrations;

namespace ICMSTU.API.Migrations
{
    public partial class UppercaseStrukturRekeningTableName : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_StrukturRekening",
                table: "StrukturRekening");

            migrationBuilder.RenameTable(
                name: "StrukturRekening",
                newName: "STUKTURREKENING");

            migrationBuilder.AddPrimaryKey(
                name: "PK_STUKTURREKENING",
                table: "STUKTURREKENING",
                column: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_STUKTURREKENING",
                table: "STUKTURREKENING");

            migrationBuilder.RenameTable(
                name: "STUKTURREKENING",
                newName: "StrukturRekening");

            migrationBuilder.AddPrimaryKey(
                name: "PK_StrukturRekening",
                table: "StrukturRekening",
                column: "Id");
        }
    }
}
