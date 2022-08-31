using GraphQL;
using GraphQL.Types;
using GraphqlApi.Database;
using GraphqlApi.GraphQL.Types;
using GraphqlApi.Models;

namespace GraphqlApi.GraphQL
{
    public class QueryObject : ObjectGraphType<object>
    {
        public QueryObject(IFinanceTrackerRepository repository)
        {
            Name = "Queries";
            Description = "The base query for all the entities in our object graph.";

            // AO: DONE (same as we did in MutationObject)
            //FieldAsync<MovieObject, Movie>(
            //    "movie",
            //    "Gets a movie by its unique identifier.",
            //    new QueryArguments(
            //        new QueryArgument<NonNullGraphType<IdGraphType>>
            //        {
            //            Name = "id",
            //            Description = "The unique GUID of the movie."
            //        }),
            //    context => repository.GetMovieByIdAsync(context.GetArgument("id", Guid.Empty)));


            Field("movie", typeof(MovieObject))
                .Description("Gets a movie by its unique identifier.")
                .Arguments(new QueryArgument<NonNullGraphType<IdGraphType>>
                {
                    Name = "id",
                    Description = "The unique GUID of the movie."
                })
                .Resolve( context => 
                {
                    var id = context.GetArgument<Guid>("id", Guid.Empty);
                    return repository.GetMovieByIdAsync(id).Result;
                });

            Field("category", typeof(ListGraphType<CategoryObject>))
                .Description("Gets list of all categories")
                .Resolve(context =>
                {
                    return repository.GetCategories();
                });

            Field("expense", typeof(ListGraphType<ExpenseObject>))
                .Description("Gets list of all expenses")
                .Resolve(context =>
                {
                    return repository.GetExpenses();
                });
        }
    }
}
