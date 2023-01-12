using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MalinsProjectVT23.Migrations
{
    public partial class Datetimeingame : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Winner",
                table: "RockScissorPaperGameResults",
                newName: "UserWin");

            migrationBuilder.RenameColumn(
                name: "NumberOfWins",
                table: "RockScissorPaperGameResults",
                newName: "NumberOfUserWins");

            migrationBuilder.RenameColumn(
                name: "NumberOfLosses",
                table: "RockScissorPaperGameResults",
                newName: "NumberOfComputerWins");

            migrationBuilder.RenameColumn(
                name: "Looser",
                table: "RockScissorPaperGameResults",
                newName: "ComputerWin");

            migrationBuilder.AddColumn<DateTime>(
                name: "Date",
                table: "RockScissorPaperGameResults",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Date",
                table: "RockScissorPaperGameResults");

            migrationBuilder.RenameColumn(
                name: "UserWin",
                table: "RockScissorPaperGameResults",
                newName: "Winner");

            migrationBuilder.RenameColumn(
                name: "NumberOfUserWins",
                table: "RockScissorPaperGameResults",
                newName: "NumberOfWins");

            migrationBuilder.RenameColumn(
                name: "NumberOfComputerWins",
                table: "RockScissorPaperGameResults",
                newName: "NumberOfLosses");

            migrationBuilder.RenameColumn(
                name: "ComputerWin",
                table: "RockScissorPaperGameResults",
                newName: "Looser");
        }
    }
}
