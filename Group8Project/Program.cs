//Author: Murtaza Mian
// Description: Program.cs

using Group8Project.Models;
using Group8Projects.Models;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddDbContext<MBS_DBContext>(opts =>
{
    opts.UseSqlServer(
builder.Configuration["ConnectionStrings:MBSConnStr"]);
});


//For our application it means that the application components can access objects that implement the IBookRepository interface without knowing that it is the
// EFStoreRepository implementation class they are using.

builder.Services.AddScoped<IUserRepository, EFUserRepository>();
builder.Services.AddScoped<IMovieRepository, EFMovieRepository>();
builder.Services.AddScoped<IReviewRepository, EFReviewRepository>();

var app = builder.Build();

//make sure this is enabled so you don't get this error
//failed-to-load-resource-the-server-responded-with-a-status-of-404-not-found
app.UseStaticFiles();

app.MapControllerRoute("homepage", "Home", new { Controller = "Home", Action = "SignUpPage" });
app.MapControllerRoute("homepage", "Home/Dashboard", new { Controller = "Home", Action = "LoginPage" });

app.MapDefaultControllerRoute();

app.Run();
