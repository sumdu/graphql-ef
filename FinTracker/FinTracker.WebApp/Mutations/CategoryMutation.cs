using EntityGraphQL.Schema;
using FinTracker.Dal;
using FinTracker.Models;
using System.Linq.Expressions;


// https://entitygraphql.github.io/docs/schema-creation/mutations/

namespace FinTracker.WebApp.Mutations
{
    public class CategoryMutations
    {
        [GraphQLMutation("Add a new category to the system")]
        public Expression<Func<FinTrackerContext, Category>> AddNewCategory(FinTrackerContext db, string categoryName)
        {
            var category = new Category
            {
                Name = categoryName
            };
            db.Categories.Add(category);
            db.SaveChanges();

            return (ctx) => ctx.Categories.First(p => p.Id == category.Id);
        }
    }
}
