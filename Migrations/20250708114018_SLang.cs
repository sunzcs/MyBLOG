using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace myblog.Migrations
{
    /// <inheritdoc />
    public partial class SLang : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Educations",
                columns: table => new
                {
                    EducationId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SCName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SCStatement = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SCStartdate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    SCFinishdate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Educations", x => x.EducationId);
                });

            migrationBuilder.CreateTable(
                name: "Lang",
                columns: table => new
                {
                    LangId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    LangName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LangLevel = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Lang", x => x.LangId);
                });

            migrationBuilder.CreateTable(
                name: "SLang",
                columns: table => new
                {
                    SlangId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SlangName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SlangLevel = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SLang", x => x.SlangId);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Educations");

            migrationBuilder.DropTable(
                name: "Lang");

            migrationBuilder.DropTable(
                name: "SLang");
        }
    }
}
