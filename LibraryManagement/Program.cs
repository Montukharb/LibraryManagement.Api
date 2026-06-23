using LibraryManagement.dbcontext;
using LibraryManagement.Repository;
using LibraryManagement.Service;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.EntityFrameworkCore;
using static System.Runtime.InteropServices.JavaScript.JSType;
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
//Gloabal level exception handler using middleware
//lambda function example
//app.UseExceptionHandler(globalbranch =>
//{
//    globalbranch.Run(async context =>
//    {
//        var exceptionfeature = context.Features.Get<IExceptionHandlerFeature>();

//        context.Response.StatusCode = 500;
//        context.Response.ContentType = "application/json";
//        await context.Response.WriteAsJsonAsync(new
//        {
//            message = "Something went wrong",
//            exceptionProperMsg = exceptionfeature?.Error?.Message,
//            errorStack = exceptionfeature?.Error?.StackTrace
//        });
//    });

//});

//using controller handle exception
//app.UseExceptionHandler("/error");
//app.Map("/error", branch =>
//{
//    branch.Run(async context =>
//    {
//        var exceptionfeature = context.Features.Get<IExceptionHandlerFeature>();
//        context.Response.StatusCode = 500;
//        context.Response.ContentType = "application/json";
//        await context.Response.WriteAsJsonAsync(new
//        {
//            message = "Something went wrodsfng",
//            exceptionProperMsg = exceptionfeature?.Error?.Message,
//            errorStack = exceptionfeature?.Error?.StackTrace
//        });
//    });
//});;
app.UseExceptionHandler("/error");
/*
Isme dikkat aa sakti hai:
app.UseExceptionHandler("/error");

Kyunki request ko / error ke saath poori pipeline me dobara bhejta hai.

Isliye agar tumhare middleware /error par bhi exception throw karte hain to:

An exception was thrown attempting to execute the error handler
    */

//route,class middleware,lambda function

app.MapControllers();

app.MapGet("/", () => { return Results.Ok($"Welcome to backend\n dbconnection path = {dbConnectioPath}"); });
//minimal -> endpoints -> endpointfilter

app.MapFallback(() =>
{
    return Results.NotFound("EndPoint Route Not Found");
});
app.Run(); //application runner