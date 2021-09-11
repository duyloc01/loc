using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace tuanntgcs18661ApplicationDev.Migrations
{
    public partial class _50 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Code",
                table: "Classrooms",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "EndDate",
                table: "Classrooms",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<int>(
                name: "Part",
                table: "Classrooms",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Semester",
                table: "Classrooms",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<DateTime>(
                name: "StatrtDate",
                table: "Classrooms",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<int>(
                name: "Year",
                table: "Classrooms",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Code",
                table: "Classrooms");

            migrationBuilder.DropColumn(
                name: "EndDate",
                table: "Classrooms");

            migrationBuilder.DropColumn(
                name: "Part",
                table: "Classrooms");

            migrationBuilder.DropColumn(
                name: "Semester",
                table: "Classrooms");

            migrationBuilder.DropColumn(
                name: "StatrtDate",
                table: "Classrooms");

            migrationBuilder.DropColumn(
                name: "Year",
                table: "Classrooms");
        }
    }
}
