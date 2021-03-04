using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace FPTCertification.Data.Migrations
{
    public partial class addnewtablequizhtml : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_CertificationSkills",
                table: "CertificationSkills");

            migrationBuilder.DropIndex(
                name: "IX_CertificationSkills_CertificationId",
                table: "CertificationSkills");

            migrationBuilder.AddPrimaryKey(
                name: "PK_CertificationSkills",
                table: "CertificationSkills",
                columns: new[] { "CertificationId", "SkillId" });

            migrationBuilder.CreateTable(
                name: "QuizHTMLs",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Ten = table.Column<string>(maxLength: 200, nullable: true),
                    DapAn1 = table.Column<string>(maxLength: 200, nullable: true),
                    DapAn2 = table.Column<string>(nullable: true),
                    DapAn3 = table.Column<string>(nullable: true),
                    DapAn4 = table.Column<string>(nullable: true),
                    CreateDate = table.Column<DateTime>(nullable: false),
                    ModifyDate = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_QuizHTMLs", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "QuizHTMLs");

            migrationBuilder.DropPrimaryKey(
                name: "PK_CertificationSkills",
                table: "CertificationSkills");

            migrationBuilder.AddPrimaryKey(
                name: "PK_CertificationSkills",
                table: "CertificationSkills",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_CertificationSkills_CertificationId",
                table: "CertificationSkills",
                column: "CertificationId");
        }
    }
}
