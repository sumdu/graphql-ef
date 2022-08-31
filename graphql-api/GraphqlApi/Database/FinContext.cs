using GraphqlApi.Models;
using Microsoft.EntityFrameworkCore;

namespace GraphqlApi.Database
{
    public class FinContext : DbContext
    {
        public FinContext(DbContextOptions<FinContext> options) : base(options) { }

        public DbSet<Movie> Movie => Set<Movie>();

        public DbSet<Category> Categories => Set<Category>();
        public DbSet<Expense> Expenses => Set<Expense>();

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Movie>().OwnsMany(m => m.Reviews).HasData(
                new Review
                {
                    Id = 1,
                    Reviewer = "A",
                    Stars = 4,
                    MovieId = new Guid("72d95bfd-1dac-4bc2-adc1-f28fd43777fd")
                }
            );
            modelBuilder.Entity<Movie>().HasData(
                new Movie
                {
                    Id = new Guid("72d95bfd-1dac-4bc2-adc1-f28fd43777fd"),
                    Name = "Superman and Lois"
                }
            );

            modelBuilder.Entity<Category>().HasData(new Category { Id = new Guid("72d95bfd-1dac-4bc2-adc1-f28fd43777fd"), Name = "Category 1" });

            //modelBuilder.Entity<Expense>().OwnsOne<Category>(e => e.Category).HasData(new Expense
            //{
            //    Id = new Guid("72d95bfd-1dac-4bc2-adc1-f28fd4377000"),
            //    //Category = cat1,
            //    CategoryId = new Guid("72d95bfd-1dac-4bc2-adc1-f28fd43777fd"),
            //    Name = "Hello there",
            //    Amount = 100,
            //    Month = 1,
            //    Year = 2022
            //});

            //modelBuilder.Entity<Category>().OwnsMany<Expense>(c => c.Expenses).HasData(
            //    new Category { Id = new Guid("72d95bfd-1dac-4bc2-adc1-f28fd43777fd"), Name = "Category 1" 
            //});

        }
    }
}
