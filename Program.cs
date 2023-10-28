using System.Reflection;
using IbgeApi.ApiHandlers;
using IbgeApi.Data;
using IbgeApi.Repository;
using IbgeApi.Repository.Interfaces;
using IbgeApi.Services;
using IbgeApi.Services.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using ILocationService = IbgeApi.Services.Interfaces.ILocationService;

var builder = WebApplication.CreateBuilder(args);

var connectionString = builder.Configuration.GetConnectionString("SQLite");
builder.Services.AddDbContext<IbgeDbContext>(options =>
    options.UseSqlite(connectionString));

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options =>
{
    options.SwaggerDoc("v1", new OpenApiInfo
    {
        Version = "v1",
        Title = "Ibge API",
        Description = "Api com dados do Ibge",
        Contact = new OpenApiContact
        {
            Name = "Repositório - Github",
            Url = new Uri("https://github.com/achilesmatheus/ibge")
        },
    });
    var xmlFilename = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
    options.IncludeXmlComments(Path.Combine(AppContext.BaseDirectory, xmlFilename));
});

builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<ILocationRepository, LocationRepository>();
builder.Services.AddScoped<ITokenService, TokenService>();
builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<ILocationService, LocationService>();


var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

#region Api Heath Check

app.MapGet("/", HealthCheckHandler.Get);

#endregion

#region User

app.MapPost("/signup", AccountHandler.SignUp);
app.MapPost("/login", AccountHandler.Login);

#endregion

#region Location

app.MapPost("/location", LocationHandler.Create);
app.MapGet("/locations/{skip}/{take}", LocationHandler.GetAll);
app.MapGet("/location/{code}", LocationHandler.GetByIbgeCode);
app.MapGet("/location/state/{state}", LocationHandler.GetByState);
app.MapGet("/location/city/{city}", LocationHandler.GetByCity);
app.MapPut("/location/{code}", LocationHandler.Update);
app.MapDelete("/location/{code}", LocationHandler.Remove);

#endregion

app.Run();