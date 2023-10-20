using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace neophyte_proj.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class bage : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CourseBags_Students_StudentId",
                table: "CourseBags");

            migrationBuilder.DropIndex(
                name: "IX_CourseBags_StudentId",
                table: "CourseBags");

            migrationBuilder.DropColumn(
                name: "StudentId",
                table: "CourseBags");

            migrationBuilder.CreateTable(
                name: "BageStudent",
                columns: table => new
                {
                    BageId = table.Column<int>(type: "int", nullable: false),
                    StudentId = table.Column<int>(type: "int", nullable: false),
                    CourseBageId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BageStudent", x => new { x.BageId, x.StudentId });
                    table.ForeignKey(
                        name: "FK_BageStudent_CourseBags_CourseBageId",
                        column: x => x.CourseBageId,
                        principalTable: "CourseBags",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BageStudent_Students_StudentId",
                        column: x => x.StudentId,
                        principalTable: "Students",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_BageStudent_CourseBageId",
                table: "BageStudent",
                column: "CourseBageId");

            migrationBuilder.CreateIndex(
                name: "IX_BageStudent_StudentId",
                table: "BageStudent",
                column: "StudentId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BageStudent");

            migrationBuilder.AddColumn<int>(
                name: "StudentId",
                table: "CourseBags",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_CourseBags_StudentId",
                table: "CourseBags",
                column: "StudentId");

            migrationBuilder.AddForeignKey(
                name: "FK_CourseBags_Students_StudentId",
                table: "CourseBags",
                column: "StudentId",
                principalTable: "Students",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
