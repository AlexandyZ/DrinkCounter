using System;
using System.Collections.Generic;
using Microsoft.Data.Entity.Migrations;

namespace DrinkCounter.Migrations
{
    public partial class ModifyDrinkType : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(name: "CategoryId", table: "DrinkType");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CategoryId",
                table: "DrinkType",
                nullable: false,
                defaultValue: 0);
        }
    }
}
