using GraphQL.Types;
using GraphqlApi.Models;

namespace GraphqlApi.GraphQL.Types
{
    public class ExpenseObject : ObjectGraphType<Expense>
    {
        public ExpenseObject()
        {
            Name = nameof(Expense);
            Description = "An expense for a category";

            Field(r => r.Id).Description("Id of the expense");
            Field(r => r.Name).Description("Name of the expense");
            //Field(r => r.Category).Description("Category of the expense").Type(typeof(CategoryObject));
            Field(r => r.Amount).Description("Amount planned");
            Field(r => r.Month).Description("Month of the expense");
            Field(r => r.Year).Description("Year of the expense");

            Field(
                name: "Category",
                description: "Reviews of the movie",
                type: typeof(CategoryObject),
                resolve: m => m.Source.Category
            );
        }
    }


}
