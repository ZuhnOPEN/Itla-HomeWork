#nullable enable
using BusStationAPI.Application.Interfaces;
using BusStationAPI.Application.Services;
using BusStationAPI.Domain.Interfaces;
using BusStationAPI.Infrastructure.Data;
using BusStationAPI.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"),
        sqlServerOptionsAction: sqlOptions =>
        {
            sqlOptions.EnableRetryOnFailure(
                maxRetryCount: 3,
                maxRetryDelay: TimeSpan.FromSeconds(5),
                errorNumbersToAdd: null);
        }));

builder.Services.AddScoped<IBusStationRepository, BusStationRepository>();
builder.Services.AddScoped<IBusStationService, BusStationService>();

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowBlazor", policy =>
    {
        policy.WithOrigins(
                "https://localhost:7172", "http://localhost:5181", // Blazor ports actualizados
                "https://localhost:7002", "http://localhost:5002", // API ports actualizados
                "https://localhost:7000", "https://localhost:7001", "http://localhost:5000", "http://localhost:5001" // Puertos adicionales por compatibilidad
              )
              .AllowAnyMethod()
              .AllowAnyHeader()
              .AllowCredentials();
    });
});

var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;
    try
    {
        var context = services.GetRequiredService<AppDbContext>();
        context.Database.Migrate();
    }
    catch (Exception ex)
    {
        var logger = services.GetRequiredService<ILogger<Program>>();
        logger.LogError(ex, "Error al aplicar migraciones de la base de datos");
    }
}

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "BusStation API v1");
        c.RoutePrefix = string.Empty; 
    });
}

app.UseHttpsRedirection();

app.UseCors("AllowBlazor");

app.UseAuthorization();

app.MapControllers();

app.MapGet("/health", async (AppDbContext context) => 
{
    try 
    {
        await context.Database.CanConnectAsync();
        var stationCount = await context.BusStations.CountAsync();
        
        return Results.Ok(new { 
            status = "API is running",
            database = "Connected", 
            stationCount = stationCount,
            timestamp = DateTime.UtcNow 
        });
    }
    catch (Exception ex)
    {
        return Results.Problem($"Database connection failed: {ex.Message}");
    }
})
.WithName("Health Check");

app.Run();
