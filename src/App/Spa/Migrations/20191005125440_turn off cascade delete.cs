using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace AdisBlog.Migrations
{
    public partial class turnoffcascadedelete : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_comments_posts_post_id",
                table: "comments");

            migrationBuilder.DropForeignKey(
                name: "FK_favorite_posts_users_user_id",
                table: "favorite_posts");

            migrationBuilder.DropForeignKey(
                name: "FK_followings_users_user_id",
                table: "followings");

            migrationBuilder.DropForeignKey(
                name: "FK_post_tag_posts_post_id",
                table: "post_tag");

            migrationBuilder.DropForeignKey(
                name: "FK_post_tag_tags_tag_id",
                table: "post_tag");

            migrationBuilder.DropForeignKey(
                name: "FK_posts_users_user_id",
                table: "posts");

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

            migrationBuilder.AddForeignKey(
                name: "FK_comments_posts_post_id",
                table: "comments",
                column: "post_id",
                principalTable: "posts",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_favorite_posts_users_user_id",
                table: "favorite_posts",
                column: "user_id",
                principalTable: "users",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_followings_users_user_id",
                table: "followings",
                column: "user_id",
                principalTable: "users",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_post_tag_posts_post_id",
                table: "post_tag",
                column: "post_id",
                principalTable: "posts",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_post_tag_tags_tag_id",
                table: "post_tag",
                column: "tag_id",
                principalTable: "tags",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_posts_users_user_id",
                table: "posts",
                column: "user_id",
                principalTable: "users",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_comments_posts_post_id",
                table: "comments");

            migrationBuilder.DropForeignKey(
                name: "FK_favorite_posts_users_user_id",
                table: "favorite_posts");

            migrationBuilder.DropForeignKey(
                name: "FK_followings_users_user_id",
                table: "followings");

            migrationBuilder.DropForeignKey(
                name: "FK_post_tag_posts_post_id",
                table: "post_tag");

            migrationBuilder.DropForeignKey(
                name: "FK_post_tag_tags_tag_id",
                table: "post_tag");

            migrationBuilder.DropForeignKey(
                name: "FK_posts_users_user_id",
                table: "posts");

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

            migrationBuilder.AddForeignKey(
                name: "FK_comments_posts_post_id",
                table: "comments",
                column: "post_id",
                principalTable: "posts",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_favorite_posts_users_user_id",
                table: "favorite_posts",
                column: "user_id",
                principalTable: "users",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_followings_users_user_id",
                table: "followings",
                column: "user_id",
                principalTable: "users",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_post_tag_posts_post_id",
                table: "post_tag",
                column: "post_id",
                principalTable: "posts",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_post_tag_tags_tag_id",
                table: "post_tag",
                column: "tag_id",
                principalTable: "tags",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_posts_users_user_id",
                table: "posts",
                column: "user_id",
                principalTable: "users",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
