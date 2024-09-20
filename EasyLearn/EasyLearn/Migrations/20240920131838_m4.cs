using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EasyLearn.Migrations
{
    /// <inheritdoc />
    public partial class m4 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "user123",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "81d38d61-a63e-4c5b-9f85-b479ab97641c", "bbb1307c-7efa-46fc-a248-f6228adcfcd0" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "user456",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "292dbeb7-fc97-413e-bcfc-8f69d3a9e404", "6ec0f02f-dad4-4295-abc5-cdedc391cf7c" });

            migrationBuilder.UpdateData(
                table: "Course",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Create", "LastOpen" },
                values: new object[] { new DateTime(2024, 9, 20, 15, 18, 36, 748, DateTimeKind.Local).AddTicks(8552), new DateTime(2024, 9, 20, 15, 18, 36, 748, DateTimeKind.Local).AddTicks(8604) });

            migrationBuilder.UpdateData(
                table: "Course",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Create", "LastOpen" },
                values: new object[] { new DateTime(2024, 9, 20, 15, 18, 36, 748, DateTimeKind.Local).AddTicks(8606), new DateTime(2024, 9, 20, 15, 18, 36, 748, DateTimeKind.Local).AddTicks(8607) });

            migrationBuilder.UpdateData(
                table: "Folder",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Create", "LastOpen" },
                values: new object[] { new DateTime(2024, 9, 20, 15, 18, 36, 748, DateTimeKind.Local).AddTicks(8634), new DateTime(2024, 9, 20, 15, 18, 36, 748, DateTimeKind.Local).AddTicks(8635) });

            migrationBuilder.UpdateData(
                table: "Folder",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Create", "LastOpen" },
                values: new object[] { new DateTime(2024, 9, 20, 15, 18, 36, 748, DateTimeKind.Local).AddTicks(8638), new DateTime(2024, 9, 20, 15, 18, 36, 748, DateTimeKind.Local).AddTicks(8639) });

            migrationBuilder.UpdateData(
                table: "TrainingModule",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Create", "LastOpen" },
                values: new object[] { new DateTime(2024, 9, 20, 15, 18, 36, 748, DateTimeKind.Local).AddTicks(8669), new DateTime(2024, 9, 20, 15, 18, 36, 748, DateTimeKind.Local).AddTicks(8671) });

            migrationBuilder.UpdateData(
                table: "TrainingModule",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Create", "LastOpen" },
                values: new object[] { new DateTime(2024, 9, 20, 15, 18, 36, 748, DateTimeKind.Local).AddTicks(8675), new DateTime(2024, 9, 20, 15, 18, 36, 748, DateTimeKind.Local).AddTicks(8676) });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
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
    }
}
