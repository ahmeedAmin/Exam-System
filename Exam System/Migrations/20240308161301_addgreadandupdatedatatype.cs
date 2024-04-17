using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Exam_System.Migrations
{
    /// <inheritdoc />
    public partial class addgreadandupdatedatatype : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<double>(
                name: "Grade",
                table: "StudentSubjects",
                type: "float",
                nullable: true);

            migrationBuilder.AlterColumn<double>(
                name: "Grade",
                table: "StudentExams",
                type: "float",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Grade",
                table: "StudentSubjects");

            migrationBuilder.AlterColumn<int>(
                name: "Grade",
                table: "StudentExams",
                type: "int",
                nullable: false,
                oldClrType: typeof(double),
                oldType: "float");
        }
    }
}
