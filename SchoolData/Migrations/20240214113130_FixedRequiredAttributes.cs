using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SchoolData.Migrations
{
    /// <inheritdoc />
    public partial class FixedRequiredAttributes : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "Age",
                table: "Students",
                type: "integer",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "Courses",
                type: "text",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.UpdateData(
                table: "Enrollments",
                keyColumn: "EnrollmentId",
                keyValue: 1,
                column: "EnrollmentDate",
                value: new DateTime(2024, 2, 14, 11, 31, 30, 420, DateTimeKind.Utc).AddTicks(4600));

            migrationBuilder.UpdateData(
                table: "Enrollments",
                keyColumn: "EnrollmentId",
                keyValue: 2,
                column: "EnrollmentDate",
                value: new DateTime(2024, 2, 14, 11, 31, 30, 420, DateTimeKind.Utc).AddTicks(4600));

            migrationBuilder.UpdateData(
                table: "Enrollments",
                keyColumn: "EnrollmentId",
                keyValue: 3,
                column: "EnrollmentDate",
                value: new DateTime(2024, 2, 14, 11, 31, 30, 420, DateTimeKind.Utc).AddTicks(4610));

            migrationBuilder.UpdateData(
                table: "Enrollments",
                keyColumn: "EnrollmentId",
                keyValue: 4,
                column: "EnrollmentDate",
                value: new DateTime(2024, 2, 14, 11, 31, 30, 420, DateTimeKind.Utc).AddTicks(4610));

            migrationBuilder.UpdateData(
                table: "Enrollments",
                keyColumn: "EnrollmentId",
                keyValue: 5,
                column: "EnrollmentDate",
                value: new DateTime(2024, 2, 14, 11, 31, 30, 420, DateTimeKind.Utc).AddTicks(4610));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "Age",
                table: "Students",
                type: "integer",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "integer",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "Courses",
                type: "text",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);

            migrationBuilder.UpdateData(
                table: "Enrollments",
                keyColumn: "EnrollmentId",
                keyValue: 1,
                column: "EnrollmentDate",
                value: new DateTime(2024, 2, 14, 11, 14, 3, 790, DateTimeKind.Utc).AddTicks(3160));

            migrationBuilder.UpdateData(
                table: "Enrollments",
                keyColumn: "EnrollmentId",
                keyValue: 2,
                column: "EnrollmentDate",
                value: new DateTime(2024, 2, 14, 11, 14, 3, 790, DateTimeKind.Utc).AddTicks(3160));

            migrationBuilder.UpdateData(
                table: "Enrollments",
                keyColumn: "EnrollmentId",
                keyValue: 3,
                column: "EnrollmentDate",
                value: new DateTime(2024, 2, 14, 11, 14, 3, 790, DateTimeKind.Utc).AddTicks(3160));

            migrationBuilder.UpdateData(
                table: "Enrollments",
                keyColumn: "EnrollmentId",
                keyValue: 4,
                column: "EnrollmentDate",
                value: new DateTime(2024, 2, 14, 11, 14, 3, 790, DateTimeKind.Utc).AddTicks(3160));

            migrationBuilder.UpdateData(
                table: "Enrollments",
                keyColumn: "EnrollmentId",
                keyValue: 5,
                column: "EnrollmentDate",
                value: new DateTime(2024, 2, 14, 11, 14, 3, 790, DateTimeKind.Utc).AddTicks(3160));
        }
    }
}
