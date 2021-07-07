using Microsoft.EntityFrameworkCore.Migrations;

namespace ASPNetCoreEFCoreFacit.Migrations
{
    public partial class userregistration2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CountryId",
                table: "UserRegistrations",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "UserType",
                table: "UserRegistrations",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Countries",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Namn = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Countries", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_UserRegistrations_CountryId",
                table: "UserRegistrations",
                column: "CountryId");

            migrationBuilder.AddForeignKey(
                name: "FK_UserRegistrations_Countries_CountryId",
                table: "UserRegistrations",
                column: "CountryId",
                principalTable: "Countries",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserRegistrations_Countries_CountryId",
                table: "UserRegistrations");

            migrationBuilder.DropTable(
                name: "Countries");

            migrationBuilder.DropIndex(
                name: "IX_UserRegistrations_CountryId",
                table: "UserRegistrations");

            migrationBuilder.DropColumn(
                name: "CountryId",
                table: "UserRegistrations");

            migrationBuilder.DropColumn(
                name: "UserType",
                table: "UserRegistrations");
        }
    }
}
