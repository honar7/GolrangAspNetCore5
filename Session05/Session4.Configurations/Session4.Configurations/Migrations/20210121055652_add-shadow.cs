using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Session4.Configurations.Migrations
{
    public partial class addshadow : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "defaults");

            migrationBuilder.EnsureSchema(
                name: "stest");

            migrationBuilder.EnsureSchema(
                name: "abc");

            migrationBuilder.CreateTable(
                name: "FirstEntityAttributes",
                schema: "defaults",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    BirthDate = table.Column<DateTime>(type: "Date", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FirstEntityAttributes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "FirstEntityFluent",
                schema: "defaults",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    BirthDate = table.Column<DateTime>(type: "Date", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FirstEntityFluent", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "KeyLessFluentSample",
                schema: "defaults",
                columns: table => new
                {
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                });

            migrationBuilder.CreateTable(
                name: "MyTable",
                schema: "stest",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    column_Class_Name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MyTable", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PkTestFluent",
                schema: "defaults",
                columns: table => new
                {
                    Pk01 = table.Column<int>(type: "int", nullable: false),
                    Pk02 = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PkTestFluent", x => new { x.Pk01, x.Pk02 });
                });

            migrationBuilder.CreateTable(
                name: "ShadowProp",
                schema: "defaults",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    InsertBy = table.Column<int>(type: "int", nullable: false),
                    InsertDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdagteBy = table.Column<int>(type: "int", nullable: false),
                    UpdateDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ShadowProp", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "tbl_SetNameFluent",
                schema: "abc",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    col_ClassName = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbl_SetNameFluent", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TestValueConversions",
                schema: "defaults",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ValueConversionInner = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TestValueConversions", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_FirstEntityFluent_FirstName_LastName",
                schema: "defaults",
                table: "FirstEntityFluent",
                columns: new[] { "FirstName", "LastName" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "FirstEntityAttributes",
                schema: "defaults");

            migrationBuilder.DropTable(
                name: "FirstEntityFluent",
                schema: "defaults");

            migrationBuilder.DropTable(
                name: "KeyLessFluentSample",
                schema: "defaults");

            migrationBuilder.DropTable(
                name: "MyTable",
                schema: "stest");

            migrationBuilder.DropTable(
                name: "PkTestFluent",
                schema: "defaults");

            migrationBuilder.DropTable(
                name: "ShadowProp",
                schema: "defaults");

            migrationBuilder.DropTable(
                name: "tbl_SetNameFluent",
                schema: "abc");

            migrationBuilder.DropTable(
                name: "TestValueConversions",
                schema: "defaults");
        }
    }
}
