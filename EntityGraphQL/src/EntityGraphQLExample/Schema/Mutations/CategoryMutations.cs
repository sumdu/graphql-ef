using EntityGraphQL.Schema;
using EntityGraphQLExample.Database;
using EntityGraphQLExample.Database.Models;
using System.Linq.Expressions;

namespace EntityGraphQLExample.Schema.Mutations;

public class CategoryMutations
{
    [MutationArguments]
    public class AddCategoryModel
    {
        public string Name { get; set; }
    }
    
    [GraphQLMutation("Add a new category to the system")]
    
    public Expression<Func<CibContext, Category>> AddCategory(CibContext db, [GraphQLNotNull] AddCategoryModel model)
    {
        var category = new Category
        {
            Name = model.Name
        };
        db.Categories.Add(category);
        db.SaveChanges();
        return ctx => ctx.Categories.First(p => p.Id == category.Id);
    }
}