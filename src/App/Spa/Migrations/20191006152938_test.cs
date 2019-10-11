using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace AdisBlog.Migrations
{
    public partial class test : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "tags",
                keyColumn: "id",
                keyValue: new Guid("0f8fad5b-d3cb-469f-a165-712677284194"),
                columns: new[] { "created_at", "updated_at" },
                values: new object[] { new DateTime(2019, 10, 6, 22, 29, 38, 391, DateTimeKind.Local).AddTicks(7546), new DateTime(2019, 10, 6, 22, 29, 38, 391, DateTimeKind.Local).AddTicks(7550) });

            migrationBuilder.UpdateData(
                table: "tags",
                keyColumn: "id",
                keyValue: new Guid("0f8fad5b-d3cb-469f-a165-71267728950e"),
                columns: new[] { "created_at", "updated_at" },
                values: new object[] { new DateTime(2019, 10, 6, 22, 29, 38, 391, DateTimeKind.Local).AddTicks(7482), new DateTime(2019, 10, 6, 22, 29, 38, 391, DateTimeKind.Local).AddTicks(7502) });

            migrationBuilder.UpdateData(
                table: "tags",
                keyColumn: "id",
                keyValue: new Guid("8914ad5b-d3cb-469f-a165-71267728950e"),
                columns: new[] { "created_at", "updated_at" },
                values: new object[] { new DateTime(2019, 10, 6, 22, 29, 38, 391, DateTimeKind.Local).AddTicks(7565), new DateTime(2019, 10, 6, 22, 29, 38, 391, DateTimeKind.Local).AddTicks(7568) });

            migrationBuilder.UpdateData(
                table: "users",
                keyColumn: "id",
                keyValue: new Guid("0f8fad5b-d9cb-469f-a165-70867728950e"),
                columns: new[] { "created_at", "password", "updated_at" },
                values: new object[] { new DateTime(2019, 10, 6, 22, 29, 38, 266, DateTimeKind.Local).AddTicks(3039), "$2a$10$Xhd.AXitmQ2UE8DVg37vNOyJT4AuOjohnPFu46GE4uS6D1jTS94N.", new DateTime(2019, 10, 6, 22, 29, 38, 275, DateTimeKind.Local).AddTicks(7248) });

            migrationBuilder.UpdateData(
                table: "users",
                keyColumn: "id",
                keyValue: new Guid("7c9e6679-7425-40de-944b-e07fc1f90ae7"),
                columns: new[] { "created_at", "password", "updated_at" },
                values: new object[] { new DateTime(2019, 10, 6, 22, 29, 38, 369, DateTimeKind.Local).AddTicks(3647), "$2a$10$NgY9nqEHK4mGRTPW6HmdhOiDQ.JT9QV/ScwnmrNXW9fUS6rQ8kJVC", new DateTime(2019, 10, 6, 22, 29, 38, 369, DateTimeKind.Local).AddTicks(3671) });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "tags",
                keyColumn: "id",
                keyValue: new Guid("0f8fad5b-d3cb-469f-a165-712677284194"),
                columns: new[] { "created_at", "updated_at" },
                values: new object[] { new DateTime(2019, 10, 5, 19, 54, 39, 733, DateTimeKind.Local).AddTicks(6268), new DateTime(2019, 10, 5, 19, 54, 39, 733, DateTimeKind.Local).AddTicks(6270) });

            migrationBuilder.UpdateData(
                table: "tags",
                keyColumn: "id",
                keyValue: new Guid("0f8fad5b-d3cb-469f-a165-71267728950e"),
                columns: new[] { "created_at", "updated_at" },
                values: new object[] { new DateTime(2019, 10, 5, 19, 54, 39, 733, DateTimeKind.Local).AddTicks(6220), new DateTime(2019, 10, 5, 19, 54, 39, 733, DateTimeKind.Local).AddTicks(6240) });

            migrationBuilder.UpdateData(
                table: "tags",
                keyColumn: "id",
                keyValue: new Guid("8914ad5b-d3cb-469f-a165-71267728950e"),
                columns: new[] { "created_at", "updated_at" },
                values: new object[] { new DateTime(2019, 10, 5, 19, 54, 39, 733, DateTimeKind.Local).AddTicks(6278), new DateTime(2019, 10, 5, 19, 54, 39, 733, DateTimeKind.Local).AddTicks(6280) });

            migrationBuilder.UpdateData(
                table: "users",
                keyColumn: "id",
                keyValue: new Guid("0f8fad5b-d9cb-469f-a165-70867728950e"),
                columns: new[] { "created_at", "password", "updated_at" },
                values: new object[] { new DateTime(2019, 10, 5, 19, 54, 39, 617, DateTimeKind.Local).AddTicks(8698), "$2a$10$UwdIHQ90SUPzZRXeeE1KkeRJ2MeQm1O8KvPZMmYidLPr/AS18tARy", new DateTime(2019, 10, 5, 19, 54, 39, 632, DateTimeKind.Local).AddTicks(3071) });

            migrationBuilder.UpdateData(
                table: "users",
                keyColumn: "id",
                keyValue: new Guid("7c9e6679-7425-40de-944b-e07fc1f90ae7"),
                columns: new[] { "created_at", "password", "updated_at" },
                values: new object[] { new DateTime(2019, 10, 5, 19, 54, 39, 713, DateTimeKind.Local).AddTicks(5674), "$2a$10$zi0xHnz1D5M7uqxdtMz10.bnXpezmgJlGCZtjeCdeewTVRBbQ3b3y", new DateTime(2019, 10, 5, 19, 54, 39, 713, DateTimeKind.Local).AddTicks(5696) });
        }
    }
}
