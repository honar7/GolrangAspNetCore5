using Microsoft.EntityFrameworkCore.Migrations;

namespace Session05.OOConfig.Migrations
{
    public partial class owned3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "City",
                table: "People");

            migrationBuilder.DropColumn(
                name: "Phone",
                table: "People");

            migrationBuilder.DropColumn(
                name: "Proviance",
                table: "People");

            migrationBuilder.DropColumn(
                name: "Street",
                table: "People");

            migrationBuilder.CreateTable(
                name: "Address",
                columns: table => new
                {
                    PersonId = table.Column<int>(type: "int", nullable: false),
                    Proviance = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    City = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Street = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Phone = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Address", x => x.PersonId);
                    table.ForeignKey(
                        name: "FK_Address_People_PersonId",
                        column: x => x.PersonId,
                        principalTable: "People",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Address");

            migrationBuilder.AddColumn<string>(
                name: "City",
                table: "People",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Phone",
                table: "People",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Proviance",
                table: "People",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Street",
                table: "People",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
