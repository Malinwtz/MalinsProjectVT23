using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MalinsProjectVT23.Migrations
{
    public partial class addedpropertycalculationStrategytocalculationclass : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "CalculationStrategy",
                table: "Calculations",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CalculationStrategy",
                table: "Calculations");
        }
    }
}
