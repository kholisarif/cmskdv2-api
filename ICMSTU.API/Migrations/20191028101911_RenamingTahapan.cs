using Microsoft.EntityFrameworkCore.Migrations;

namespace ICMSTU.API.Migrations
{
    public partial class RenamingTahapan : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_KEGIATANUNIT_Tahapan_TahapanId",
                table: "KEGIATANUNIT");

            migrationBuilder.DropForeignKey(
                name: "FK_PROGRAMUNIT_Tahapan_TahapanId",
                table: "PROGRAMUNIT");

            migrationBuilder.DropForeignKey(
                name: "FK_Tahapan_Tahapan_ParentId",
                table: "Tahapan");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Tahapan",
                table: "Tahapan");

            migrationBuilder.RenameTable(
                name: "Tahapan",
                newName: "TAHAPAN");

            migrationBuilder.RenameIndex(
                name: "IX_Tahapan_Kode_Nama",
                table: "TAHAPAN",
                newName: "IX_TAHAPAN_Kode_Nama");

            migrationBuilder.RenameIndex(
                name: "IX_Tahapan_ParentId",
                table: "TAHAPAN",
                newName: "IX_TAHAPAN_ParentId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_TAHAPAN",
                table: "TAHAPAN",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_KEGIATANUNIT_TAHAPAN_TahapanId",
                table: "KEGIATANUNIT",
                column: "TahapanId",
                principalTable: "TAHAPAN",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_PROGRAMUNIT_TAHAPAN_TahapanId",
                table: "PROGRAMUNIT",
                column: "TahapanId",
                principalTable: "TAHAPAN",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_TAHAPAN_TAHAPAN_ParentId",
                table: "TAHAPAN",
                column: "ParentId",
                principalTable: "TAHAPAN",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_KEGIATANUNIT_TAHAPAN_TahapanId",
                table: "KEGIATANUNIT");

            migrationBuilder.DropForeignKey(
                name: "FK_PROGRAMUNIT_TAHAPAN_TahapanId",
                table: "PROGRAMUNIT");

            migrationBuilder.DropForeignKey(
                name: "FK_TAHAPAN_TAHAPAN_ParentId",
                table: "TAHAPAN");

            migrationBuilder.DropPrimaryKey(
                name: "PK_TAHAPAN",
                table: "TAHAPAN");

            migrationBuilder.RenameTable(
                name: "TAHAPAN",
                newName: "Tahapan");

            migrationBuilder.RenameIndex(
                name: "IX_TAHAPAN_Kode_Nama",
                table: "Tahapan",
                newName: "IX_Tahapan_Kode_Nama");

            migrationBuilder.RenameIndex(
                name: "IX_TAHAPAN_ParentId",
                table: "Tahapan",
                newName: "IX_Tahapan_ParentId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Tahapan",
                table: "Tahapan",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_KEGIATANUNIT_Tahapan_TahapanId",
                table: "KEGIATANUNIT",
                column: "TahapanId",
                principalTable: "Tahapan",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_PROGRAMUNIT_Tahapan_TahapanId",
                table: "PROGRAMUNIT",
                column: "TahapanId",
                principalTable: "Tahapan",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Tahapan_Tahapan_ParentId",
                table: "Tahapan",
                column: "ParentId",
                principalTable: "Tahapan",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
