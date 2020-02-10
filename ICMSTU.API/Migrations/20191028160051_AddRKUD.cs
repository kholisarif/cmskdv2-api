using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ICMSTU.API.Migrations
{
    public partial class AddRKUD : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "RKUD",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    BankId = table.Column<int>(nullable: false),
                    NamaRekening = table.Column<string>(nullable: true),
                    NoRekening = table.Column<string>(nullable: true),
                    SaldoAwal = table.Column<decimal>(type: "decimal(18, 2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RKUD", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RKUD_BANK_BankId",
                        column: x => x.BankId,
                        principalTable: "BANK",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_RKUD_BankId_NamaRekening_NoRekening",
                table: "RKUD",
                columns: new[] { "BankId", "NamaRekening", "NoRekening" },
                unique: true,
                filter: "[NamaRekening] IS NOT NULL AND [NoRekening] IS NOT NULL");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "RKUD");
        }
    }
}
