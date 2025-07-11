using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace myblog.Migrations
{
    /// <inheritdoc />
    public partial class Me : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Education",
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
                    table.PrimaryKey("PK_Education", x => x.EducationId);
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
                name: "Me",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Surname = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Phonenum = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Birthday = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Me", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Skills",
                columns: table => new
                {
                    SkillsId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SkillName = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Skills", x => x.SkillsId);
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
                name: "Education");

            migrationBuilder.DropTable(
                name: "Lang");

            migrationBuilder.DropTable(
                name: "Me");

            migrationBuilder.DropTable(
                name: "Skills");

            migrationBuilder.DropTable(
                name: "SLang");
        }
    }
}
