using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    public partial class skillset : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SkillSets_Users_UserId",
                table: "SkillSets");

            migrationBuilder.DropIndex(
                name: "IX_SkillSets_UserId",
                table: "SkillSets");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "SkillSets");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "SkillSets",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.CreateTable(
                name: "UserSkillSets",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    SkillSetId = table.Column<int>(type: "int", nullable: false),
                    SkillSetsId = table.Column<int>(type: "int", nullable: true),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsActive = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserSkillSets", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserSkillSets_SkillSets_SkillSetsId",
                        column: x => x.SkillSetsId,
                        principalTable: "SkillSets",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_UserSkillSets_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_UserSkillSets_SkillSetsId",
                table: "UserSkillSets",
                column: "SkillSetsId");

            migrationBuilder.CreateIndex(
                name: "IX_UserSkillSets_UserId",
                table: "UserSkillSets",
                column: "UserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "UserSkillSets");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "SkillSets",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "UserId",
                table: "SkillSets",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_SkillSets_UserId",
                table: "SkillSets",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_SkillSets_Users_UserId",
                table: "SkillSets",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id");
        }
    }
}
