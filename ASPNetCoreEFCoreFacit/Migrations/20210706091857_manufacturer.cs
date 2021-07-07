using Microsoft.EntityFrameworkCore.Migrations;

namespace ASPNetCoreEFCoreFacit.Migrations
{
    public partial class manufacturer : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Manufacturer",
                table: "Lastbilar");

            migrationBuilder.DropColumn(
                name: "Manufacturer",
                table: "Bilar");

            migrationBuilder.AddColumn<int>(
                name: "ManufacturerId",
                table: "Lastbilar",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ManufacturerId",
                table: "Bilar",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Manufacturers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Namn = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Manufacturers", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Lastbilar_ManufacturerId",
                table: "Lastbilar",
                column: "ManufacturerId");

            migrationBuilder.CreateIndex(
                name: "IX_Bilar_ManufacturerId",
                table: "Bilar",
                column: "ManufacturerId");

            migrationBuilder.AddForeignKey(
                name: "FK_Bilar_Manufacturers_ManufacturerId",
                table: "Bilar",
                column: "ManufacturerId",
                principalTable: "Manufacturers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Lastbilar_Manufacturers_ManufacturerId",
                table: "Lastbilar",
                column: "ManufacturerId",
                principalTable: "Manufacturers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Bilar_Manufacturers_ManufacturerId",
                table: "Bilar");

            migrationBuilder.DropForeignKey(
                name: "FK_Lastbilar_Manufacturers_ManufacturerId",
                table: "Lastbilar");

            migrationBuilder.DropTable(
                name: "Manufacturers");

            migrationBuilder.DropIndex(
                name: "IX_Lastbilar_ManufacturerId",
                table: "Lastbilar");

            migrationBuilder.DropIndex(
                name: "IX_Bilar_ManufacturerId",
                table: "Bilar");

            migrationBuilder.DropColumn(
                name: "ManufacturerId",
                table: "Lastbilar");

            migrationBuilder.DropColumn(
                name: "ManufacturerId",
                table: "Bilar");

            migrationBuilder.AddColumn<string>(
                name: "Manufacturer",
                table: "Lastbilar",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Manufacturer",
                table: "Bilar",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: true);
        }
    }
}
