namespace EntityGraphQLExample.Database.Models;

public class Category
{
    public int Id { get; set; }
    public string Name { get; set; }
    public virtual ICollection<Expense> Expenses { get; set; }
    public CategoryImportanceEnum Importance { get; set; }
}

