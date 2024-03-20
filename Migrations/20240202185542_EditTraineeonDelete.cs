using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Task_2ITI.Migrations
{
    public partial class EditTraineeonDelete : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CoursesResult_Courses_CourseId",
                table: "CoursesResult");

            migrationBuilder.DropForeignKey(
                name: "FK_CoursesResult_Trainees_TraineeId",
                table: "CoursesResult");

            migrationBuilder.AlterColumn<string>(
                name: "Image",
                table: "Trainees",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddForeignKey(
                name: "FK_CoursesResult_Courses_CourseId",
                table: "CoursesResult",
                column: "CourseId",
                principalTable: "Courses",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_CoursesResult_Trainees_TraineeId",
                table: "CoursesResult",
                column: "TraineeId",
                principalTable: "Trainees",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CoursesResult_Courses_CourseId",
                table: "CoursesResult");

            migrationBuilder.DropForeignKey(
                name: "FK_CoursesResult_Trainees_TraineeId",
                table: "CoursesResult");

            migrationBuilder.AlterColumn<string>(
                name: "Image",
                table: "Trainees",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_CoursesResult_Courses_CourseId",
                table: "CoursesResult",
                column: "CourseId",
                principalTable: "Courses",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);

            migrationBuilder.AddForeignKey(
                name: "FK_CoursesResult_Trainees_TraineeId",
                table: "CoursesResult",
                column: "TraineeId",
                principalTable: "Trainees",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);
        }
    }
}
