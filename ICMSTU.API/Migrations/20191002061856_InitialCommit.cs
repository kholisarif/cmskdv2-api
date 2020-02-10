using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ICMSTU.API.Migrations
{
    public partial class InitialCommit : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "GOLONGAN",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Kode = table.Column<string>(nullable: true),
                    Pangkat = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GOLONGAN", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "MENU",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false),
                    ParentId = table.Column<int>(nullable: true),
                    Nama = table.Column<string>(nullable: true),
                    RouterLink = table.Column<string>(nullable: true),
                    QueryParams = table.Column<string>(nullable: true),
                    Configuration = table.Column<string>(nullable: true),
                    Lvl = table.Column<int>(nullable: false),
                    Tipe = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MENU", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MENU_MENU_ParentId",
                        column: x => x.ParentId,
                        principalTable: "MENU",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ROLE",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Nama = table.Column<string>(nullable: true),
                    Deskripsi = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ROLE", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TAHUN",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Nilai = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TAHUN", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "UNITORGANISASI",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ParentId = table.Column<int>(nullable: true),
                    Lvl = table.Column<int>(nullable: false),
                    Kode = table.Column<string>(nullable: true),
                    Nama = table.Column<string>(nullable: true),
                    Akronim = table.Column<string>(nullable: true),
                    Alamat = table.Column<string>(nullable: true),
                    Telepon = table.Column<string>(nullable: true),
                    Tipe = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UNITORGANISASI", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UNITORGANISASI_UNITORGANISASI_ParentId",
                        column: x => x.ParentId,
                        principalTable: "UNITORGANISASI",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "PEGAWAI",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Nip = table.Column<string>(nullable: true),
                    Nama = table.Column<string>(nullable: true),
                    GolonganId = table.Column<int>(nullable: false),
                    Alamat = table.Column<string>(nullable: true),
                    Jabatan = table.Column<string>(nullable: true),
                    Pendidikan = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PEGAWAI", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PEGAWAI_GOLONGAN_GolonganId",
                        column: x => x.GolonganId,
                        principalTable: "GOLONGAN",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PERMISSION",
                columns: table => new
                {
                    RoleId = table.Column<int>(nullable: false),
                    MenuId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PERMISSION", x => new { x.RoleId, x.MenuId });
                    table.ForeignKey(
                        name: "FK_PERMISSION_MENU_MenuId",
                        column: x => x.MenuId,
                        principalTable: "MENU",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PERMISSION_ROLE_RoleId",
                        column: x => x.RoleId,
                        principalTable: "ROLE",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "USER",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Username = table.Column<string>(nullable: true),
                    UnitOrganisasiId = table.Column<int>(nullable: true),
                    PegawaiId = table.Column<int>(nullable: true),
                    Password = table.Column<string>(nullable: true),
                    FalseLoginCount = table.Column<byte>(nullable: false),
                    LockedOut = table.Column<bool>(nullable: false),
                    Deskripsi = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_USER", x => x.Id);
                    table.ForeignKey(
                        name: "FK_USER_PEGAWAI_PegawaiId",
                        column: x => x.PegawaiId,
                        principalTable: "PEGAWAI",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_USER_UNITORGANISASI_UnitOrganisasiId",
                        column: x => x.UnitOrganisasiId,
                        principalTable: "UNITORGANISASI",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "USERROLE",
                columns: table => new
                {
                    UserId = table.Column<int>(nullable: false),
                    RoleId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_USERROLE", x => new { x.RoleId, x.UserId });
                    table.ForeignKey(
                        name: "FK_USERROLE_ROLE_RoleId",
                        column: x => x.RoleId,
                        principalTable: "ROLE",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_USERROLE_USER_UserId",
                        column: x => x.UserId,
                        principalTable: "USER",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "ROLE",
                columns: new[] { "Id", "Deskripsi", "Nama" },
                values: new object[] { 1, "System Administrator", "admin" });

            migrationBuilder.InsertData(
                table: "TAHUN",
                columns: new[] { "Id", "Nilai" },
                values: new object[] { 1, 2019 });

            migrationBuilder.InsertData(
                table: "TAHUN",
                columns: new[] { "Id", "Nilai" },
                values: new object[] { 2, 2020 });

            migrationBuilder.CreateIndex(
                name: "IX_MENU_ParentId",
                table: "MENU",
                column: "ParentId");

            migrationBuilder.CreateIndex(
                name: "IX_PEGAWAI_GolonganId",
                table: "PEGAWAI",
                column: "GolonganId");

            migrationBuilder.CreateIndex(
                name: "IX_PERMISSION_MenuId",
                table: "PERMISSION",
                column: "MenuId");

            migrationBuilder.CreateIndex(
                name: "IX_TAHUN_Nilai",
                table: "TAHUN",
                column: "Nilai",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_UNITORGANISASI_ParentId",
                table: "UNITORGANISASI",
                column: "ParentId");

            migrationBuilder.CreateIndex(
                name: "IX_UNITORGANISASI_Kode_Nama",
                table: "UNITORGANISASI",
                columns: new[] { "Kode", "Nama" },
                unique: true,
                filter: "[Kode] IS NOT NULL AND [Nama] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_USER_PegawaiId",
                table: "USER",
                column: "PegawaiId");

            migrationBuilder.CreateIndex(
                name: "IX_USER_UnitOrganisasiId",
                table: "USER",
                column: "UnitOrganisasiId");

            migrationBuilder.CreateIndex(
                name: "IX_USER_Username",
                table: "USER",
                column: "Username",
                unique: true,
                filter: "[Username] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_USERROLE_UserId",
                table: "USERROLE",
                column: "UserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PERMISSION");

            migrationBuilder.DropTable(
                name: "TAHUN");

            migrationBuilder.DropTable(
                name: "USERROLE");

            migrationBuilder.DropTable(
                name: "MENU");

            migrationBuilder.DropTable(
                name: "ROLE");

            migrationBuilder.DropTable(
                name: "USER");

            migrationBuilder.DropTable(
                name: "PEGAWAI");

            migrationBuilder.DropTable(
                name: "UNITORGANISASI");

            migrationBuilder.DropTable(
                name: "GOLONGAN");
        }
    }
}
