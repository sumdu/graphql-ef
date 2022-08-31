using GraphQL.Types;

namespace GraphqlApi.GraphQL
{
    public class FinTrackerSchema : Schema
    {
        public FinTrackerSchema(QueryObject query, MutationObject mutation, IServiceProvider sp) : base(sp)
        {
            Query = query;
            Mutation = mutation;
        }
    }
}
