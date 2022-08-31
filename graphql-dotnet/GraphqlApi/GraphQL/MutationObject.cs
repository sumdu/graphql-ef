using GraphQL;
using GraphQL.Types;
using GraphqlApi.Database;
using GraphqlApi.GraphQL.Types;
using GraphqlApi.Models;

namespace GraphqlApi.GraphQL
{
    public class MutationObject : ObjectGraphType<object>
    {
        public MutationObject(IFinanceTrackerRepository repository)
        {
            Name = "Mutations";
            Description = "The base mutation for all the entities in our object graph.";

            Field(
                "addReview",
                typeof(MovieObject)
                )
                .Description("Add review to a movie.")
                .Arguments(
                    new QueryArgument<NonNullGraphType<IdGraphType>>
                    {
                        Name = "id",
                        Description = "The unique GUID of the movie."
                    },
                    new QueryArgument<NonNullGraphType<ReviewInputObject>>
                    {
                        Name = "review",
                        Description = "Review for the movie."
                    }
                )
                .Resolve(context =>
                {
                    var id = context.GetArgument<Guid>("id");
                    var review = context.GetArgument<Review>("review");
                    return repository.AddReviewToMovie(id, review);
                });


            // AO: DONE
            // old code that was refactored for .NET 6 above

            //FieldAsync<MovieObject, Movie>(
            //    "addReview",
            //    "Add review to a movie.",
            //    new QueryArguments(
            //        new QueryArgument<NonNullGraphType<IdGraphType>>
            //        {
            //            Name = "id",
            //            Description = "The unique GUID of the movie."
            //        },
            //        new QueryArgument<NonNullGraphType<ReviewInputObject>>
            //        {
            //            Name = "review",
            //            Description = "Review for the movie."
            //        }),
            //    context =>
            //    {
            //        var id = (Guid?)context.Arguments["id"].Value;// GetArgument<Guid>("id");
            //        var review = (Review)context.Arguments["review"].Value;
            //        return repository.AddReviewToMovieAsync(id.Value, review);
            //    });

            Field(
                "addExpense",
                typeof(ExpenseObject)
                )
                .Description("Add expense for the category.")
                .Arguments(
                    new QueryArgument<NonNullGraphType<IdGraphType>>
                    {
                        Name = "categoryId",
                        Description = "The unique GUID of the category."
                    },
                    new QueryArgument<NonNullGraphType<ExpenseInputObject>>
                    {
                        Name = "expense",
                        Description = "New expense to create per category"
                    }
                )
                .Resolve(context =>
                {
                    var catId = context.GetArgument<Guid>("categoryId");
                    var expense = context.GetArgument<Expense>("expense");
                    return repository.AddExpense(catId, expense);
                });
        }
    }
}
