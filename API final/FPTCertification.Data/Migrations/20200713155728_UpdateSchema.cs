using Microsoft.EntityFrameworkCore.Migrations;

namespace FPTCertification.Data.Migrations
{
    public partial class UpdateSchema : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Questions_Skills_SkillId",
                table: "Questions");

            migrationBuilder.RenameColumn(
                name: "ID",
                table: "Certifications",
                newName: "Id");

            migrationBuilder.AlterColumn<int>(
                name: "SkillId",
                table: "Questions",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_Questions_Skills_SkillId",
                table: "Questions",
                column: "SkillId",
                principalTable: "Skills",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Questions_Skills_SkillId",
                table: "Questions");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Certifications",
                newName: "ID");

            migrationBuilder.AlterColumn<int>(
                name: "SkillId",
                table: "Questions",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Questions_Skills_SkillId",
                table: "Questions",
                column: "SkillId",
                principalTable: "Skills",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
