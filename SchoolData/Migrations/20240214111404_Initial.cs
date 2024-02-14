using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace SchoolData.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Courses",
                columns: table => new
                {
                    CourseId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Title = table.Column<string>(type: "text", nullable: false),
                    Description = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Courses", x => x.CourseId);
                });

            migrationBuilder.CreateTable(
                name: "Students",
                columns: table => new
                {
                    StudentId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Age = table.Column<int>(type: "integer", nullable: false),
                    GPA = table.Column<double>(type: "double precision", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Students", x => x.StudentId);
                });

            migrationBuilder.CreateTable(
                name: "Enrollments",
                columns: table => new
                {
                    EnrollmentId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    StudentId = table.Column<int>(type: "integer", nullable: false),
                    CourseId = table.Column<int>(type: "integer", nullable: false),
                    EnrollmentDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Enrollments", x => x.EnrollmentId);
                    table.ForeignKey(
                        name: "FK_Enrollments_Courses_CourseId",
                        column: x => x.CourseId,
                        principalTable: "Courses",
                        principalColumn: "CourseId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Enrollments_Students_StudentId",
                        column: x => x.StudentId,
                        principalTable: "Students",
                        principalColumn: "StudentId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Courses",
                columns: new[] { "CourseId", "Description", "Title" },
                values: new object[,]
                {
                    { 1, "Introduction to Mathematics", "Mathematics" },
                    { 2, "Introduction to Science", "Science" },
                    { 3, "Introduction to History", "History" }
                });

            migrationBuilder.InsertData(
                table: "Students",
                columns: new[] { "StudentId", "Age", "GPA", "Name" },
                values: new object[,]
                {
                    { 1, 18, 3.7999999999999998, "John Doe" },
                    { 2, 19, 3.8999999999999999, "Jane Smith" },
                    { 3, 20, 3.5, "Alice Johnson" },
                    { 4, 21, 3.7000000000000002, "Bob Brown" }
                });

            migrationBuilder.InsertData(
                table: "Enrollments",
                columns: new[] { "EnrollmentId", "CourseId", "EnrollmentDate", "StudentId" },
                values: new object[,]
                {
                    { 1, 1, new DateTime(2024, 2, 14, 11, 14, 3, 790, DateTimeKind.Utc).AddTicks(3160), 1 },
                    { 2, 2, new DateTime(2024, 2, 14, 11, 14, 3, 790, DateTimeKind.Utc).AddTicks(3160), 2 },
                    { 3, 1, new DateTime(2024, 2, 14, 11, 14, 3, 790, DateTimeKind.Utc).AddTicks(3160), 3 },
                    { 4, 3, new DateTime(2024, 2, 14, 11, 14, 3, 790, DateTimeKind.Utc).AddTicks(3160), 4 },
                    { 5, 2, new DateTime(2024, 2, 14, 11, 14, 3, 790, DateTimeKind.Utc).AddTicks(3160), 4 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Enrollments_CourseId",
                table: "Enrollments",
                column: "CourseId");

            migrationBuilder.CreateIndex(
                name: "IX_Enrollments_StudentId",
                table: "Enrollments",
                column: "StudentId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Enrollments");

            migrationBuilder.DropTable(
                name: "Courses");

            migrationBuilder.DropTable(
                name: "Students");
        }
    }
}
