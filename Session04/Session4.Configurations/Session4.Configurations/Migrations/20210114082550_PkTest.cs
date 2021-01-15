using Microsoft.EntityFrameworkCore.Migrations;

namespace Session4.Configurations.Migrations
{
    public partial class PkTest : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "PkTestFluent",
                columns: table => new
                {
                    Pk01 = table.Column<int>(type: "int", nullable: false),
                    Pk02 = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PkTestFluent", x => new { x.Pk01, x.Pk02 });
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PkTestFluent");
        }
    }
}
