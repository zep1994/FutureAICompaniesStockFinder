using System.ComponentModel.DataAnnotations;

namespace WebScraperAPI.Models
{
    public class ScraperJob
    {
        [Key]
        public int Id { get; set; }
        public string Url { get; set; } = string.Empty;
        public int IntervalMinutes { get; set; }
        public bool NotifyByEmail { get; set; }
        public bool NotifyByApp { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    }
}
