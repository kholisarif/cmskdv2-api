using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ICMSTU.API.Migrations
{
    public partial class AddBank : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "BANK",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    NamaLengkap = table.Column<string>(nullable: true),
                    Nama = table.Column<string>(nullable: true),
                    KodeBank = table.Column<string>(nullable: true),
                    KodeSKN = table.Column<string>(nullable: true),
                    KodeRTGS = table.Column<string>(nullable: true),
                    KodeKota = table.Column<string>(nullable: true),
                    KodeSwift = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BANK", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_BANK_KodeBank_Nama",
                table: "BANK",
                columns: new[] { "KodeBank", "Nama" },
                unique: true,
                filter: "[KodeBank] IS NOT NULL AND [Nama] IS NOT NULL");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BANK");
        }
    }
}
