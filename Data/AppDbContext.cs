using Microsoft.EntityFrameworkCore;
using WebScraperAPI.Models;

namespace WebScraperAPI.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<ScraperJob> ScraperJobs { get; set; }
    }
}
