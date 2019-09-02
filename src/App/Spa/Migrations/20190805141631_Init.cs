using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace AdisBlog.Migrations
{
    public partial class Init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "tags",
                columns: table => new
                {
                    id = table.Column<Guid>(nullable: false),
                    created_at = table.Column<DateTime>(nullable: false),
                    updated_at = table.Column<DateTime>(nullable: false),
                    title = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tags", x => x.id);
                });

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
                name: "favorite_posts",
                columns: table => new
                {
                    id = table.Column<Guid>(nullable: false),
                    created_at = table.Column<DateTime>(nullable: false),
                    updated_at = table.Column<DateTime>(nullable: false),
                    post_id = table.Column<Guid>(nullable: false),
                    user_id = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_favorite_posts", x => x.id);
                    table.ForeignKey(
                        name: "FK_favorite_posts_users_user_id",
                        column: x => x.user_id,
                        principalTable: "users",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
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
                name: "comments",
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
                    table.PrimaryKey("PK_comments", x => x.id);
                    table.ForeignKey(
                        name: "FK_comments_posts_post_id",
                        column: x => x.post_id,
                        principalTable: "posts",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "post_tag",
                columns: table => new
                {
                    post_id = table.Column<Guid>(nullable: false),
                    tag_id = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_post_tag", x => new { x.post_id, x.tag_id });
                    table.ForeignKey(
                        name: "FK_post_tag_posts_post_id",
                        column: x => x.post_id,
                        principalTable: "posts",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_post_tag_tags_tag_id",
                        column: x => x.tag_id,
                        principalTable: "tags",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "tags",
                columns: new[] { "id", "created_at", "title", "updated_at" },
                values: new object[,]
                {
                    { new Guid("0f8fad5b-d3cb-469f-a165-71267728950e"), new DateTime(2019, 8, 5, 21, 16, 31, 410, DateTimeKind.Local).AddTicks(8351), "Computer Science", new DateTime(2019, 8, 5, 21, 16, 31, 410, DateTimeKind.Local).AddTicks(8365) },
                    { new Guid("0f8fad5b-d3cb-469f-a165-712677284194"), new DateTime(2019, 8, 5, 21, 16, 31, 410, DateTimeKind.Local).AddTicks(8396), "Sports", new DateTime(2019, 8, 5, 21, 16, 31, 410, DateTimeKind.Local).AddTicks(8399) },
                    { new Guid("8914ad5b-d3cb-469f-a165-71267728950e"), new DateTime(2019, 8, 5, 21, 16, 31, 410, DateTimeKind.Local).AddTicks(8408), "Lifestyle", new DateTime(2019, 8, 5, 21, 16, 31, 410, DateTimeKind.Local).AddTicks(8409) }
                });

            migrationBuilder.InsertData(
                table: "users",
                columns: new[] { "id", "created_at", "password", "role", "updated_at", "username" },
                values: new object[,]
                {
                    { new Guid("0f8fad5b-d9cb-469f-a165-70867728950e"), new DateTime(2019, 8, 5, 21, 16, 31, 299, DateTimeKind.Local).AddTicks(5388), "$2a$10$KDruOWg2NqWpGqyYX93z7u.N/kvpgCcIwzT0X8hK2HejLxEiMyimO", "user", new DateTime(2019, 8, 5, 21, 16, 31, 299, DateTimeKind.Local).AddTicks(9931), "adis" },
                    { new Guid("7c9e6679-7425-40de-944b-e07fc1f90ae7"), new DateTime(2019, 8, 5, 21, 16, 31, 391, DateTimeKind.Local).AddTicks(846), "$2a$10$ApODPs7zY80ho3dThYv.5.tr5lx7lX17UBpRXftQzkCXF9FaLFEwi", "admin", new DateTime(2019, 8, 5, 21, 16, 31, 391, DateTimeKind.Local).AddTicks(866), "admin" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_comments_post_id",
                table: "comments",
                column: "post_id");

            migrationBuilder.CreateIndex(
                name: "IX_favorite_posts_user_id_post_id",
                table: "favorite_posts",
                columns: new[] { "user_id", "post_id" });

            migrationBuilder.CreateIndex(
                name: "IX_post_tag_tag_id",
                table: "post_tag",
                column: "tag_id");

            migrationBuilder.CreateIndex(
                name: "IX_posts_user_id",
                table: "posts",
                column: "user_id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "comments");

            migrationBuilder.DropTable(
                name: "favorite_posts");

            migrationBuilder.DropTable(
                name: "post_tag");

            migrationBuilder.DropTable(
                name: "posts");

            migrationBuilder.DropTable(
                name: "tags");

            migrationBuilder.DropTable(
                name: "users");
        }
    }
}
