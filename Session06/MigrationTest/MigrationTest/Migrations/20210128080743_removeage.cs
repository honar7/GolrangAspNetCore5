using Microsoft.EntityFrameworkCore.Migrations;

namespace MigrationTest.Migrations
{
    public partial class removeage : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateUser("UName", "Passwor");
            migrationBuilder.DropColumn(
                name: "Age",
                table: "People");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Age",
                table: "People",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
