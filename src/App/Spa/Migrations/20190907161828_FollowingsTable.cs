using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace AdisBlog.Migrations
{
    public partial class FollowingsTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "followings",
                columns: table => new
                {
                    id = table.Column<Guid>(nullable: false),
                    created_at = table.Column<DateTime>(nullable: false),
                    updated_at = table.Column<DateTime>(nullable: false),
                    following_user_id = table.Column<Guid>(nullable: false),
                    user_id = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_followings", x => x.id);
                    table.ForeignKey(
                        name: "FK_followings_users_user_id",
                        column: x => x.user_id,
                        principalTable: "users",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

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

            migrationBuilder.CreateIndex(
                name: "IX_followings_user_id",
                table: "followings",
                column: "user_id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "followings");

            migrationBuilder.UpdateData(
                table: "tags",
                keyColumn: "id",
                keyValue: new Guid("0f8fad5b-d3cb-469f-a165-712677284194"),
                columns: new[] { "created_at", "updated_at" },
                values: new object[] { new DateTime(2019, 8, 5, 21, 16, 31, 410, DateTimeKind.Local).AddTicks(8396), new DateTime(2019, 8, 5, 21, 16, 31, 410, DateTimeKind.Local).AddTicks(8399) });

            migrationBuilder.UpdateData(
                table: "tags",
                keyColumn: "id",
                keyValue: new Guid("0f8fad5b-d3cb-469f-a165-71267728950e"),
                columns: new[] { "created_at", "updated_at" },
                values: new object[] { new DateTime(2019, 8, 5, 21, 16, 31, 410, DateTimeKind.Local).AddTicks(8351), new DateTime(2019, 8, 5, 21, 16, 31, 410, DateTimeKind.Local).AddTicks(8365) });

            migrationBuilder.UpdateData(
                table: "tags",
                keyColumn: "id",
                keyValue: new Guid("8914ad5b-d3cb-469f-a165-71267728950e"),
                columns: new[] { "created_at", "updated_at" },
                values: new object[] { new DateTime(2019, 8, 5, 21, 16, 31, 410, DateTimeKind.Local).AddTicks(8408), new DateTime(2019, 8, 5, 21, 16, 31, 410, DateTimeKind.Local).AddTicks(8409) });

            migrationBuilder.UpdateData(
                table: "users",
                keyColumn: "id",
                keyValue: new Guid("0f8fad5b-d9cb-469f-a165-70867728950e"),
                columns: new[] { "created_at", "password", "updated_at" },
                values: new object[] { new DateTime(2019, 8, 5, 21, 16, 31, 299, DateTimeKind.Local).AddTicks(5388), "$2a$10$KDruOWg2NqWpGqyYX93z7u.N/kvpgCcIwzT0X8hK2HejLxEiMyimO", new DateTime(2019, 8, 5, 21, 16, 31, 299, DateTimeKind.Local).AddTicks(9931) });

            migrationBuilder.UpdateData(
                table: "users",
                keyColumn: "id",
                keyValue: new Guid("7c9e6679-7425-40de-944b-e07fc1f90ae7"),
                columns: new[] { "created_at", "password", "updated_at" },
                values: new object[] { new DateTime(2019, 8, 5, 21, 16, 31, 391, DateTimeKind.Local).AddTicks(846), "$2a$10$ApODPs7zY80ho3dThYv.5.tr5lx7lX17UBpRXftQzkCXF9FaLFEwi", new DateTime(2019, 8, 5, 21, 16, 31, 391, DateTimeKind.Local).AddTicks(866) });
        }
    }
}
