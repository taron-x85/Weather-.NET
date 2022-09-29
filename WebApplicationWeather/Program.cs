using Microsoft.EntityFrameworkCore;
using System.Text.Json.Serialization;
using WebApplicationWeather.Controllers;
using WebApplicationWeather.DataSrc;
using WebApplicationWeather.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

    builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<WeatherContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));
builder.Services.AddTransient<IWeatherService, WeatherService>();
builder.Services.AddTransient<WeatherForecastController>();
builder.Services.AddScoped<IDataSeeder, DataSeeder>();

builder.Services.AddControllers().AddJsonOptions(x =>
                x.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles);

builder.Services.AddCors(options =>
{
    options.AddPolicy("ReactPolicy",
        policy =>
        {
            policy.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader().WithOrigins("http://localhost:3000").AllowCredentials();
        });
});
var app = builder.Build();
// Run seed data
if (args.Length == 1 && args[0].ToLower() == "runseed")
{
    await SeedData(app);
}

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.UseCors("ReactPolicy");

app.Run();

static async ValueTask SeedData(IHost app)
{
    var scopFactory = app.Services.GetService<IServiceScopeFactory>();

    using var scope = scopFactory?.CreateAsyncScope();
    var service = scope?.ServiceProvider.GetService<IDataSeeder>();
    if (service is not null) await service.Seed();
}
