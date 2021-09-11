using Microsoft.EntityFrameworkCore.Migrations;

namespace tuanntgcs18661ApplicationDev.Migrations
{
    public partial class _15 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ClassProfile",
                table: "Classrooms");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ClassProfile",
                table: "Classrooms",
                type: "int",
                nullable: true);
        }
    }
}
