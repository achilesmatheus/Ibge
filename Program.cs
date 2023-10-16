using IbgeApi.ApiHandlers;
using IbgeApi.Data;
using IbgeApi.Models;
using IbgeApi.Repository;
using IbgeApi.Repository.Interfaces;
using IbgeApi.Services;
using IbgeApi.ViewModels;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

var connectionString = builder.Configuration.GetConnectionString("SQLite");
builder.Services.AddDbContext<IbgeDbContext>(options =>
    options.UseSqlite(connectionString));

builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<TokenService>();

var app = builder.Build();

app.MapGet("/", ApiHealthCheckHandler.Get);
app.MapPost("/signin", AccountHandler.SignIn);
app.MapPost("/login", AccountHandler.Login);

app.Run();