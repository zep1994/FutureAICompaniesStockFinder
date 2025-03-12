using Microsoft.EntityFrameworkCore;
using Hangfire;
using Hangfire.PostgreSql;
using Microsoft.Extensions.DependencyInjection;
using WebScraperAPI.Data;
using WebScraperAPI.Services;
using Serilog;

var builder = WebApplication.CreateBuilder(args);

// Configure Serilog for logging
Log.Logger = new LoggerConfiguration()
    .WriteTo.Console()
    .WriteTo.File("logs/app.log", rollingInterval: RollingInterval.Day)
    .CreateLogger();

builder.Host.UseSerilog();

// PostgreSQL Connection String
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

// Add Database Context
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseNpgsql(connectionString));

builder.Services.AddHangfire(config =>
    config.UsePostgreSqlStorage(options => 
    {
        options.UseNpgsqlConnection(connectionString);
    })
);


// Register Services
builder.Services.AddScoped<ScraperService>();

// Add Controllers
builder.Services.AddControllers();

var app = builder.Build();

app.UseRouting();
app.UseAuthorization();
app.UseHangfireDashboard();  

app.MapControllers();


app.Run();
