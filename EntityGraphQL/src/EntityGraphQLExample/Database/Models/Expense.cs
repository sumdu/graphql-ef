namespace EntityGraphQLExample.Database.Models;

public class Expense
{
    public int Id { get; set; }
    public string Name { get; set; }
    
    public virtual Category Category { get; set; }
    public int? CategoryId { get; set; }
    public int Year { get; set; }
    public int Month { get; set; }
    public double Amount { get; set; }
}