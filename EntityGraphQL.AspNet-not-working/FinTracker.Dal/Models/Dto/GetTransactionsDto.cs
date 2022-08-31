namespace FinTracker.Models.Dto
{
    public class GetTransactionsDto
    {
        public int TransactionId { get; set; }
        public string TransactionName { get; set; }
        public int Year { get; set; }
        public int Month { get; set; }
        public decimal? Amount { get; set; }
        public DateTime? TransactionDate { get; set; }
        public DateTime TransactionAddedDate { get; set; }
        public string CategoryName { get; set; }
    }
}
