using Microsoft.EntityFrameworkCore.Migrations;

namespace Session05.OOConfig.Migrations
{
    public partial class owned2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Address_Street",
                table: "People",
                newName: "Street");

            migrationBuilder.RenameColumn(
                name: "Address_Proviance",
                table: "People",
                newName: "Proviance");

            migrationBuilder.RenameColumn(
                name: "Address_Phone",
                table: "People",
                newName: "Phone");

            migrationBuilder.RenameColumn(
                name: "Address_City",
                table: "People",
                newName: "City");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Street",
                table: "People",
                newName: "Address_Street");

            migrationBuilder.RenameColumn(
                name: "Proviance",
                table: "People",
                newName: "Address_Proviance");

            migrationBuilder.RenameColumn(
                name: "Phone",
                table: "People",
                newName: "Address_Phone");

            migrationBuilder.RenameColumn(
                name: "City",
                table: "People",
                newName: "Address_City");
        }
    }
}
