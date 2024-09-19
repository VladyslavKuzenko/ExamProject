using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EasyLearn.Migrations
{
    /// <inheritdoc />
    public partial class m2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "user123",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "01dfe6f3-d1e5-4ce7-9996-6612dce3eee1", "ccb73965-3783-4b35-9ec2-a1fcdb998fa8" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "user456",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "827eb787-ebf9-4d37-bf09-9d39f60ad0f5", "c874c0f6-cac5-4f19-86a8-eef8be58a7dd" });

            migrationBuilder.UpdateData(
                table: "Course",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Create", "LastOpen" },
                values: new object[] { new DateTime(2024, 9, 15, 16, 53, 42, 628, DateTimeKind.Local).AddTicks(1309), new DateTime(2024, 9, 15, 16, 53, 42, 628, DateTimeKind.Local).AddTicks(1358) });

            migrationBuilder.UpdateData(
                table: "Course",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Create", "LastOpen" },
                values: new object[] { new DateTime(2024, 9, 15, 16, 53, 42, 628, DateTimeKind.Local).AddTicks(1365), new DateTime(2024, 9, 15, 16, 53, 42, 628, DateTimeKind.Local).AddTicks(1366) });

            migrationBuilder.UpdateData(
                table: "Folder",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Create", "LastOpen" },
                values: new object[] { new DateTime(2024, 9, 15, 16, 53, 42, 628, DateTimeKind.Local).AddTicks(1388), new DateTime(2024, 9, 15, 16, 53, 42, 628, DateTimeKind.Local).AddTicks(1390) });

            migrationBuilder.UpdateData(
                table: "Folder",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Create", "LastOpen" },
                values: new object[] { new DateTime(2024, 9, 15, 16, 53, 42, 628, DateTimeKind.Local).AddTicks(1392), new DateTime(2024, 9, 15, 16, 53, 42, 628, DateTimeKind.Local).AddTicks(1394) });

            migrationBuilder.UpdateData(
                table: "TrainingModule",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Create", "LastOpen" },
                values: new object[] { new DateTime(2024, 9, 15, 16, 53, 42, 628, DateTimeKind.Local).AddTicks(1415), new DateTime(2024, 9, 15, 16, 53, 42, 628, DateTimeKind.Local).AddTicks(1416) });

            migrationBuilder.UpdateData(
                table: "TrainingModule",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Create", "LastOpen" },
                values: new object[] { new DateTime(2024, 9, 15, 16, 53, 42, 628, DateTimeKind.Local).AddTicks(1419), new DateTime(2024, 9, 15, 16, 53, 42, 628, DateTimeKind.Local).AddTicks(1420) });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "user123",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "3244dd3a-4ca1-4a83-90e5-5cfeb732d66b", "a51b6afb-249b-449d-8ea4-1b0fad7e3266" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "user456",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "b6eadd41-5b87-4642-96bd-91d8c0d06729", "f6931657-afbd-4a82-a9bb-22a444283f7b" });

            migrationBuilder.UpdateData(
                table: "Course",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Create", "LastOpen" },
                values: new object[] { new DateTime(2024, 9, 15, 13, 27, 16, 53, DateTimeKind.Local).AddTicks(5781), new DateTime(2024, 9, 15, 13, 27, 16, 53, DateTimeKind.Local).AddTicks(5836) });

            migrationBuilder.UpdateData(
                table: "Course",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Create", "LastOpen" },
                values: new object[] { new DateTime(2024, 9, 15, 13, 27, 16, 53, DateTimeKind.Local).AddTicks(5838), new DateTime(2024, 9, 15, 13, 27, 16, 53, DateTimeKind.Local).AddTicks(5840) });

            migrationBuilder.UpdateData(
                table: "Folder",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Create", "LastOpen" },
                values: new object[] { new DateTime(2024, 9, 15, 13, 27, 16, 53, DateTimeKind.Local).AddTicks(5865), new DateTime(2024, 9, 15, 13, 27, 16, 53, DateTimeKind.Local).AddTicks(5866) });

            migrationBuilder.UpdateData(
                table: "Folder",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Create", "LastOpen" },
                values: new object[] { new DateTime(2024, 9, 15, 13, 27, 16, 53, DateTimeKind.Local).AddTicks(5871), new DateTime(2024, 9, 15, 13, 27, 16, 53, DateTimeKind.Local).AddTicks(5872) });

            migrationBuilder.UpdateData(
                table: "TrainingModule",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Create", "LastOpen" },
                values: new object[] { new DateTime(2024, 9, 15, 13, 27, 16, 53, DateTimeKind.Local).AddTicks(5896), new DateTime(2024, 9, 15, 13, 27, 16, 53, DateTimeKind.Local).AddTicks(5897) });

            migrationBuilder.UpdateData(
                table: "TrainingModule",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Create", "LastOpen" },
                values: new object[] { new DateTime(2024, 9, 15, 13, 27, 16, 53, DateTimeKind.Local).AddTicks(5900), new DateTime(2024, 9, 15, 13, 27, 16, 53, DateTimeKind.Local).AddTicks(5901) });
        }
    }
}
