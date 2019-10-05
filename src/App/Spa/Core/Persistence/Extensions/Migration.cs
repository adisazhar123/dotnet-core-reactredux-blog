using System;
using AdisBlog.Models;
using Microsoft.EntityFrameworkCore;

namespace AdisBlog.Core.Persistence.Extensions
{
    public static class Migration
    {
        public static void CreateMigrations(this ModelBuilder modelBuilder)
        {
                modelBuilder.Entity<User>().ToTable("users").HasData(
                new User
                {
                    Id = Guid.Parse("0f8fad5b-d9cb-469f-a165-70867728950e"),
                    Username  = "adis",
                    Password = BCrypt.Net.BCrypt.HashPassword("secret"),
                    Role = "user",
                    CreatedAt = DateTime.Now,
                    UpdatedAt = DateTime.Now
                },
                new User
                {
                    Id = Guid.Parse("7c9e6679-7425-40de-944b-e07fc1f90ae7"),
                    Username  = "admin",
                    Password = BCrypt.Net.BCrypt.HashPassword("secret"),
                    Role = "admin",
                    CreatedAt = DateTime.Now,
                    UpdatedAt = DateTime.Now
                });
            
            modelBuilder.Entity<User>(entity =>
            {
                entity.HasKey(u => u.Id);
                entity.Property(u => u.Id).HasColumnName("id");
                entity.Property(u => u.Username).HasColumnName("username").IsRequired();
                entity.Property(u => u.Password).HasColumnName("password").IsRequired();
                entity.Property(u => u.Role).HasColumnName("role").IsRequired();

                entity.HasMany(u => u.Posts)
                    .WithOne(p => p.User)
                    .HasForeignKey( p => p.UserId)
                    .IsRequired();

                entity.HasMany(u => u.FavoritePosts)
                    .WithOne(f => f.User)
                    .HasForeignKey(f => f.UserId)
                    .IsRequired();

                entity.HasMany(u => u.Followings)
                    .WithOne(f => f.User)
                    .HasForeignKey(f => f.UserId)
                    .IsRequired();
            });

            modelBuilder.Entity<Post>().ToTable("posts");
            modelBuilder.Entity<Post>(entity =>
            {
                entity.HasKey(p => p.Id);
                entity.Property(p => p.Id).HasColumnName("id");
                entity.Property(p => p.Title).HasColumnName("title").IsRequired();
                entity.Property(p => p.Body).HasColumnName("body").IsRequired();
                entity.Property(p => p.CoverImagePath).HasColumnName("cover_image_path").IsRequired(false);
                entity.Property(p => p.CreatedAt).HasColumnName("created_at");
                entity.Property(p => p.UpdatedAt).HasColumnName("updated_at");
                entity.Property(p => p.UserId).HasColumnName("user_id");

                entity.HasMany(p => p.Comments)
                    .WithOne(c => c.Post)
                    .HasForeignKey(c => c.PostId)
                    .IsRequired();
            });

            modelBuilder.Entity<Comment>().ToTable("comments");
            modelBuilder.Entity<Comment>(entity =>
            {
                entity.HasKey(c => c.Id);
                entity.Property(c => c.Id).HasColumnName("id");
                entity.Property(c => c.PostId).HasColumnName("post_id");
                entity.Property(c => c.Body).HasColumnName("body");
                entity.Property(c => c.CreatedAt).HasColumnName("created_at");
                entity.Property(c => c.UpdatedAt).HasColumnName("updated_at");
            });

            modelBuilder.Entity<FavoritePost>().ToTable("favorite_posts");
            modelBuilder.Entity<FavoritePost>().HasIndex(f => new { f.UserId, f.PostId });
            modelBuilder.Entity<FavoritePost>(entity =>
            {
                entity.HasKey(f => f.Id);
                entity.Property(f => f.PostId).HasColumnName("post_id");
                entity.Property(f => f.UserId).HasColumnName("user_id");
                entity.Property(f => f.CreatedAt).HasColumnName("created_at");
                entity.Property(f => f.UpdatedAt).HasColumnName("updated_at");
            });

            modelBuilder.Entity<Tag>().ToTable("tags").HasData(
                new Tag
                {
                    Id = Guid.Parse("0f8fad5b-d3cb-469f-a165-71267728950e"),
                    Title = "Computer Science",
                    CreatedAt = DateTime.Now,
                    UpdatedAt = DateTime.Now
                },
                new Tag
                {
                    Id = Guid.Parse("0f8fad5b-d3cb-469f-a165-712677284194"),
                    Title = "Sports",
                    CreatedAt = DateTime.Now,
                    UpdatedAt = DateTime.Now
                },
                new Tag
                {
                    Id = Guid.Parse("8914ad5b-d3cb-469f-a165-71267728950e"),
                    Title = "Lifestyle",
                    CreatedAt = DateTime.Now,
                    UpdatedAt = DateTime.Now
                });
            modelBuilder.Entity<Tag>(entity => { entity.Property(t => t.Title).HasColumnName("title"); });

            modelBuilder.Entity<PostTag>().ToTable("post_tag");
            modelBuilder.Entity<PostTag>(entity =>
            {
                entity.HasKey(pt => new {pt.PostId, pt.TagId});
                entity.Property(pt => pt.PostId).HasColumnName("post_id");
                entity.Property(pt => pt.TagId).HasColumnName("tag_id");

                entity.HasOne(pt => pt.Post)
                    .WithMany(p => p.PostTags)
                    .HasForeignKey(pt => pt.PostId);
                
                entity.HasOne(pt => pt.Tag)
                    .WithMany(t => t.PostTags)
                    .HasForeignKey(pt => pt.TagId);
            });

            modelBuilder.Entity<Following>().ToTable("followings");
            modelBuilder.Entity<Following>(entity =>
            {
                entity.HasKey(f => f.Id);
                entity.Property(f => f.UserId).HasColumnName("user_id");
                entity.Property(f => f.FollowingUserId).HasColumnName("following_user_id");
            });
        }
    }
}