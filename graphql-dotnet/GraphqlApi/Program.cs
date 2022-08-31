using Autofac;
using Autofac.Extensions.DependencyInjection;
using GraphQL;
using GraphQL.DataLoader;
using GraphqlApi.Database;
using GraphqlApi.GraphQL;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Configure Autofac as DI engine
builder.Host.UseServiceProviderFactory(new AutofacServiceProviderFactory());

// Register services with Autofac here
builder.Host.ConfigureContainer<ContainerBuilder>(builder => {

    builder.RegisterType<HttpContextAccessor>().As<IHttpContextAccessor>().SingleInstance();
    builder.RegisterType<FinanceTrackerRepository>().As<IFinanceTrackerRepository>().InstancePerLifetimeScope();

    // DocumentWriter from "builder.RegisterType<DocumentWriter>().AsImplementedInterfaces().SingleInstance()" is replaced with these two:
    builder.RegisterType<DataLoaderDocumentListener>().SingleInstance();
    builder.RegisterType<HttpContextAccessor>().As<IHttpContextAccessor>().SingleInstance();

    builder.RegisterType<QueryObject>().AsSelf().SingleInstance();
    builder.RegisterType<FinTrackerSchema>().AsSelf().SingleInstance();
});

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
// builder.Services.AddEndpointsApiExplorer();
// builder.Services.AddSwaggerGen();

builder.Services//.AddEntityFrameworkInMemoryDatabase()
    .AddDbContext<FinContext>(context => { context.UseInMemoryDatabase("MovieDb"); });

builder.Services.AddGraphQL(
        (graphqlBuilder) =>
        {
            graphqlBuilder.AddGraphTypes()
                .AddSystemTextJson()
                .AddDataLoader() // Add GraphQL data loader to reduce the number of calls to our repository. https://graphql-dotnet.github.io/docs/guides/dataloader/
                .AddSchema<FinTrackerSchema>()
                .AddGraphTypes() // Adds all graph types in the current assembly with a singleton lifetime.
                .AddErrorInfoProvider(opt => opt.ExposeExceptionDetails = true)
                //.ConfigureExecutionOptions(options => {
                //    options.EnableMetrics = true;
                //    options.UnhandledExceptionDelegate = ctx =>
                //    {
                //        return new Task(() => Console.WriteLine(ctx?.ErrorMessage?.ToString()));
                //    };
                //})
                ;

            var options = new GraphQL.ExecutionOptions()
            {
                EnableMetrics = true,
            };
        });

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    //app.UseSwagger();
    //app.UseSwaggerUI();

    app.UseGraphQLAltair(); // endpoint: /ui/altair
}

app.UseGraphQL(); // endpoint: /graphql

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
