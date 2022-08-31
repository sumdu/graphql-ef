using EntityGraphQL.AspNet;
using EntityGraphQLExample.Database;
using EntityGraphQLExample.Schema;
using GraphQL.Server.Ui.Altair;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<CibContext>(opt => opt.UseInMemoryDatabase("cib"));
builder.Services.AddGraphQLSchema(Schema.AddGraphQlOptions);

var app = builder.Build();

await using var serviceScope = app.Services.CreateAsyncScope();
var cibContext = serviceScope.ServiceProvider.GetRequiredService<CibContext>();
await DatabaseSeeder.SeedAsync(cibContext);

app.UseHttpsRedirection();

app.UseRouting();
app.UseEndpoints(routeBuilder =>
{
    routeBuilder.MapGraphQL<CibContext>();
    routeBuilder.MapGraphQLAltair(new AltairOptions
    {
        GraphQLEndPoint = PathString.FromUriComponent("/graphql")
    });
});

app.Run();
