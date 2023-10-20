using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace neophyte_proj.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class feedBack : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Author",
                table: "TeacherFeedBacks");

            migrationBuilder.DropColumn(
                name: "Author",
                table: "CourseFeedBacks");

            migrationBuilder.DropColumn(
                name: "IsAuthorStudent",
                table: "CourseFeedBacks");

            migrationBuilder.AddColumn<int>(
                name: "StudentId",
                table: "TeacherFeedBacks",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "StudentId",
                table: "CourseFeedBacks",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_TeacherFeedBacks_StudentId",
                table: "TeacherFeedBacks",
                column: "StudentId");

            migrationBuilder.CreateIndex(
                name: "IX_CourseFeedBacks_StudentId",
                table: "CourseFeedBacks",
                column: "StudentId");

            migrationBuilder.AddForeignKey(
                name: "FK_CourseFeedBacks_Students_StudentId",
                table: "CourseFeedBacks",
                column: "StudentId",
                principalTable: "Students",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_TeacherFeedBacks_Students_StudentId",
                table: "TeacherFeedBacks",
                column: "StudentId",
                principalTable: "Students",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CourseFeedBacks_Students_StudentId",
                table: "CourseFeedBacks");

            migrationBuilder.DropForeignKey(
                name: "FK_TeacherFeedBacks_Students_StudentId",
                table: "TeacherFeedBacks");

            migrationBuilder.DropIndex(
                name: "IX_TeacherFeedBacks_StudentId",
                table: "TeacherFeedBacks");

            migrationBuilder.DropIndex(
                name: "IX_CourseFeedBacks_StudentId",
                table: "CourseFeedBacks");

            migrationBuilder.DropColumn(
                name: "StudentId",
                table: "TeacherFeedBacks");

            migrationBuilder.DropColumn(
                name: "StudentId",
                table: "CourseFeedBacks");

            migrationBuilder.AddColumn<string>(
                name: "Author",
                table: "TeacherFeedBacks",
                type: "varchar(20)",
                maxLength: 20,
                nullable: false,
                defaultValue: "")
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<string>(
                name: "Author",
                table: "CourseFeedBacks",
                type: "varchar(20)",
                maxLength: 20,
                nullable: false,
                defaultValue: "")
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<bool>(
                name: "IsAuthorStudent",
                table: "CourseFeedBacks",
                type: "tinyint(1)",
                nullable: false,
                defaultValue: false);
        }
    }
}
