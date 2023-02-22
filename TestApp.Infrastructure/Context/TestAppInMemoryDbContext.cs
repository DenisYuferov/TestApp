using Microsoft.EntityFrameworkCore;
using TestApp.Infrastructure.Entities;

namespace TestApp.Infrastructure.Context
{
    public class TestAppInMemoryDbContext : DbContext
    {
        public DbSet<Author> Authors { get; set; }
        public DbSet<Book> Books { get; set; }

        public TestAppInMemoryDbContext(DbContextOptions<TestAppInMemoryDbContext> options)
            : base(options)
        {

        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            // optionsBuilder.UseInMemoryDatabase(databaseName: "databaseName");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Author>(entity =>
            {
                entity.HasKey(a => a.Id);
                entity.Property(a => a.Age).IsRequired();
                entity.Property(a => a.FirstName).IsRequired().HasMaxLength(16);
                entity.Property(a => a.LastName).HasMaxLength(64);
                entity.Property(a => a.Phone).HasMaxLength(32);
                entity.HasMany(a => a.Books)
                      .WithOne(b => b.Author)
                      .OnDelete(DeleteBehavior.Cascade);
            });
            
            modelBuilder.Entity<Book>(entity =>
            {
                entity.HasKey(b => b.Id);
                entity.Property(b => b.AuthorId).IsRequired();
                entity.Property(b => b.Title).IsRequired().HasMaxLength(512);
                entity.Property(b => b.Description).HasMaxLength(1024);
                entity.HasOne(b => b.Author)
                      .WithMany(a => a.Books)
                      .HasForeignKey(b => b.AuthorId);
            });
        }
    }
}