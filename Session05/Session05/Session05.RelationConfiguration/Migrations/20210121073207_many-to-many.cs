using Microsoft.EntityFrameworkCore.Migrations;

namespace Session05.RelationConfiguration.Migrations
{
    public partial class manytomany : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ManyChild",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ChildName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    OneParentId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ManyChild", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ManyChild_OneParent_OneParentId",
                        column: x => x.OneParentId,
                        principalTable: "OneParent",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ManyLeft",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ManyLeft", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ManyRight",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ManyRight", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "RelationManyToMany",
                columns: table => new
                {
                    ManyLeftId = table.Column<int>(type: "int", nullable: false),
                    ManyRightId = table.Column<int>(type: "int", nullable: false),
                    SortOrder = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RelationManyToMany", x => new { x.ManyLeftId, x.ManyRightId });
                    table.ForeignKey(
                        name: "FK_RelationManyToMany_ManyLeft_ManyLeftId",
                        column: x => x.ManyLeftId,
                        principalTable: "ManyLeft",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_RelationManyToMany_ManyRight_ManyRightId",
                        column: x => x.ManyRightId,
                        principalTable: "ManyRight",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ManyChild_OneParentId",
                table: "ManyChild",
                column: "OneParentId");

            migrationBuilder.CreateIndex(
                name: "IX_RelationManyToMany_ManyRightId",
                table: "RelationManyToMany",
                column: "ManyRightId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ManyChild");

            migrationBuilder.DropTable(
                name: "RelationManyToMany");

            migrationBuilder.DropTable(
                name: "ManyLeft");

            migrationBuilder.DropTable(
                name: "ManyRight");
        }
    }
}
