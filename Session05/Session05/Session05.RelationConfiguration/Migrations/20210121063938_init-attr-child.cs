using Microsoft.EntityFrameworkCore.Migrations;

namespace Session05.RelationConfiguration.Migrations
{
    public partial class initattrchild : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ChildAttr",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ParentIdFk = table.Column<int>(type: "int", nullable: false),
                    ParentId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ChildAttr", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ChildAttr_ParentAttrs_ParentId",
                        column: x => x.ParentId,
                        principalTable: "ParentAttrs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ChildAttr_ParentId",
                table: "ChildAttr",
                column: "ParentId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ChildAttr");
        }
    }
}
