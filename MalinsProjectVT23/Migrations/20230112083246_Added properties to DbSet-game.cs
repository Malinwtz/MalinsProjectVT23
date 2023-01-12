using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MalinsProjectVT23.Migrations
{
    public partial class AddedpropertiestoDbSetgame : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "Looser",
                table: "RockScissorPaperGameResults",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<int>(
                name: "NumberOfLosses",
                table: "RockScissorPaperGameResults",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "NumberOfWins",
                table: "RockScissorPaperGameResults",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<bool>(
                name: "Tie",
                table: "RockScissorPaperGameResults",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "Winner",
                table: "RockScissorPaperGameResults",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Looser",
                table: "RockScissorPaperGameResults");

            migrationBuilder.DropColumn(
                name: "NumberOfLosses",
                table: "RockScissorPaperGameResults");

            migrationBuilder.DropColumn(
                name: "NumberOfWins",
                table: "RockScissorPaperGameResults");

            migrationBuilder.DropColumn(
                name: "Tie",
                table: "RockScissorPaperGameResults");

            migrationBuilder.DropColumn(
                name: "Winner",
                table: "RockScissorPaperGameResults");
        }
    }
}
