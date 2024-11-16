using Domain.Dtos.Category;
using Domain.Dtos.Speaker;

namespace Domain.Dtos.Event
{
    public class EventClientDto
    {
        public string? Id { get; set; }
        public string? FileCode { get; set; }
        public string? EventDay { get; set; }
        public string? SlugUrl { get; set; }
        public string? Clock { get; set; }
        public string? Title { get; set; }
        public string? Address { get; set; }
        public List<SpeakerDto>? Speakers { get; set; }
        public List<CategoryDto>? Categories { get; set; }

    }
}
