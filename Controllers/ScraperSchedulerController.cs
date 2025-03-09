using Microsoft.AspNetCore.Mvc;
using Hangfire;
using WebScraperAPI.Services;
using Microsoft.Extensions.Logging;

namespace WebScraperAPI.Controllers
{
    [Route("api/scheduler")]
    [ApiController]
    public class ScraperSchedulerController : ControllerBase
    {
        private readonly ILogger<ScraperSchedulerController> _logger;

        public ScraperSchedulerController(ILogger<ScraperSchedulerController> logger)
        {
            _logger = logger;
        }

        [HttpPost("schedule")]
        public IActionResult ScheduleScraping()
        {
            try
            {
                RecurringJob.AddOrUpdate<ScraperService>(
                    "scraper_job",
                    service => service.RunScraper(),
                    Cron.Minutely); // Adjust interval as needed

                _logger.LogInformation("✅ Scrapy job scheduled successfully.");
                return Ok(new { message = "Scrapy job scheduled." });
            }
            catch (Exception ex)
            {
                _logger.LogError($"❌ Error scheduling Scrapy job: {ex.Message}");
                return StatusCode(500, "Failed to schedule Scrapy job.");
            }
        }

        [HttpPost("run-now")]
        public IActionResult RunScraperImmediately([FromServices] ScraperService scraperService)
        {
            try
            {
                scraperService.RunScraper();
                _logger.LogInformation("✅ Scraper executed manually.");
                return Ok(new { message = "Scraper executed." });
            }
            catch (Exception ex)
            {
                _logger.LogError($"❌ Error running scraper manually: {ex.Message}");
                return StatusCode(500, "Failed to execute scraper.");
            }
        }
    }
}
