using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    public partial class skillsetImprove : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserSkillSets_SkillSets_SkillSetsId",
                table: "UserSkillSets");

            migrationBuilder.DropColumn(
                name: "SkillSetId",
                table: "UserSkillSets");

            migrationBuilder.AlterColumn<int>(
                name: "SkillSetsId",
                table: "UserSkillSets",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_UserSkillSets_SkillSets_SkillSetsId",
                table: "UserSkillSets",
                column: "SkillSetsId",
                principalTable: "SkillSets",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserSkillSets_SkillSets_SkillSetsId",
                table: "UserSkillSets");

            migrationBuilder.AlterColumn<int>(
                name: "SkillSetsId",
                table: "UserSkillSets",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<int>(
                name: "SkillSetId",
                table: "UserSkillSets",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddForeignKey(
                name: "FK_UserSkillSets_SkillSets_SkillSetsId",
                table: "UserSkillSets",
                column: "SkillSetsId",
                principalTable: "SkillSets",
                principalColumn: "Id");
        }
    }
}
