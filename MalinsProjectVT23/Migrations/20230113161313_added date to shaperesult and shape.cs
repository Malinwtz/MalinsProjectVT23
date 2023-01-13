using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MalinsProjectVT23.Migrations
{
    public partial class addeddatetoshaperesultandshape : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Date",
                table: "ShapeResults",
                newName: "ResultDate");

            migrationBuilder.AddColumn<DateTime>(
                name: "ShapeDate",
                table: "Shapes",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ShapeDate",
                table: "Shapes");

            migrationBuilder.RenameColumn(
                name: "ResultDate",
                table: "ShapeResults",
                newName: "Date");
        }
    }
}
