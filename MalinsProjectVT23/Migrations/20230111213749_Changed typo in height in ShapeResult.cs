using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MalinsProjectVT23.Migrations
{
    public partial class ChangedtypoinheightinShapeResult : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<decimal>(
                name: "Area",
                table: "ShapeResults",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "Circumference",
                table: "ShapeResults",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "Height",
                table: "ShapeResults",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "Length",
                table: "ShapeResults",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<int>(
                name: "ShapeId",
                table: "ShapeResults",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_ShapeResults_ShapeId",
                table: "ShapeResults",
                column: "ShapeId");

            migrationBuilder.AddForeignKey(
                name: "FK_ShapeResults_Shapes_ShapeId",
                table: "ShapeResults",
                column: "ShapeId",
                principalTable: "Shapes",
                principalColumn: "ShapeId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ShapeResults_Shapes_ShapeId",
                table: "ShapeResults");

            migrationBuilder.DropIndex(
                name: "IX_ShapeResults_ShapeId",
                table: "ShapeResults");

            migrationBuilder.DropColumn(
                name: "Area",
                table: "ShapeResults");

            migrationBuilder.DropColumn(
                name: "Circumference",
                table: "ShapeResults");

            migrationBuilder.DropColumn(
                name: "Height",
                table: "ShapeResults");

            migrationBuilder.DropColumn(
                name: "Length",
                table: "ShapeResults");

            migrationBuilder.DropColumn(
                name: "ShapeId",
                table: "ShapeResults");
        }
    }
}
