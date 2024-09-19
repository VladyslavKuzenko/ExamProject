using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EasyLearn.Migrations
{
    /// <inheritdoc />
    public partial class m3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "user123",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "a77d1367-2519-4a03-a162-92920ce4357c", "ce6bad61-ddf6-4978-884f-1ced4a2a328c" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "user456",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "44d29c5d-cbc5-41e9-9651-da65c335bbe4", "9dea162c-2254-48be-871f-d3187e7d8aa4" });

            migrationBuilder.UpdateData(
                table: "Course",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Create", "LastOpen" },
                values: new object[] { new DateTime(2024, 9, 15, 17, 7, 1, 283, DateTimeKind.Local).AddTicks(6759), new DateTime(2024, 9, 15, 17, 7, 1, 283, DateTimeKind.Local).AddTicks(6826) });

            migrationBuilder.UpdateData(
                table: "Course",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Create", "LastOpen" },
                values: new object[] { new DateTime(2024, 9, 15, 17, 7, 1, 283, DateTimeKind.Local).AddTicks(6829), new DateTime(2024, 9, 15, 17, 7, 1, 283, DateTimeKind.Local).AddTicks(6831) });

            migrationBuilder.UpdateData(
                table: "Folder",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Create", "LastOpen" },
                values: new object[] { new DateTime(2024, 9, 15, 17, 7, 1, 283, DateTimeKind.Local).AddTicks(6873), new DateTime(2024, 9, 15, 17, 7, 1, 283, DateTimeKind.Local).AddTicks(6875) });

            migrationBuilder.UpdateData(
                table: "Folder",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Create", "LastOpen" },
                values: new object[] { new DateTime(2024, 9, 15, 17, 7, 1, 283, DateTimeKind.Local).AddTicks(6880), new DateTime(2024, 9, 15, 17, 7, 1, 283, DateTimeKind.Local).AddTicks(6882) });

            migrationBuilder.UpdateData(
                table: "TrainingModule",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Create", "LastOpen" },
                values: new object[] { new DateTime(2024, 9, 15, 17, 7, 1, 283, DateTimeKind.Local).AddTicks(6916), new DateTime(2024, 9, 15, 17, 7, 1, 283, DateTimeKind.Local).AddTicks(6920) });

            migrationBuilder.UpdateData(
                table: "TrainingModule",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Create", "LastOpen" },
                values: new object[] { new DateTime(2024, 9, 15, 17, 7, 1, 283, DateTimeKind.Local).AddTicks(6925), new DateTime(2024, 9, 15, 17, 7, 1, 283, DateTimeKind.Local).AddTicks(6926) });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
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
    }
}
