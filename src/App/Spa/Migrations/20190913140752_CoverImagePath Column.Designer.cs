﻿// <auto-generated />
using System;
using AdisBlog.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace AdisBlog.Migrations
{
    [DbContext(typeof(BlogsDbContext))]
    [Migration("20190913140752_CoverImagePath Column")]
    partial class CoverImagePathColumn
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.6-servicing-10079")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("AdisBlog.Models.Comment", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("id");

                    b.Property<string>("Body")
                        .HasColumnName("body");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnName("created_at");

                    b.Property<Guid>("PostId")
                        .HasColumnName("post_id");

                    b.Property<DateTime>("UpdatedAt")
                        .HasColumnName("updated_at");

                    b.HasKey("Id");

                    b.HasIndex("PostId");

                    b.ToTable("comments");
                });

            modelBuilder.Entity("AdisBlog.Models.FavoritePost", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("id");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnName("created_at");

                    b.Property<Guid>("PostId")
                        .HasColumnName("post_id");

                    b.Property<DateTime>("UpdatedAt")
                        .HasColumnName("updated_at");

                    b.Property<Guid>("UserId")
                        .HasColumnName("user_id");

                    b.HasKey("Id");

                    b.HasIndex("UserId", "PostId");

                    b.ToTable("favorite_posts");
                });

            modelBuilder.Entity("AdisBlog.Models.Following", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("id");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnName("created_at");

                    b.Property<Guid>("FollowingUserId")
                        .HasColumnName("following_user_id");

                    b.Property<DateTime>("UpdatedAt")
                        .HasColumnName("updated_at");

                    b.Property<Guid>("UserId")
                        .HasColumnName("user_id");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("followings");
                });

            modelBuilder.Entity("AdisBlog.Models.Post", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("id");

                    b.Property<string>("Body")
                        .IsRequired()
                        .HasColumnName("body");

                    b.Property<string>("CoverImagePath")
                        .HasColumnName("cover_image_path");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnName("created_at");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnName("title");

                    b.Property<DateTime>("UpdatedAt")
                        .HasColumnName("updated_at");

                    b.Property<Guid>("UserId")
                        .HasColumnName("user_id");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("posts");
                });

            modelBuilder.Entity("AdisBlog.Models.PostTag", b =>
                {
                    b.Property<Guid>("PostId")
                        .HasColumnName("post_id");

                    b.Property<Guid>("TagId")
                        .HasColumnName("tag_id");

                    b.HasKey("PostId", "TagId");

                    b.HasIndex("TagId");

                    b.ToTable("post_tag");
                });

            modelBuilder.Entity("AdisBlog.Models.Tag", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("id");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnName("created_at");

                    b.Property<string>("Title")
                        .HasColumnName("title");

                    b.Property<DateTime>("UpdatedAt")
                        .HasColumnName("updated_at");

                    b.HasKey("Id");

                    b.ToTable("tags");

                    b.HasData(
                        new
                        {
                            Id = new Guid("0f8fad5b-d3cb-469f-a165-71267728950e"),
                            CreatedAt = new DateTime(2019, 9, 13, 21, 7, 52, 700, DateTimeKind.Local).AddTicks(3696),
                            Title = "Computer Science",
                            UpdatedAt = new DateTime(2019, 9, 13, 21, 7, 52, 700, DateTimeKind.Local).AddTicks(3714)
                        },
                        new
                        {
                            Id = new Guid("0f8fad5b-d3cb-469f-a165-712677284194"),
                            CreatedAt = new DateTime(2019, 9, 13, 21, 7, 52, 700, DateTimeKind.Local).AddTicks(3740),
                            Title = "Sports",
                            UpdatedAt = new DateTime(2019, 9, 13, 21, 7, 52, 700, DateTimeKind.Local).AddTicks(3742)
                        },
                        new
                        {
                            Id = new Guid("8914ad5b-d3cb-469f-a165-71267728950e"),
                            CreatedAt = new DateTime(2019, 9, 13, 21, 7, 52, 700, DateTimeKind.Local).AddTicks(3749),
                            Title = "Lifestyle",
                            UpdatedAt = new DateTime(2019, 9, 13, 21, 7, 52, 700, DateTimeKind.Local).AddTicks(3751)
                        });
                });

            modelBuilder.Entity("AdisBlog.Models.User", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("id");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnName("created_at");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnName("password");

                    b.Property<string>("Role")
                        .IsRequired()
                        .HasColumnName("role");

                    b.Property<DateTime>("UpdatedAt")
                        .HasColumnName("updated_at");

                    b.Property<string>("Username")
                        .IsRequired()
                        .HasColumnName("username");

                    b.HasKey("Id");

                    b.ToTable("users");

                    b.HasData(
                        new
                        {
                            Id = new Guid("0f8fad5b-d9cb-469f-a165-70867728950e"),
                            CreatedAt = new DateTime(2019, 9, 13, 21, 7, 52, 591, DateTimeKind.Local).AddTicks(3792),
                            Password = "$2a$10$dNgzNvexyTsZN/I6DF41n.MsWARQHIZFoSfVRyQM/TpLDwqgw65du",
                            Role = "user",
                            UpdatedAt = new DateTime(2019, 9, 13, 21, 7, 52, 592, DateTimeKind.Local).AddTicks(24),
                            Username = "adis"
                        },
                        new
                        {
                            Id = new Guid("7c9e6679-7425-40de-944b-e07fc1f90ae7"),
                            CreatedAt = new DateTime(2019, 9, 13, 21, 7, 52, 674, DateTimeKind.Local).AddTicks(9630),
                            Password = "$2a$10$cDP.tuMMV/dSV5YOJ1fOKOw0AaGfZMtSV1QThgZ7tPXHVBkpjOLaq",
                            Role = "admin",
                            UpdatedAt = new DateTime(2019, 9, 13, 21, 7, 52, 674, DateTimeKind.Local).AddTicks(9650),
                            Username = "admin"
                        });
                });

            modelBuilder.Entity("AdisBlog.Models.Comment", b =>
                {
                    b.HasOne("AdisBlog.Models.Post", "Post")
                        .WithMany("Comments")
                        .HasForeignKey("PostId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("AdisBlog.Models.FavoritePost", b =>
                {
                    b.HasOne("AdisBlog.Models.User", "User")
                        .WithMany("FavoritePosts")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("AdisBlog.Models.Following", b =>
                {
                    b.HasOne("AdisBlog.Models.User", "User")
                        .WithMany("Followings")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("AdisBlog.Models.Post", b =>
                {
                    b.HasOne("AdisBlog.Models.User", "User")
                        .WithMany("Posts")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("AdisBlog.Models.PostTag", b =>
                {
                    b.HasOne("AdisBlog.Models.Post", "Post")
                        .WithMany("PostTags")
                        .HasForeignKey("PostId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("AdisBlog.Models.Tag", "Tag")
                        .WithMany("PostTags")
                        .HasForeignKey("TagId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
