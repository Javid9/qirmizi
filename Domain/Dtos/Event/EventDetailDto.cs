using Domain.Dtos.Category;
using Domain.Dtos.Speaker;
using Domain.Enums;

namespace Domain.Dtos.Event
{
    public class EventDetailDto
    {
        public string? Id { get; set; }
        public string? Title { get; set; }
        public string? Text { get; set; }
        public string? Address { get; set; }
        public string? Price { get; set; }
        public string? Map { get; set; }
        public string? SlugUrl { get; set; }
        public string? FileCode { get; set; }
        public string? PartnerLogo { get; set; }
        public string? CreateDate { get; set; }
        public string? Clock { get; set; }
        public string? Link { get; set; }
        public TicketType? TicketType { get; set; }
        public List<CategoryDto>? Categories { get; set; }
        public List<SpeakerDto>? Speakers { get; set; }


    }
}
