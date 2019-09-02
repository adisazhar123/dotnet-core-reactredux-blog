using System;
using System.Threading;
using System.Threading.Tasks;
using AdisBlog.Models;
using Microsoft.EntityFrameworkCore;

namespace AdisBlog.Data
{
    public class BlogsDbContext : DbContext
    {
        public DbSet<Post> Posts { get; set; }
        public DbSet<Comment> Comments { get; set; }
        
        public DbSet<User> Users { get; set; }
        
        public BlogsDbContext(DbContextOptions<BlogsDbContext> options) : base(options)
        { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

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
            });

            modelBuilder.Entity<Post>().ToTable("posts");
            modelBuilder.Entity<Post>(entity =>
            {
                entity.HasKey(p => p.Id);
                entity.Property(p => p.Id).HasColumnName("id");
                entity.Property(p => p.Title).HasColumnName("title").IsRequired();
                entity.Property(p => p.Body).HasColumnName("body").IsRequired();
                entity.Property(p => p.CreatedAt).HasColumnName("created_at");
                entity.Property(p => p.UpdatedAt).HasColumnName("updated_at");
                entity.Property(p => p.UserId).HasColumnName("user_id");

                entity.HasMany(p => p.Comments)
                    .WithOne(c => c.Post)
                    .HasForeignKey(c => c.PostId)
                    .IsRequired();
            });

            modelBuilder.Entity<Comment>().ToTable("Comments");
            modelBuilder.Entity<Comment>(entity =>
            {
                entity.HasKey(c => c.Id);
                entity.Property(c => c.Id).HasColumnName("id");
                entity.Property(c => c.PostId).HasColumnName("post_id");
                entity.Property(c => c.Body).HasColumnName("body");
                entity.Property(c => c.CreatedAt).HasColumnName("created_at");
                entity.Property(c => c.UpdatedAt).HasColumnName("updated_at");

            });
        }

        public override int SaveChanges(bool acceptAllChangesOnSuccess)
        {
            OnBeforeSaving();
            return base.SaveChanges(acceptAllChangesOnSuccess);
        }
        
        public override Task<int> SaveChangesAsync(bool acceptAllChangesOnSuccess, CancellationToken cancellationToken = default(CancellationToken))
        {
            OnBeforeSaving();
            return base.SaveChangesAsync(acceptAllChangesOnSuccess, cancellationToken);
        }
        
        private void OnBeforeSaving()
        {
            var entries = ChangeTracker.Entries();
            foreach (var entry in entries)
            {
                if (entry.Entity is BaseModel trackable)
                {
                    var now = DateTime.Now;
                    switch (entry.State)
                    {
                        case EntityState.Modified:
                            trackable.UpdatedAt = now;
                            break;

                        case EntityState.Added:
                            trackable.Id = Guid.NewGuid();
                            trackable.CreatedAt = now;
                            trackable.UpdatedAt = now;
                            break;
                    }
                }
            }
        }
    }
}