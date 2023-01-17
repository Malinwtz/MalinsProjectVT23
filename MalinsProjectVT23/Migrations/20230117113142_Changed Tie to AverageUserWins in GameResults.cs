using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MalinsProjectVT23.Migrations
{
    public partial class ChangedTietoAverageUserWinsinGameResults : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Tie",
                table: "RockScissorPaperGameResults");

            migrationBuilder.AddColumn<decimal>(
                name: "AverageUserWins",
                table: "RockScissorPaperGameResults",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AverageUserWins",
                table: "RockScissorPaperGameResults");

            migrationBuilder.AddColumn<bool>(
                name: "Tie",
                table: "RockScissorPaperGameResults",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }
    }
}
