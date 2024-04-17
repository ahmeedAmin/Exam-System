using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Exam_System.Migrations
{
    /// <inheritdoc />
    public partial class deletUserAnswer : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "UserAnswer",
                table: "Questions");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "UserAnswer",
                table: "Questions",
                type: "int",
                nullable: true);
        }
    }
}
