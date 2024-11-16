using Domain.Common;
using Domain.Entities.Languages;
using Domain.Enums;

namespace Domain.Entities
{
    public class Event : BaseEntity
    {
        public string? SlugUrl { get; set; }
        public DateTime? EventDay { get; set; }
        public string? Clock { get; set; }
        public string? PartnerLogo { get; set; }
        public string? FileCode { get; set; }
        public string? Map { get; set; }
        public string? Link { get; set; }
        public TicketType? TicketType { get; set; }
        public List<EventLanguage>? EventLanguages { get; set; }
        public List<EventCategory>? EventCategories { get; set; }
        public List<SpeakerEvent>? SpeakerEvents { get; set; }
    }
}
