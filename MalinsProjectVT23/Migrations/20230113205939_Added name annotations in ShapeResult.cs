using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MalinsProjectVT23.Migrations
{
    public partial class AddednameannotationsinShapeResult : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Length",
                table: "ShapeResults",
                newName: "LengthInCentimeter");

            migrationBuilder.RenameColumn(
                name: "Height",
                table: "ShapeResults",
                newName: "HeightInCentimeter");

            migrationBuilder.RenameColumn(
                name: "Circumference",
                table: "ShapeResults",
                newName: "CircumferenceInCentimeter");

            migrationBuilder.RenameColumn(
                name: "Area",
                table: "ShapeResults",
                newName: "AreaInSquareCentimeter");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "LengthInCentimeter",
                table: "ShapeResults",
                newName: "Length");

            migrationBuilder.RenameColumn(
                name: "HeightInCentimeter",
                table: "ShapeResults",
                newName: "Height");

            migrationBuilder.RenameColumn(
                name: "CircumferenceInCentimeter",
                table: "ShapeResults",
                newName: "Circumference");

            migrationBuilder.RenameColumn(
                name: "AreaInSquareCentimeter",
                table: "ShapeResults",
                newName: "Area");
        }
    }
}
