using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MalinsProjectVT23.Migrations
{
    public partial class AddedPrimaryKeysinalldatabaseclasses : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Calculations",
                columns: table => new
                {
                    CalculationId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Input1 = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Input2 = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Result = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Calculations", x => x.CalculationId);
                });

            migrationBuilder.CreateTable(
                name: "RockScissorPaperGameResults",
                columns: table => new
                {
                    GameId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RockScissorPaperGameResults", x => x.GameId);
                });

            migrationBuilder.CreateTable(
                name: "ShapeResults",
                columns: table => new
                {
                    ShapeResultId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ShapeResults", x => x.ShapeResultId);
                });

            migrationBuilder.CreateTable(
                name: "Shapes",
                columns: table => new
                {
                    ShapeId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Shapes", x => x.ShapeId);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Calculations");

            migrationBuilder.DropTable(
                name: "RockScissorPaperGameResults");

            migrationBuilder.DropTable(
                name: "ShapeResults");

            migrationBuilder.DropTable(
                name: "Shapes");
        }
    }
}
