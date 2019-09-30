using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace AdisBlog.Migrations
{
    public partial class CoverImagePathColumn : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "cover_image_path",
                table: "posts",
                nullable: true);

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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "cover_image_path",
                table: "posts");

            migrationBuilder.UpdateData(
                table: "tags",
                keyColumn: "id",
                keyValue: new Guid("0f8fad5b-d3cb-469f-a165-712677284194"),
                columns: new[] { "created_at", "updated_at" },
                values: new object[] { new DateTime(2019, 9, 7, 23, 18, 27, 523, DateTimeKind.Local).AddTicks(7859), new DateTime(2019, 9, 7, 23, 18, 27, 523, DateTimeKind.Local).AddTicks(7862) });

            migrationBuilder.UpdateData(
                table: "tags",
                keyColumn: "id",
                keyValue: new Guid("0f8fad5b-d3cb-469f-a165-71267728950e"),
                columns: new[] { "created_at", "updated_at" },
                values: new object[] { new DateTime(2019, 9, 7, 23, 18, 27, 523, DateTimeKind.Local).AddTicks(7801), new DateTime(2019, 9, 7, 23, 18, 27, 523, DateTimeKind.Local).AddTicks(7825) });

            migrationBuilder.UpdateData(
                table: "tags",
                keyColumn: "id",
                keyValue: new Guid("8914ad5b-d3cb-469f-a165-71267728950e"),
                columns: new[] { "created_at", "updated_at" },
                values: new object[] { new DateTime(2019, 9, 7, 23, 18, 27, 523, DateTimeKind.Local).AddTicks(7872), new DateTime(2019, 9, 7, 23, 18, 27, 523, DateTimeKind.Local).AddTicks(7875) });

            migrationBuilder.UpdateData(
                table: "users",
                keyColumn: "id",
                keyValue: new Guid("0f8fad5b-d9cb-469f-a165-70867728950e"),
                columns: new[] { "created_at", "password", "updated_at" },
                values: new object[] { new DateTime(2019, 9, 7, 23, 18, 27, 392, DateTimeKind.Local).AddTicks(1250), "$2a$10$Y2VewsGhsDi5McA/QvDxJOAPj4/GX15BAb2E5qhkaKglNkmNiKlqi", new DateTime(2019, 9, 7, 23, 18, 27, 392, DateTimeKind.Local).AddTicks(9655) });

            migrationBuilder.UpdateData(
                table: "users",
                keyColumn: "id",
                keyValue: new Guid("7c9e6679-7425-40de-944b-e07fc1f90ae7"),
                columns: new[] { "created_at", "password", "updated_at" },
                values: new object[] { new DateTime(2019, 9, 7, 23, 18, 27, 483, DateTimeKind.Local).AddTicks(5438), "$2a$10$mybO8hwFDR0LXE/at1VG7eDh0XWtVvhz.n82bx2vB517qZaR94sFC", new DateTime(2019, 9, 7, 23, 18, 27, 483, DateTimeKind.Local).AddTicks(5468) });
        }
    }
}
