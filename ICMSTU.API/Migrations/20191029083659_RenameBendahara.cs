using Microsoft.EntityFrameworkCore.Migrations;

namespace ICMSTU.API.Migrations
{
    public partial class RenameBendahara : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Bendahara_BANK_BankId",
                table: "Bendahara");

            migrationBuilder.DropForeignKey(
                name: "FK_Bendahara_JNSBEND_JnsBendId",
                table: "Bendahara");

            migrationBuilder.DropForeignKey(
                name: "FK_Bendahara_PEGAWAI_PegawaiId1",
                table: "Bendahara");

            migrationBuilder.DropForeignKey(
                name: "FK_Bendahara_UNITORGANISASI_UnitOrganisasiId",
                table: "Bendahara");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Bendahara",
                table: "Bendahara");

            migrationBuilder.RenameTable(
                name: "Bendahara",
                newName: "BENDAHARA");

            migrationBuilder.RenameIndex(
                name: "IX_Bendahara_NoSK_UnitOrganisasiId_BankId_JnsBendId_PegawaiId",
                table: "BENDAHARA",
                newName: "IX_BENDAHARA_NoSK_UnitOrganisasiId_BankId_JnsBendId_PegawaiId");

            migrationBuilder.RenameIndex(
                name: "IX_Bendahara_UnitOrganisasiId",
                table: "BENDAHARA",
                newName: "IX_BENDAHARA_UnitOrganisasiId");

            migrationBuilder.RenameIndex(
                name: "IX_Bendahara_PegawaiId1",
                table: "BENDAHARA",
                newName: "IX_BENDAHARA_PegawaiId1");

            migrationBuilder.RenameIndex(
                name: "IX_Bendahara_JnsBendId",
                table: "BENDAHARA",
                newName: "IX_BENDAHARA_JnsBendId");

            migrationBuilder.RenameIndex(
                name: "IX_Bendahara_BankId",
                table: "BENDAHARA",
                newName: "IX_BENDAHARA_BankId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_BENDAHARA",
                table: "BENDAHARA",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_BENDAHARA_BANK_BankId",
                table: "BENDAHARA",
                column: "BankId",
                principalTable: "BANK",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_BENDAHARA_JNSBEND_JnsBendId",
                table: "BENDAHARA",
                column: "JnsBendId",
                principalTable: "JNSBEND",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_BENDAHARA_PEGAWAI_PegawaiId1",
                table: "BENDAHARA",
                column: "PegawaiId1",
                principalTable: "PEGAWAI",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_BENDAHARA_UNITORGANISASI_UnitOrganisasiId",
                table: "BENDAHARA",
                column: "UnitOrganisasiId",
                principalTable: "UNITORGANISASI",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BENDAHARA_BANK_BankId",
                table: "BENDAHARA");

            migrationBuilder.DropForeignKey(
                name: "FK_BENDAHARA_JNSBEND_JnsBendId",
                table: "BENDAHARA");

            migrationBuilder.DropForeignKey(
                name: "FK_BENDAHARA_PEGAWAI_PegawaiId1",
                table: "BENDAHARA");

            migrationBuilder.DropForeignKey(
                name: "FK_BENDAHARA_UNITORGANISASI_UnitOrganisasiId",
                table: "BENDAHARA");

            migrationBuilder.DropPrimaryKey(
                name: "PK_BENDAHARA",
                table: "BENDAHARA");

            migrationBuilder.RenameTable(
                name: "BENDAHARA",
                newName: "Bendahara");

            migrationBuilder.RenameIndex(
                name: "IX_BENDAHARA_NoSK_UnitOrganisasiId_BankId_JnsBendId_PegawaiId",
                table: "Bendahara",
                newName: "IX_Bendahara_NoSK_UnitOrganisasiId_BankId_JnsBendId_PegawaiId");

            migrationBuilder.RenameIndex(
                name: "IX_BENDAHARA_UnitOrganisasiId",
                table: "Bendahara",
                newName: "IX_Bendahara_UnitOrganisasiId");

            migrationBuilder.RenameIndex(
                name: "IX_BENDAHARA_PegawaiId1",
                table: "Bendahara",
                newName: "IX_Bendahara_PegawaiId1");

            migrationBuilder.RenameIndex(
                name: "IX_BENDAHARA_JnsBendId",
                table: "Bendahara",
                newName: "IX_Bendahara_JnsBendId");

            migrationBuilder.RenameIndex(
                name: "IX_BENDAHARA_BankId",
                table: "Bendahara",
                newName: "IX_Bendahara_BankId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Bendahara",
                table: "Bendahara",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Bendahara_BANK_BankId",
                table: "Bendahara",
                column: "BankId",
                principalTable: "BANK",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Bendahara_JNSBEND_JnsBendId",
                table: "Bendahara",
                column: "JnsBendId",
                principalTable: "JNSBEND",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Bendahara_PEGAWAI_PegawaiId1",
                table: "Bendahara",
                column: "PegawaiId1",
                principalTable: "PEGAWAI",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Bendahara_UNITORGANISASI_UnitOrganisasiId",
                table: "Bendahara",
                column: "UnitOrganisasiId",
                principalTable: "UNITORGANISASI",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
