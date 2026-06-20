using LibraryManagement.dbcontext;
using Microsoft.EntityFrameworkCore;
using LibraryManagement.Service;
using LibraryManagement.Repository;
var builder = WebApplication.CreateBuilder(args);

var dbConnectioPath = builder.Configuration.GetConnectionString("DefaultConnection");
var authorname = builder.Configuration["MyAppDetails:Author"];
var version = builder.Configuration["MyAppDetails:version"];

builder.Services.AddDbContext<AppDbContext>(option => option.UseSqlServer(dbConnectioPath));
//builder.Services.AddDbContext<AppDbContext>(option => option.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

//services di controller = register

builder.Services.AddControllers();

//dependency register here now we use in overall app
//builder.Services.AddTransient
builder.Services.AddScoped<IBookService, BookService>();
builder.Services.AddScoped<IBookRepository, BookRepository>();
//builder.Services.AddSingleton
var app = builder.Build();

// mapcontroller, middleware, minimal api routhandler,
app.MapControllers();
app.MapGet("/", () => { return Results.Ok($"Welcome to backend\n dbconnection path = {dbConnectioPath}" ); });

app.MapFallback(() =>
{
    return Results.NotFound("Not found any end points");
});
app.Run();