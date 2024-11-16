using Domain.Common;

namespace Domain.Entities.Languages
{
    public class EventLanguage :BaseEntity
    {
        public string? Title { get; set; }
        public string? Address { get; set; }
        public string? Text { get; set; }
        public string? Price { get; set; }
        public string? Language_Code { get; set; }
        public string? SeoTitle { get; set; }
        public string? SeoDesc { get; set; }
        public string? SeoKey { get; set; }
        public string? EventId { get; set; }
        public Event? Event { get; set; }

    }
}
