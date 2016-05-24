using System;
using System.Collections.Generic;
using Microsoft.Data.Entity.Migrations;

namespace DrinkCounter.Migrations
{
    public partial class modifyModels : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(name: "DrinkTypeId", table: "DrinkCount");
            migrationBuilder.CreateTable(
                name: "TeamMember",
                columns: table => new
                {
                    UserId = table.Column<string>(nullable: false),
                    TeamId = table.Column<int>(nullable: false),
                    Activated = table.Column<bool>(nullable: false, defaultValue: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TeamMember", x => new { x.UserId, x.TeamId });
                    table.ForeignKey(
                        name: "FK_TeamMember_Team_TeamId",
                        column: x => x.TeamId,
                        principalTable: "Team",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_TeamMember_UserInfo_UserId",
                        column: x => x.UserId,
                        principalTable: "UserInfo",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });
            migrationBuilder.AlterColumn<string>(
                name: "Lastname",
                table: "UserInfo",
                nullable: false);
            migrationBuilder.AlterColumn<string>(
                name: "Gender",
                table: "UserInfo",
                type: "char",
                nullable: true);
            migrationBuilder.AlterColumn<string>(
                name: "Firstname",
                table: "UserInfo",
                nullable: false);
            migrationBuilder.AddColumn<int>(
                name: "CategoryId",
                table: "DrinkType",
                nullable: false,
                defaultValue: 0);
            migrationBuilder.AddColumn<int>(
                name: "DrinkCategoryId",
                table: "DrinkType",
                nullable: true);
            migrationBuilder.AddColumn<int>(
                name: "TypeId",
                table: "DrinkCount",
                nullable: false,
                defaultValue: 0);
            migrationBuilder.AddColumn<string>(
                name: "UserId",
                table: "DrinkCount",
                nullable: true);
            migrationBuilder.AddForeignKey(
                name: "FK_DrinkCount_DrinkType_TypeId",
                table: "DrinkCount",
                column: "TypeId",
                principalTable: "DrinkType",
                principalColumn: "DrinkTypeId",
                onDelete: ReferentialAction.Restrict);
            migrationBuilder.AddForeignKey(
                name: "FK_DrinkCount_UserInfo_UserId",
                table: "DrinkCount",
                column: "UserId",
                principalTable: "UserInfo",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
            migrationBuilder.AddForeignKey(
                name: "FK_DrinkType_DrinkCategory_DrinkCategoryId",
                table: "DrinkType",
                column: "DrinkCategoryId",
                principalTable: "DrinkCategory",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(name: "FK_DrinkCount_DrinkType_TypeId", table: "DrinkCount");
            migrationBuilder.DropForeignKey(name: "FK_DrinkCount_UserInfo_UserId", table: "DrinkCount");
            migrationBuilder.DropForeignKey(name: "FK_DrinkType_DrinkCategory_DrinkCategoryId", table: "DrinkType");
            migrationBuilder.DropColumn(name: "CategoryId", table: "DrinkType");
            migrationBuilder.DropColumn(name: "DrinkCategoryId", table: "DrinkType");
            migrationBuilder.DropColumn(name: "TypeId", table: "DrinkCount");
            migrationBuilder.DropColumn(name: "UserId", table: "DrinkCount");
            migrationBuilder.DropTable("TeamMember");
            migrationBuilder.AlterColumn<string>(
                name: "Lastname",
                table: "UserInfo",
                nullable: true);
            migrationBuilder.AlterColumn<string>(
                name: "Gender",
                table: "UserInfo",
                nullable: true);
            migrationBuilder.AlterColumn<string>(
                name: "Firstname",
                table: "UserInfo",
                nullable: true);
            migrationBuilder.AddColumn<int>(
                name: "DrinkTypeId",
                table: "DrinkCount",
                nullable: false,
                defaultValue: 0);
        }
    }
}
