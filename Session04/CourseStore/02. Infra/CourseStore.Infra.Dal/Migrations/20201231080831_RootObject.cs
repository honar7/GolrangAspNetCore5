using Microsoft.EntityFrameworkCore.Migrations;

namespace CourseStore.Infra.Dal.Migrations
{
    public partial class RootObject : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "RootObjects",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RootObjects", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Relation01",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RootObjectId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Relation01", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Relation01_RootObjects_RootObjectId",
                        column: x => x.RootObjectId,
                        principalTable: "RootObjects",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Relation02",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RootObjectId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Relation02", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Relation02_RootObjects_RootObjectId",
                        column: x => x.RootObjectId,
                        principalTable: "RootObjects",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Relation03",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RootObjectId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Relation03", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Relation03_RootObjects_RootObjectId",
                        column: x => x.RootObjectId,
                        principalTable: "RootObjects",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Relation01_RootObjectId",
                table: "Relation01",
                column: "RootObjectId");

            migrationBuilder.CreateIndex(
                name: "IX_Relation02_RootObjectId",
                table: "Relation02",
                column: "RootObjectId");

            migrationBuilder.CreateIndex(
                name: "IX_Relation03_RootObjectId",
                table: "Relation03",
                column: "RootObjectId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Relation01");

            migrationBuilder.DropTable(
                name: "Relation02");

            migrationBuilder.DropTable(
                name: "Relation03");

            migrationBuilder.DropTable(
                name: "RootObjects");
        }
    }
}
