using Microsoft.EntityFrameworkCore.Migrations;

namespace ICMSTU.API.Migrations
{
  public partial class AddStrukturUnit : Migration
  {
    protected override void Up(MigrationBuilder migrationBuilder)
    {
      migrationBuilder.CreateTable(
          name: "STRUKTURUNIT",
          columns: table => new
          {
            Id = table.Column<int>(nullable: false),
            Nama = table.Column<string>(nullable: true)
          },
          constraints: table =>
          {
            table.PrimaryKey("PK_STRUKTURUNIT", x => x.Id);
          });
    }

    protected override void Down(MigrationBuilder migrationBuilder)
    {
      migrationBuilder.DropTable(
          name: "STRUKTURUNIT");
    }
  }
}
