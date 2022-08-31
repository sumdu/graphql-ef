namespace GraphqlApi.Models
{
    public class Expense
    {
        public Guid Id { get; set; }
        public Category Category { get; set; } = new Category() { Id = Guid.NewGuid() };
        public Guid CategoryId { get; set; }
        public string Name { get; set; }
        public int Year { get; set; }
        public int Month { get; set; }
        public float Amount { get; set; }
    }
}
