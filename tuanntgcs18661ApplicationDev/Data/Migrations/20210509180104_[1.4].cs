using Microsoft.EntityFrameworkCore.Migrations;

namespace tuanntgcs18661ApplicationDev.Migrations
{
    public partial class _14 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ClassProfile",
                table: "Classrooms",
                type: "int",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ClassProfile",
                table: "Classrooms");
        }
    }
}
