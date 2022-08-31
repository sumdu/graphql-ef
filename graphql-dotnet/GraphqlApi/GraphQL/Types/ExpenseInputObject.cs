using GraphQL.Types;
using GraphqlApi.Models;

namespace GraphqlApi.GraphQL.Types
{
    public sealed class ExpenseInputObject : InputObjectGraphType<Expense>
    {
        public ExpenseInputObject()
        {
            Name = "ExpenseInput";
            Description = "An expense per category";

            Field(r => r.Name).Description("blah");
            Field(r => r.Amount);
            Field(r => r.Month);
            Field(r => r.Year);
        }
    }
}
