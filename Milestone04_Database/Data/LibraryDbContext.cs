using Microsoft.EntityFrameworkCore;
using Milestone04_Database.Models;

namespace Milestone04_Database.Data;

public class LibraryDbContext : DbContext
{
    public DbSet<User> Users { get; set; }

    public DbSet<Book> Books { get; set; }

    protected override void OnConfiguring(
        DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlite("Data Source=library.db");
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        // Username must be unique
        modelBuilder.Entity<User>()
            .HasIndex(u => u.Username)
            .IsUnique();

        // One user can own many books
        modelBuilder.Entity<User>()
            .HasMany(u => u.Books)
            .WithOne(b => b.User)
            .HasForeignKey(b => b.UserId)
            .OnDelete(DeleteBehavior.Cascade);

        // Required book fields
        modelBuilder.Entity<Book>()
            .Property(b => b.Title)
            .IsRequired();

        modelBuilder.Entity<Book>()
            .Property(b => b.Author)
            .IsRequired();
    }
}