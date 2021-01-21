using Microsoft.EntityFrameworkCore.Migrations;

namespace Session05.RelationConfiguration.Migrations
{
    public partial class addonotoone : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ChildAttr_ParentAttrs_ParentIdFk",
                table: "ChildAttr");

            migrationBuilder.DropIndex(
                name: "IX_ChildAttr_ParentIdFk",
                table: "ChildAttr");

            migrationBuilder.AddColumn<int>(
                name: "ParentId",
                table: "ChildAttr",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "OneParent",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ParentName = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OneParent", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "parentFls",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_parentFls", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "OneChild",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    ChildName = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OneChild", x => x.Id);
                    table.ForeignKey(
                        name: "FK_OneChild_OneParent_Id",
                        column: x => x.Id,
                        principalTable: "OneParent",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ChidlFls",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ParentFlId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ChidlFls", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ChidlFls_parentFls_ParentFlId",
                        column: x => x.ParentFlId,
                        principalTable: "parentFls",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ChildAttr_ParentId",
                table: "ChildAttr",
                column: "ParentId");

            migrationBuilder.CreateIndex(
                name: "IX_ChidlFls_ParentFlId",
                table: "ChidlFls",
                column: "ParentFlId");

            migrationBuilder.AddForeignKey(
                name: "FK_ChildAttr_ParentAttrs_ParentId",
                table: "ChildAttr",
                column: "ParentId",
                principalTable: "ParentAttrs",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ChildAttr_ParentAttrs_ParentId",
                table: "ChildAttr");

            migrationBuilder.DropTable(
                name: "ChidlFls");

            migrationBuilder.DropTable(
                name: "OneChild");

            migrationBuilder.DropTable(
                name: "parentFls");

            migrationBuilder.DropTable(
                name: "OneParent");

            migrationBuilder.DropIndex(
                name: "IX_ChildAttr_ParentId",
                table: "ChildAttr");

            migrationBuilder.DropColumn(
                name: "ParentId",
                table: "ChildAttr");

            migrationBuilder.CreateIndex(
                name: "IX_ChildAttr_ParentIdFk",
                table: "ChildAttr",
                column: "ParentIdFk");

            migrationBuilder.AddForeignKey(
                name: "FK_ChildAttr_ParentAttrs_ParentIdFk",
                table: "ChildAttr",
                column: "ParentIdFk",
                principalTable: "ParentAttrs",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
