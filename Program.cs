using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.SignalR;
using Hangfire;

var builder = WebApplication.CreateBuilder(args);

// // Configure Serilog for logging
// Log.Logger = new LoggerConfiguration()
//     .WriteTo.Console()
//     .WriteTo.File("logs/app.log", rollingInterval: RollingInterval.Day)
//     .CreateLogger();

// Add SignalR for real-time notifications
builder.Services.AddSignalR();

// // Register services
// builder.Services.AddScoped<ScraperJobService>();

// Add controllers
builder.Services.AddControllers();

// Enable CORS (if API is used by frontend apps)
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll",
        policy => policy.AllowAnyOrigin()
                        .AllowAnyMethod()
                        .AllowAnyHeader());
});

var app = builder.Build();

// Middleware pipeline
app.UseRouting();
app.UseCors("AllowAll");
app.UseAuthorization();
app.UseHangfireDashboard();

// // Exception Handling Middleware
// app.UseMiddleware<GlobalExceptionHandlerMiddleware>();

// // Map API endpoints
// app.UseEndpoints(endpoints =>
// {
//     endpoints.MapControllers();
//     endpoints.MapHub<NotificationHub>("/notifications");
// });

app.Run();
