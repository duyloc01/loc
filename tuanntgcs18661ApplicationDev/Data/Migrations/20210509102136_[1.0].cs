using Microsoft.EntityFrameworkCore.Migrations;

namespace tuanntgcs18661ApplicationDev.Migrations
{
    public partial class _10 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Topics_AspNetUsers_TrainerId1",
                table: "Topics");

            migrationBuilder.DropTable(
                name: "TrainneeClassrooms");

            migrationBuilder.DropIndex(
                name: "IX_Topics_TrainerId1",
                table: "Topics");

            migrationBuilder.DropColumn(
                name: "TrainerId1",
                table: "Topics");

            migrationBuilder.DropColumn(
                name: "ClassProfiledId",
                table: "Classrooms");

            migrationBuilder.RenameColumn(
                name: "StatrtDate",
                table: "Classrooms",
                newName: "StartDate");

            migrationBuilder.RenameColumn(
                name: "Firstname",
                table: "AspNetUsers",
                newName: "FirstName");

            migrationBuilder.AlterColumn<string>(
                name: "TrainerId",
                table: "Topics",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "Topics",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "Courses",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "EnrolmentYear",
                table: "ClassProfiles",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.CreateTable(
                name: "Trainee",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    TOEIC = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Trainee", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Trainee_AspNetUsers_Id",
                        column: x => x.Id,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "TraineeClassrooms",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ClassroomId = table.Column<int>(type: "int", nullable: false),
                    TraineeId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TraineeClassrooms", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TraineeClassrooms_AspNetUsers_TraineeId",
                        column: x => x.TraineeId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TraineeClassrooms_Classrooms_ClassroomId",
                        column: x => x.ClassroomId,
                        principalTable: "Classrooms",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Trainer",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Type = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Trainer", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Trainer_AspNetUsers_Id",
                        column: x => x.Id,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Topics_TrainerId",
                table: "Topics",
                column: "TrainerId");

            migrationBuilder.CreateIndex(
                name: "IX_TraineeClassrooms_ClassroomId",
                table: "TraineeClassrooms",
                column: "ClassroomId");

            migrationBuilder.CreateIndex(
                name: "IX_TraineeClassrooms_TraineeId",
                table: "TraineeClassrooms",
                column: "TraineeId");

            migrationBuilder.AddForeignKey(
                name: "FK_Topics_AspNetUsers_TrainerId",
                table: "Topics",
                column: "TrainerId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Topics_AspNetUsers_TrainerId",
                table: "Topics");

            migrationBuilder.DropTable(
                name: "Trainee");

            migrationBuilder.DropTable(
                name: "TraineeClassrooms");

            migrationBuilder.DropTable(
                name: "Trainer");

            migrationBuilder.DropIndex(
                name: "IX_Topics_TrainerId",
                table: "Topics");

            migrationBuilder.DropColumn(
                name: "Name",
                table: "Topics");

            migrationBuilder.DropColumn(
                name: "Description",
                table: "Courses");

            migrationBuilder.RenameColumn(
                name: "StartDate",
                table: "Classrooms",
                newName: "StatrtDate");

            migrationBuilder.RenameColumn(
                name: "FirstName",
                table: "AspNetUsers",
                newName: "Firstname");

            migrationBuilder.AlterColumn<int>(
                name: "TrainerId",
                table: "Topics",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AddColumn<string>(
                name: "TrainerId1",
                table: "Topics",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ClassProfiledId",
                table: "Classrooms",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<int>(
                name: "EnrolmentYear",
                table: "ClassProfiles",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.CreateTable(
                name: "TrainneeClassrooms",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ClassroomId = table.Column<int>(type: "int", nullable: false),
                    TraineeId = table.Column<int>(type: "int", nullable: false),
                    TraineeId1 = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TrainneeClassrooms", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TrainneeClassrooms_AspNetUsers_TraineeId1",
                        column: x => x.TraineeId1,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_TrainneeClassrooms_Classrooms_ClassroomId",
                        column: x => x.ClassroomId,
                        principalTable: "Classrooms",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Topics_TrainerId1",
                table: "Topics",
                column: "TrainerId1");

            migrationBuilder.CreateIndex(
                name: "IX_TrainneeClassrooms_ClassroomId",
                table: "TrainneeClassrooms",
                column: "ClassroomId");

            migrationBuilder.CreateIndex(
                name: "IX_TrainneeClassrooms_TraineeId1",
                table: "TrainneeClassrooms",
                column: "TraineeId1");

            migrationBuilder.AddForeignKey(
                name: "FK_Topics_AspNetUsers_TrainerId1",
                table: "Topics",
                column: "TrainerId1",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
