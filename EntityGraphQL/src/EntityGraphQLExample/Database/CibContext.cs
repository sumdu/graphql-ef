using EntityGraphQLExample.Database.Models;
using Microsoft.EntityFrameworkCore;

namespace EntityGraphQLExample.Database;

public class CibContext : DbContext
{
    public CibContext(DbContextOptions<CibContext> options) : base(options) { }

    public DbSet<Category> Categories => Set<Category>();
    public DbSet<Expense> Expenses => Set<Expense>();
}