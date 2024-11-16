using Domain.Enums;

namespace Domain.Dtos.Event
{
    public class CreateEventDto
    {
        public DateTime? EventDay { get; set; }
        public string? Clock { get; set; }
        public string? PartnerLogo { get; set; }
        public string? FileCode { get; set; }
        public string? Map { get; set; }
        public string? Link { get; set; }
        public TicketType? TicketType { get; set; }
        public List<EventLangaugeDto>? EventLangauges { get; set; }
        public List<string>? CategoryIds { get; set; }
        public List<string>? SpeakerIds { get; set; }
    }
}
