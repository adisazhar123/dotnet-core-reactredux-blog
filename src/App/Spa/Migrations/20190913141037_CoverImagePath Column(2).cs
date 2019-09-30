using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace AdisBlog.Migrations
{
    public partial class CoverImagePathColumn2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "tags",
                keyColumn: "id",
                keyValue: new Guid("0f8fad5b-d3cb-469f-a165-712677284194"),
                columns: new[] { "created_at", "updated_at" },
                values: new object[] { new DateTime(2019, 9, 13, 21, 10, 37, 525, DateTimeKind.Local).AddTicks(2810), new DateTime(2019, 9, 13, 21, 10, 37, 525, DateTimeKind.Local).AddTicks(2812) });

            migrationBuilder.UpdateData(
                table: "tags",
                keyColumn: "id",
                keyValue: new Guid("0f8fad5b-d3cb-469f-a165-71267728950e"),
                columns: new[] { "created_at", "updated_at" },
                values: new object[] { new DateTime(2019, 9, 13, 21, 10, 37, 525, DateTimeKind.Local).AddTicks(2761), new DateTime(2019, 9, 13, 21, 10, 37, 525, DateTimeKind.Local).AddTicks(2782) });

            migrationBuilder.UpdateData(
                table: "tags",
                keyColumn: "id",
                keyValue: new Guid("8914ad5b-d3cb-469f-a165-71267728950e"),
                columns: new[] { "created_at", "updated_at" },
                values: new object[] { new DateTime(2019, 9, 13, 21, 10, 37, 525, DateTimeKind.Local).AddTicks(2820), new DateTime(2019, 9, 13, 21, 10, 37, 525, DateTimeKind.Local).AddTicks(2821) });

            migrationBuilder.UpdateData(
                table: "users",
                keyColumn: "id",
                keyValue: new Guid("0f8fad5b-d9cb-469f-a165-70867728950e"),
                columns: new[] { "created_at", "password", "updated_at" },
                values: new object[] { new DateTime(2019, 9, 13, 21, 10, 37, 422, DateTimeKind.Local).AddTicks(8287), "$2a$10$IlHQbsNFDvsbdXQSdn2W.OGZ/AtjdysSusiOykl9aBNThRPGTimxW", new DateTime(2019, 9, 13, 21, 10, 37, 423, DateTimeKind.Local).AddTicks(2814) });

            migrationBuilder.UpdateData(
                table: "users",
                keyColumn: "id",
                keyValue: new Guid("7c9e6679-7425-40de-944b-e07fc1f90ae7"),
                columns: new[] { "created_at", "password", "updated_at" },
                values: new object[] { new DateTime(2019, 9, 13, 21, 10, 37, 504, DateTimeKind.Local).AddTicks(4014), "$2a$10$3m.tJ3mMLklwk47wFx5xgO2epcygKXbb/UOK/ZeMkhgejNqvjUZcW", new DateTime(2019, 9, 13, 21, 10, 37, 504, DateTimeKind.Local).AddTicks(4038) });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "tags",
                keyColumn: "id",
                keyValue: new Guid("0f8fad5b-d3cb-469f-a165-712677284194"),
                columns: new[] { "created_at", "updated_at" },
                values: new object[] { new DateTime(2019, 9, 13, 21, 7, 52, 700, DateTimeKind.Local).AddTicks(3740), new DateTime(2019, 9, 13, 21, 7, 52, 700, DateTimeKind.Local).AddTicks(3742) });

            migrationBuilder.UpdateData(
                table: "tags",
                keyColumn: "id",
                keyValue: new Guid("0f8fad5b-d3cb-469f-a165-71267728950e"),
                columns: new[] { "created_at", "updated_at" },
                values: new object[] { new DateTime(2019, 9, 13, 21, 7, 52, 700, DateTimeKind.Local).AddTicks(3696), new DateTime(2019, 9, 13, 21, 7, 52, 700, DateTimeKind.Local).AddTicks(3714) });

            migrationBuilder.UpdateData(
                table: "tags",
                keyColumn: "id",
                keyValue: new Guid("8914ad5b-d3cb-469f-a165-71267728950e"),
                columns: new[] { "created_at", "updated_at" },
                values: new object[] { new DateTime(2019, 9, 13, 21, 7, 52, 700, DateTimeKind.Local).AddTicks(3749), new DateTime(2019, 9, 13, 21, 7, 52, 700, DateTimeKind.Local).AddTicks(3751) });

            migrationBuilder.UpdateData(
                table: "users",
                keyColumn: "id",
                keyValue: new Guid("0f8fad5b-d9cb-469f-a165-70867728950e"),
                columns: new[] { "created_at", "password", "updated_at" },
                values: new object[] { new DateTime(2019, 9, 13, 21, 7, 52, 591, DateTimeKind.Local).AddTicks(3792), "$2a$10$dNgzNvexyTsZN/I6DF41n.MsWARQHIZFoSfVRyQM/TpLDwqgw65du", new DateTime(2019, 9, 13, 21, 7, 52, 592, DateTimeKind.Local).AddTicks(24) });

            migrationBuilder.UpdateData(
                table: "users",
                keyColumn: "id",
                keyValue: new Guid("7c9e6679-7425-40de-944b-e07fc1f90ae7"),
                columns: new[] { "created_at", "password", "updated_at" },
                values: new object[] { new DateTime(2019, 9, 13, 21, 7, 52, 674, DateTimeKind.Local).AddTicks(9630), "$2a$10$cDP.tuMMV/dSV5YOJ1fOKOw0AaGfZMtSV1QThgZ7tPXHVBkpjOLaq", new DateTime(2019, 9, 13, 21, 7, 52, 674, DateTimeKind.Local).AddTicks(9650) });
        }
    }
}
