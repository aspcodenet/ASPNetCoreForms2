using Microsoft.EntityFrameworkCore.Migrations;

namespace ASPNetCoreEFCoreFacit.Migrations
{
    public partial class utbildningar2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Utbildningar_CVs_CVId",
                table: "Utbildningar");

            migrationBuilder.DropIndex(
                name: "IX_Utbildningar_CVId",
                table: "Utbildningar");

            migrationBuilder.DropColumn(
                name: "CVId",
                table: "Utbildningar");

            migrationBuilder.CreateTable(
                name: "CVUtbildning",
                columns: table => new
                {
                    CvsId = table.Column<int>(type: "int", nullable: false),
                    UtbildningarId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CVUtbildning", x => new { x.CvsId, x.UtbildningarId });
                    table.ForeignKey(
                        name: "FK_CVUtbildning_CVs_CvsId",
                        column: x => x.CvsId,
                        principalTable: "CVs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CVUtbildning_Utbildningar_UtbildningarId",
                        column: x => x.UtbildningarId,
                        principalTable: "Utbildningar",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CVUtbildning_UtbildningarId",
                table: "CVUtbildning",
                column: "UtbildningarId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CVUtbildning");

            migrationBuilder.AddColumn<int>(
                name: "CVId",
                table: "Utbildningar",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Utbildningar_CVId",
                table: "Utbildningar",
                column: "CVId");

            migrationBuilder.AddForeignKey(
                name: "FK_Utbildningar_CVs_CVId",
                table: "Utbildningar",
                column: "CVId",
                principalTable: "CVs",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
