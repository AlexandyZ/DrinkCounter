using System;
using System.Collections.Generic;
using Microsoft.Data.Entity.Migrations;

namespace DrinkCounter.Migrations
{
    public partial class drinktype : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(name: "FK_DrinkType_DrinkCategory_DrinkCategoryId", table: "DrinkType");
            migrationBuilder.AlterColumn<int>(
                name: "DrinkCategoryId",
                table: "DrinkType",
                nullable: false);
            migrationBuilder.AddForeignKey(
                name: "FK_DrinkType_DrinkCategory_DrinkCategoryId",
                table: "DrinkType",
                column: "DrinkCategoryId",
                principalTable: "DrinkCategory",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(name: "FK_DrinkType_DrinkCategory_DrinkCategoryId", table: "DrinkType");
            migrationBuilder.AlterColumn<int>(
                name: "DrinkCategoryId",
                table: "DrinkType",
                nullable: true);
            migrationBuilder.AddForeignKey(
                name: "FK_DrinkType_DrinkCategory_DrinkCategoryId",
                table: "DrinkType",
                column: "DrinkCategoryId",
                principalTable: "DrinkCategory",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
