using Microsoft.EntityFrameworkCore.Migrations;

namespace ASPNetCoreEFCoreFacit.Migrations
{
    public partial class cvs : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CVs",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Email = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Bil = table.Column<bool>(type: "bit", nullable: false),
                    Korkort = table.Column<bool>(type: "bit", nullable: false),
                    Postort = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Postnr = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: true),
                    Adress = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Mobil = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    Namn = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CVs", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CVs");
        }
    }
}
