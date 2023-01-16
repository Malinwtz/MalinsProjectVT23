using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MalinsProjectVT23.Migrations
{
    public partial class Changedpropertiesingame : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ComputerWin",
                table: "RockScissorPaperGameResults");

            migrationBuilder.DropColumn(
                name: "UserWin",
                table: "RockScissorPaperGameResults");

            migrationBuilder.AddColumn<string>(
                name: "Winner",
                table: "RockScissorPaperGameResults",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Winner",
                table: "RockScissorPaperGameResults");

            migrationBuilder.AddColumn<bool>(
                name: "ComputerWin",
                table: "RockScissorPaperGameResults",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "UserWin",
                table: "RockScissorPaperGameResults",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }
    }
}
