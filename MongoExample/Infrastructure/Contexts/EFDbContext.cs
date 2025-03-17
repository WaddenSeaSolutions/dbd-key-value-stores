using Microsoft.EntityFrameworkCore;
using MongoExample.Infrastructure.Models;

namespace MongoExample.Infrastructure.Contexts;

public class EFDbContext : DbContext
{
    public DbSet<BlogDbModel> Blogs { get; set; }
    public DbSet<PostDbModel> Posts { get; set; }
    public DbSet<CommentDbModel> Comments { get; set; }
    public DbSet<UserDbModel> Users { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<BlogDbModel>().ToTable("Blogs");
        modelBuilder.Entity<PostDbModel>().ToTable("Posts");
        modelBuilder.Entity<CommentDbModel>().ToTable("Comments");
        modelBuilder.Entity<UserDbModel>().ToTable("Users");
    }
}