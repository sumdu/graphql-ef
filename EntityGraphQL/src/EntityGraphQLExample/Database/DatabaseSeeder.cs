using EntityGraphQLExample.Database.Models;

namespace EntityGraphQLExample.Database;

public static class DatabaseSeeder
{
    public static async Task SeedAsync(CibContext context)
    {
        await context.Database.EnsureDeletedAsync();
        await context.Database.EnsureCreatedAsync();

        await context.Categories.AddAsync(new()
        {
            Id = 1,
            Name = "Category 1",
            Importance = CategoryImportanceEnum.Important,
            Expenses = new List<Expense>
            {
                new()
                {
                    Id=1,
                    Name="Expense 1",
                    Amount=10,
                    Month=1,
                    Year=2000
                }
            }
        });

        await context.SaveChangesAsync();
    }
}