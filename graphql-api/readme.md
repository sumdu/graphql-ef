Created by following steps from
https://thecloudblog.net/post/build-a-basic-graphql-server-with-asp.net-core-and-entity-framework-in-10-minutes/

TODO: if something doesn't match, follow instructions from here
https://graphql-dotnet.github.io/docs/getting-started/introduction

TODO: compare my solution with this one (Getting started with GraphQL in .NET 6 - Part 1 )
https://dev.to/berviantoleo/getting-started-graphql-in-net-6-part-1-4ic2

query {
  movie(id:"72d95bfd-1dac-4bc2-adc1-f28fd43777fd") {
    name
  }
}

 mutation addReview($cat: ReviewInput!) {
  addReview(id:"72d95bfd-1dac-4bc2-adc1-f28fd43777fd", review:$cat) {
    id
    name
    reviews {
      reviewer
      stars
    } 
  }
}

{
  "cat": {
    "reviewer": "aaa",
    "stars": 5
  }
}

mutation testMutation($expense: ExpenseInput!) {
  addExpense(categoryId:"72d95bfd-1dac-4bc2-adc1-f28fd43777fd", expense:$expense) {
    id
    name
    amount
    month
    year
    category {
      id
      name
    }
  } 
}

{"expense": 
  {
    "name": "",
    "amount": 200,
    "month": 1,
    "year": 2022
  }
}