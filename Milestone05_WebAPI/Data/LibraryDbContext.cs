using Microsoft.EntityFrameworkCore;
using Milestone05_WebAPI.Models;

namespace Milestone05_WebAPI.Data
{
    public class LibraryDbContext : DbContext
    {
        public LibraryDbContext(DbContextOptions<LibraryDbContext> options)
            : base(options)
        {
        }

        public DbSet<User> Users { get; set; }

        public DbSet<Book> Books { get; set; }

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

            // Required fields
            modelBuilder.Entity<Book>()
                .Property(b => b.Title)
                .IsRequired();

            modelBuilder.Entity<Book>()
                .Property(b => b.Author)
                .IsRequired();
        }
    }
}