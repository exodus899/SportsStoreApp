using Microsoft.EntityFrameworkCore;
using SportsStore.Models;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews(); // set up objects called services, that can be used throughout the app and more specifically be accessed via dependency injection

// tell EF core the type of database to which it will connect, which connection string describes that connection, and which context class will present the data from the database
builder.Services.AddDbContext<StoreDbContext>(opts => // EF core is configured using the AddDbContext method, which registers the db context class and configures the relationship with the database
{
    opts.UseSqlServer( //declare SQL server will be used
        builder.Configuration["ConnectionStrings:SportsStoreConnection"] // access to the configuration data through builder.Configuration, i.e. how the connection string is obtained
    );
});

builder.Services.AddScoped<IStoreRepository, EFStoreRepository>(); // AddScoped creates a service where the HTTP requests gets its own repository object,
// which is typically how EF core is used.

var app = builder.Build();

// app.MapGet("/", () => "Hello World!");

app.UseStaticFiles(); // enables support for serving static content from the wwwroot folder
app.MapControllerRoute("pagination", "Products/Page{productPage}", new { Controller = "Home", action = "Index" });

app.MapDefaultControllerRoute(); // endpoint routing, registers the MVC framework as a source of endpoints using the default convention for mapping requests
// to classes and methods


SeedData.EnsurePopulated(app); // initializes the database with seed data (if it doesn't already exist) using the EnsurePopulated method of the SeedData class.

app.Run(); //runs the application, starting the server and listening for incoming requests.
