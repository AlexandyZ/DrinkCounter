using System;
using System.Collections.Generic;
using Microsoft.Data.Entity.Migrations;

namespace DrinkCounter.Migrations
{
    public partial class FixingTeam : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(name: "Date", table: "Team");
            migrationBuilder.AddColumn<DateTime>(
                name: "CreateDate",
                table: "Team",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(name: "CreateDate", table: "Team");
            migrationBuilder.AddColumn<DateTime>(
                name: "Date",
                table: "Team",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }
    }
}
