using Domain.Common;

namespace Domain.Entities
{
    public class AppConfig: BaseEntity
    {
        public string? FileCode { get; set; }
        public string? PhoneNumber { get; set; }
        public string? Email { get; set; }
        public string? MapCode { get; set; }
        public string? Address { get; set; }
        public string? Facebook { get; set; }
        public string? Instagram { get; set; }
        public string? Twitter { get; set; }
        public string? Linkedin { get; set; }
        public string? FacebookPixel { get; set; }
        public string? GoogleAnalytics { get; set; }


    }
}
