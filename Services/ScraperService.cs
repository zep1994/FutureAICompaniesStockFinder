using System.Diagnostics;
using Microsoft.Extensions.Logging;

namespace WebScraperAPI.Services
{
    public class ScraperService
    {
        private readonly ILogger<ScraperService> _logger;

        public ScraperService(ILogger<ScraperService> logger)
        {
            _logger = logger;
        }

        public void RunScraper()
        {
            try
            {
                _logger.LogInformation("Starting Python scraper...");

                // Set up the process to run the Python script
                ProcessStartInfo start = new ProcessStartInfo
                {
                    FileName = "python",  // Ensure 'python' is in PATH
                    Arguments = "Scrapper/run_scraper.py",  // Adjust path if needed
                    RedirectStandardOutput = true,
                    RedirectStandardError = true,
                    UseShellExecute = false,
                    CreateNoWindow = true
                };

                using (Process process = Process.Start(start))
                {
                    string output = process.StandardOutput.ReadToEnd();
                    string error = process.StandardError.ReadToEnd();
                    process.WaitForExit();

                    if (!string.IsNullOrEmpty(output))
                        _logger.LogInformation($"Python Scraper Output: {output}");

                    if (!string.IsNullOrEmpty(error))
                        _logger.LogError($"Python Scraper Error: {error}");
                }
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error running Python scraper: {ex.Message}");
            }
        }
    }
}
