using Microsoft.EntityFrameworkCore; // ORM framework that allows us to use .NET objects in databases
using EconomicsTrackerApi.Models;
using EconomicsTrackerApi.Database;
using Microsoft.AspNetCore.Identity;
using EconomicsTrackerApi.Controllers;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using Microsoft.Extensions.Diagnostics.HealthChecks;
using Microsoft.AspNetCore.Diagnostics.HealthChecks;



var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();
// Adding Controllers to dependency injection container
builder.Services.AddControllers();
// Adding DBContext with SQlite database provider
builder.Services.AddDbContext<EconomicsTrackerContext>(options =>
    options.UseSqlite(builder.Configuration.GetConnectionString("DefaultConnection")));
// Adding Identity for use in user authentication and authorisation
builder.Services.AddIdentity<ApplicationUser, IdentityRole>()
    .AddEntityFrameworkStores<EconomicsTrackerContext>().AddDefaultTokenProviders();
// Adding email services
builder.Services.Configure<EmailSettings>(builder.Configuration.GetSection("EmailSettings"));
builder.Services.AddScoped<EmailService>();
// Registering JWT authentication
builder.Services.AddScoped<RolesController>();
builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
})
    .AddJwtBearer(options =>
    {
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuer = true,
            ValidateAudience = true,
            ValidateLifetime = true,
            ValidateIssuerSigningKey = true,
            ValidIssuer = builder.Configuration["Jwt:Issuer"],
            ValidAudience = builder.Configuration["Jwt:Issuer"],
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["Jwt:Key"]!))
        };
    });
// Registering interfaces
builder.Services.AddScoped<IDataService, DataService>();
builder.Services.AddScoped<IIndicatorService, IndicatorService>();
builder.Services.AddScoped<IRegionService, RegionService>();
// Adding CORS services
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowReactApp", builder =>
    {
        builder.WithOrigins("http://localhost:5173")     // Allow all origins
               .AllowAnyMethod()     // Allow any HTTP method
               .AllowAnyHeader();    // Allow any header
    });
});
// Adding Health Checks
builder.Services.AddHealthChecks()
    .AddDbContextCheck<EconomicsTrackerContext>() // Check if DB is reachable
    .AddCheck("self", () => HealthCheckResult.Healthy()); // Check if the application itself is running and responsive
    


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();

var summaries = new[]
{
    "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
};

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

app.MapControllers(); // Mapping Controllers
app.UseAuthentication();
app.UseAuthorization();
app.UseCors("AllowReactApp"); // Apply the CORS policy globally
app.UseMiddleware<RateLimitingMiddleware>(10, TimeSpan.FromMinutes(1)); // 10 requests per minute
app.MapHealthChecks("/health"); // Mapping health checks




app.Run();

record WeatherForecast(DateOnly Date, int TemperatureC, string? Summary)
{
    public int TemperatureF => 32 + (int)(TemperatureC / 0.5556);
}
