using Microsoft.EntityFrameworkCore;
using Scalar.AspNetCore;
using TP1_Voiture.ApiService.Data;
using TP1_Voiture.ApiService.Features.Locations.Reserver;
using TP1_Voiture.ApiService.Features.Voiture.GetCatalogue;
using TP1_Voiture.ApiService.Features.Voiture.GetDetail.CreateNewVehicule;
using TP1_Voiture.ApiService.Features.Voiture.GetDetail.GetVoitureById;
using TP1_Voiture.ApiService.Features.Voiture.GetDetail.GetVoitureByImmatriculation;

var builder = WebApplication.CreateBuilder(args);

// Add service defaults & Aspire client integrations.
builder.AddServiceDefaults();

// Add services to the container.
builder.Services.AddProblemDetails();

// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

builder.AddNpgsqlDbContext<RentalDbContext>("RentalDb");

builder.Services.AddScoped<LocationService>();

var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;
    try
    {
        var context = services.GetRequiredService<RentalDbContext>();

        // Retry pour attendre que PostgreSQL soit prêt
        var retries = 10;
        while (retries > 0)
        {
            try
            {
                await context.Database.CanConnectAsync();
                break;
            }
            catch
            {
                retries--;
                Console.WriteLine($"PostgreSQL pas encore prêt, {retries} essais restants...");
                await Task.Delay(3000); // Attend 3 secondes
            }
        }
        
        
        await context.Database.MigrateAsync();
        await SeedData.Initialize(context);

        Console.WriteLine("BD prête et remplie !");
    }
    catch (Exception ex)
    {
        var logger = services.GetRequiredService<ILogger<Program>>();
        logger.LogError(ex, message: "Erreur lors de l'initialisation de la BD.");
    }
}

if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    app.MapScalarApiReference(options =>
        {
            options.WithTitle("Location Auto API")
                .WithTheme(ScalarTheme.Moon)
                .WithDefaultHttpClient(ScalarTarget.CSharp, ScalarClient.HttpClient);
        });
}

// Configure the HTTP request pipeline.
app.UseExceptionHandler();

string[] summaries =
    ["Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"];

app.MapGet("/", () => "API service is running. Navigate to /weatherforecast to see sample data.");

app.MapGet("/weatherforecast", () =>
    {
        var forecast = Enumerable.Range(1, 5).Select(index =>
                new WeatherForecast
                (
                    DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
                    Random.Shared.Next(-20, 55),
                    summaries[Random.Shared.Next(summaries.Length)]
                ))
            .ToArray();
        return forecast;
    })
    .WithName("GetWeatherForecast");

app.MapDefaultEndpoints();

app.MapListVoitures();
app.MapReserver();
app.MapGetVoitureByIdEndpoint();
app.MapGetVoitureByImmatriculationEndpoint();
app.MapCreateNewVehiculeEndpoint();

app.Run();

record WeatherForecast(DateOnly Date, int TemperatureC, string? Summary)
{
    public int TemperatureF => 32 + (int)(TemperatureC / 0.5556);
}