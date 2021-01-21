using Microsoft.EntityFrameworkCore.Migrations;

namespace Session05.RelationConfiguration.Migrations
{
    public partial class initattrchildsetfk : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ChildAttr_ParentAttrs_ParentId",
                table: "ChildAttr");

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

        protected override void Down(MigrationBuilder migrationBuilder)
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

            migrationBuilder.CreateIndex(
                name: "IX_ChildAttr_ParentId",
                table: "ChildAttr",
                column: "ParentId");

            migrationBuilder.AddForeignKey(
                name: "FK_ChildAttr_ParentAttrs_ParentId",
                table: "ChildAttr",
                column: "ParentId",
                principalTable: "ParentAttrs",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
