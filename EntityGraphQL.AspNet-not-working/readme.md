Use GraphQL + EF Core in .NET 6
* https://medium.com/@levanrevazashvili/graphql-with-ef-core-net-6-b1f87af099db
  (uses https://github.com/EntityGraphQL/EntityGraphQL)

Next step - add mutations:
* https://entitygraphql.github.io/
  * schema.AddMutationsFrom<CategoryMutations>();

Go to https://localhost:7011/ui/altair to see UI for graphql.

mutation MaybeAddNewCategory($cat: String!) {
  addNewCategory(categoryName: $cat) {
    id
  }
}

{
  "cat": "JEDI" 
}

