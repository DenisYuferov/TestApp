using Microsoft.EntityFrameworkCore;

using TestApp.Domain.Model.PostgreDb.Entities;
using TestApp.Domain.Model.PostgreDb.Seeds;

namespace TestApp.Infrastructure.PostgreDb.Contexts
{
    // Add-Migration Initial -StartupProject TestApp.WebApi -Project TestApp.Infrastructure.PostgreDb
    public class TestAppDbContext : DbContext
    {
        public DbSet<Author> Authors { get; set; }
        public DbSet<Book> Books { get; set; }

        public TestAppDbContext(DbContextOptions<TestAppDbContext> options)
            : base(options)
        {

        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {

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

            var seedModel = GetSeedModel();

            modelBuilder.Entity<Author>().HasData(seedModel.Author!);

            modelBuilder.Entity<Book>().HasData(seedModel.Books?[0]!);
            modelBuilder.Entity<Book>().HasData(seedModel.Books?[1]!);
        }

        public SeedModel GetSeedModel()
        {
            var model = new SeedModel
            {
                Author = new Author { Id = 1, Age = 30, FirstName = "Ivan", LastName = "Ivanov", Phone = "+7-987-654-32-10" },
                Books = new List<Book>
                {
                    new Book { Id = 1, AuthorId = 1, Title = "Test Book", Description = "It`s a very simple book", Cost = 100 },
                    new Book { Id = 2, AuthorId = 1, Title = "Test Book2", Description = "It`s a very simple book 2", Cost = 200 }
                }
            };

            return model;
        }
    }
}