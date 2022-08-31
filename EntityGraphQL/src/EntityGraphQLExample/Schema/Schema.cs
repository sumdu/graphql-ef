using EntityGraphQL.AspNet;
using EntityGraphQL.Schema;
using EntityGraphQLExample.Database;
using EntityGraphQLExample.Database.Models;
using EntityGraphQLExample.Schema.Mutations;

namespace EntityGraphQLExample.Schema;

public static class Schema
{
    public static Action<AddGraphQLOptions<CibContext>> AddGraphQlOptions => options =>
    {
        options.ConfigureSchema = ConfigureSchema;
    };

    private static void ConfigureSchema(SchemaProvider<CibContext> schemaProvider)
    {
        schemaProvider.Query().AddField("importantCategories",
            context => context.Categories.Where(c => c.Id == 1).FirstOrDefault(),
            "Fetch important categories");

        schemaProvider.AddMutationsFrom<CategoryMutations>();
        schemaProvider.AddEnum("importance", typeof(CategoryImportanceEnum), "category importance");

        // write to file
        File.WriteAllText("schema.graphql", schemaProvider.ToGraphQLSchemaString());
    }
}