using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace AdisBlog.Migrations
{
    public partial class Init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "users",
                columns: table => new
                {
                    id = table.Column<Guid>(nullable: false),
                    created_at = table.Column<DateTime>(nullable: false),
                    updated_at = table.Column<DateTime>(nullable: false),
                    username = table.Column<string>(nullable: false),
                    password = table.Column<string>(nullable: false),
                    role = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_users", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "posts",
                columns: table => new
                {
                    id = table.Column<Guid>(nullable: false),
                    created_at = table.Column<DateTime>(nullable: false),
                    updated_at = table.Column<DateTime>(nullable: false),
                    title = table.Column<string>(nullable: false),
                    body = table.Column<string>(nullable: false),
                    user_id = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_posts", x => x.id);
                    table.ForeignKey(
                        name: "FK_posts_users_user_id",
                        column: x => x.user_id,
                        principalTable: "users",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Comments",
                columns: table => new
                {
                    id = table.Column<Guid>(nullable: false),
                    created_at = table.Column<DateTime>(nullable: false),
                    updated_at = table.Column<DateTime>(nullable: false),
                    body = table.Column<string>(nullable: true),
                    post_id = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Comments", x => x.id);
                    table.ForeignKey(
                        name: "FK_Comments_posts_post_id",
                        column: x => x.post_id,
                        principalTable: "posts",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "users",
                columns: new[] { "id", "created_at", "password", "role", "updated_at", "username" },
                values: new object[] { new Guid("0f8fad5b-d9cb-469f-a165-70867728950e"), new DateTime(2019, 7, 29, 16, 36, 4, 727, DateTimeKind.Local).AddTicks(90), "$2a$10$UyZF9oHdoBrlkAu982q9ve0NxWpQgKfYi9ydJf3UU4dwItnKG62fC", "user", new DateTime(2019, 7, 29, 16, 36, 4, 727, DateTimeKind.Local).AddTicks(7081), "adis" });

            migrationBuilder.InsertData(
                table: "users",
                columns: new[] { "id", "created_at", "password", "role", "updated_at", "username" },
                values: new object[] { new Guid("7c9e6679-7425-40de-944b-e07fc1f90ae7"), new DateTime(2019, 7, 29, 16, 36, 4, 840, DateTimeKind.Local).AddTicks(335), "$2a$10$f7MW.PWQ2PIgrFPsygEbUes3JYunEOYZHqzRK8rOawmEUh/g47KdG", "admin", new DateTime(2019, 7, 29, 16, 36, 4, 840, DateTimeKind.Local).AddTicks(363), "admin" });

            migrationBuilder.CreateIndex(
                name: "IX_Comments_post_id",
                table: "Comments",
                column: "post_id");

            migrationBuilder.CreateIndex(
                name: "IX_posts_user_id",
                table: "posts",
                column: "user_id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Comments");

            migrationBuilder.DropTable(
                name: "posts");

            migrationBuilder.DropTable(
                name: "users");
        }
    }
}
