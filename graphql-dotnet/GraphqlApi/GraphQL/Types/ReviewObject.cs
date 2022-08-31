using GraphQL.Types;
using GraphqlApi.Models;

namespace GraphqlApi.GraphQL.Types
{
    public sealed class ReviewObject : ObjectGraphType<Review>
    {
        public ReviewObject()
        {
            Name = nameof(Review);
            Description = "A review of the movie";

            Field(r => r.Reviewer).Description("Name of the reviewer");
            Field(r => r.Stars).Description("Star rating out of five");
        }
    }
}
