using GraphQL.Types;
using GraphqlApi.Models;

namespace GraphqlApi.GraphQL.Types
{
    public sealed class CategoryObject : ObjectGraphType<Category>
    {
        public CategoryObject()
        {
            Name = nameof(Category);
            Description = "A category of expense in the collection";

            Field(m => m.Id).Description("Identifier of the category");
            Field(m => m.Name).Description("Name of the category");
            Field(
                name: "Expenses",
                description: "Expenses for the category",
                type: typeof(ListGraphType<ExpenseObject>),
                resolve: m => m.Source.Expenses);
        }
    }
}
