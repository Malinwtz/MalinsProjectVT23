using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MalinsProjectVT23.Migrations
{
    public partial class Changeddecimalrange : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<decimal>(
                name: "LengthInCentimeter",
                table: "ShapeResults",
                type: "decimal(38,38)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(38,2)");

            migrationBuilder.AlterColumn<decimal>(
                name: "HeightInCentimeter",
                table: "ShapeResults",
                type: "decimal(38,38)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(38,2)");

            migrationBuilder.AlterColumn<decimal>(
                name: "CircumferenceInCentimeter",
                table: "ShapeResults",
                type: "decimal(38,38)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(38,2)");

            migrationBuilder.AlterColumn<decimal>(
                name: "AreaInSquareCentimeter",
                table: "ShapeResults",
                type: "decimal(38,38)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(38,2)");

            migrationBuilder.AlterColumn<decimal>(
                name: "Result",
                table: "Calculations",
                type: "decimal(38,38)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(38,2)");

            migrationBuilder.AlterColumn<decimal>(
                name: "Input2",
                table: "Calculations",
                type: "decimal(38,38)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(38,2)");

            migrationBuilder.AlterColumn<decimal>(
                name: "Input1",
                table: "Calculations",
                type: "decimal(38,38)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(38,2)");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<decimal>(
                name: "LengthInCentimeter",
                table: "ShapeResults",
                type: "decimal(38,2)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(38,38)");

            migrationBuilder.AlterColumn<decimal>(
                name: "HeightInCentimeter",
                table: "ShapeResults",
                type: "decimal(38,2)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(38,38)");

            migrationBuilder.AlterColumn<decimal>(
                name: "CircumferenceInCentimeter",
                table: "ShapeResults",
                type: "decimal(38,2)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(38,38)");

            migrationBuilder.AlterColumn<decimal>(
                name: "AreaInSquareCentimeter",
                table: "ShapeResults",
                type: "decimal(38,2)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(38,38)");

            migrationBuilder.AlterColumn<decimal>(
                name: "Result",
                table: "Calculations",
                type: "decimal(38,2)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(38,38)");

            migrationBuilder.AlterColumn<decimal>(
                name: "Input2",
                table: "Calculations",
                type: "decimal(38,2)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(38,38)");

            migrationBuilder.AlterColumn<decimal>(
                name: "Input1",
                table: "Calculations",
                type: "decimal(38,2)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(38,38)");
        }
    }
}
