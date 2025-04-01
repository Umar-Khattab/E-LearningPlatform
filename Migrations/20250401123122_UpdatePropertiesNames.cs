using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace E_LearningPlatform.Migrations
{
    /// <inheritdoc />
    public partial class UpdatePropertiesNames : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "UserID",
                table: "Users",
                newName: "ID");

            migrationBuilder.RenameColumn(
                name: "QuestionID",
                table: "Questions",
                newName: "ID");

            migrationBuilder.RenameColumn(
                name: "ExamID",
                table: "Exams",
                newName: "ID");

            migrationBuilder.RenameColumn(
                name: "CourseID",
                table: "Courses",
                newName: "ID");

            migrationBuilder.RenameColumn(
                name: "StudentId",
                table: "Answers",
                newName: "StudentID");

            migrationBuilder.RenameColumn(
                name: "StudentID",
                table: "Answers",
                newName: "ID");

            migrationBuilder.RenameIndex(
                name: "IX_Answers_StudentId",
                table: "Answers",
                newName: "IX_Answers_StudentID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ID",
                table: "Users",
                newName: "UserID");

            migrationBuilder.RenameColumn(
                name: "ID",
                table: "Questions",
                newName: "QuestionID");

            migrationBuilder.RenameColumn(
                name: "ID",
                table: "Exams",
                newName: "ExamID");

            migrationBuilder.RenameColumn(
                name: "ID",
                table: "Courses",
                newName: "CourseID");

            migrationBuilder.RenameColumn(
                name: "StudentID",
                table: "Answers",
                newName: "StudentId");

            migrationBuilder.RenameColumn(
                name: "ID",
                table: "Answers",
                newName: "StudentID");

            migrationBuilder.RenameIndex(
                name: "IX_Answers_StudentID",
                table: "Answers",
                newName: "IX_Answers_StudentId");
        }
    }
}
