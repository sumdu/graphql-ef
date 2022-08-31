using EntityGraphQL.AspNet;
using FinTracker.Dal;
using FinTracker.WebApp.Data;
using FinTracker.WebApp.Mutations;
using GraphQL.Server.Ui.Altair;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.Text.Json;
using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
var connectionString = builder.Configuration.GetConnectionString("FinTracker");
builder.Services.AddDbContext<FinTrackerContext>(options => options.UseSqlServer(connectionString));
builder.Services.AddDatabaseDeveloperPageExceptionFilter();
builder.Services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = true)
    .AddEntityFrameworkStores<FinTrackerContext>();

Action<AddGraphQLOptions<FinTrackerContext>> configure = (configure) => 
{
    configure.ConfigureSchema = (schemaConf) =>
    {
        schemaConf.AddMutationsFrom<CategoryMutations>();
    };
};
builder.Services.AddGraphQLSchema<FinTrackerContext>(configure);

//builder.Services.AddGraphQLSchema<FinTrackerContext>(configure => {
//    /*options => options.AddMutationsFrom<CategoryMutations>()*/
//    //configure.ConfigureSchema.  AddGraphQLOptions<FinTrackerContext>();
//});

builder.Services.AddControllersWithViews()
    .AddJsonOptions(opts =>
    {
        // Use enum field names instead of numbers
        opts.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter());
        // EntityGraphQL internally builds types with fields
        opts.JsonSerializerOptions.IncludeFields = true;
        // The fields internally built already are named with fieldNamer (defaults to camelCase). This is
        // for the properties on QueryResult (Data, Errors) to match what most tools etc expect (camelCase)
        opts.JsonSerializerOptions.PropertyNamingPolicy = JsonNamingPolicy.CamelCase;
    });
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseMigrationsEndPoint();

    //app.UseSwagger();
    //app.UseSwaggerUI(); // https://localhost:<port>/swagger
}
else
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

//app.MapControllerRoute(
//    name: "default",
//    pattern: "{controller=Home}/{action=Index}/{id?}");
app.UseEndpoints(routeBuilder =>
{
    routeBuilder.MapControllers();
    routeBuilder.MapGraphQL<FinTrackerContext>(); // default url: /graphql
    routeBuilder.MapGraphQLAltair("/ui/altair", new AltairOptions
        {
            GraphQLEndPoint = PathString.FromUriComponent("/graphql")
        });
});
app.MapRazorPages();

app.Run();
