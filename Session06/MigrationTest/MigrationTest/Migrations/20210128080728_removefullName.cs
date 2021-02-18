using Microsoft.EntityFrameworkCore.Migrations;

namespace MigrationTest.Migrations
{
    public partial class removefullName : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FullName",
                table: "People");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "FullName",
                table: "People",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
