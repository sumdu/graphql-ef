using GraphqlApi.Models;
using Microsoft.EntityFrameworkCore;

namespace GraphqlApi.Database
{
    public class FinanceTrackerRepository : IFinanceTrackerRepository
    {
        private readonly FinContext _context;

        public FinanceTrackerRepository(FinContext context)
        {
            _context = context;
            _context.Database.EnsureCreated();
        }

        public Task<Movie> GetMovieByIdAsync(Guid id)
        {
            return _context.Movie.Where(m => m.Id == id).AsNoTracking().FirstOrDefaultAsync();
        }
        
        public Movie AddReviewToMovie(Guid id, Review review)
        {
            var movie = _context.Movie.Where(m => m.Id == id).FirstOrDefault();
            movie.AddReview(review);
            _context.SaveChanges();

            return movie;
        }

        public List<Category> GetCategories() 
        {
            return _context.Categories.ToList();
        }

        public List<Expense> GetExpenses()
        {
            return _context.Expenses.ToList();
        }

        public Expense AddExpense(Guid categoryId, Expense expense)
        {
            var cat = _context.Categories.Where(c => c.Id == categoryId).FirstOrDefault();
            if (cat == null)
                return new Expense();

            cat.Expenses.Add(expense);
            _context.SaveChanges();

            return expense;
        }


    }
}
