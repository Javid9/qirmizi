using Domain.Dtos.Category;
using Domain.Dtos.Speaker;
using Domain.Enums;

namespace Domain.Dtos.Event
{
    public class UpdateEvenetDto
    {
        public string? Id { get; set; }
        public string? SlugUrl { get; set; }
        public string? FileCode { get; set; }
        public string? Partnerlogo { get; set; }
        public DateTime? EventDay { get; set; }
        public string? Clock { get; set; }
        public string? Map { get; set; }
        public string? Link { get; set; }
        public TicketType? TicketType { get; set; }
        public List<string>? CategoryIds { get; set; }
        public List<string>? SpeakerIds { get; set; }
        public List<EventLangaugeDto>? EventLangauges { get; set; }
      

    }
}
