using GraphqlApi.Models;

namespace GraphqlApi.Database
{
    public interface IFinanceTrackerRepository
    {
        Task<Movie> GetMovieByIdAsync(Guid id);
        Movie AddReviewToMovie(Guid id, Review review);

        List<Category> GetCategories();
        List<Expense> GetExpenses();
        Expense AddExpense(Guid categoryId, Expense expense);
    }
}
