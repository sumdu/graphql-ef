namespace GraphqlApi.Models
{
    public class Category
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = "No Name";
        public List<Expense> Expenses { get; set; } = new List<Expense>();
    }
}
