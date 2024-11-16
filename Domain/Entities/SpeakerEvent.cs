using Domain.Common;

namespace Domain.Entities
{
    public class SpeakerEvent : BaseEntity
    {
        public string? SpeakerId { get; set; }
        public Speaker? Speaker { get; set; }
        public string? EventId { get; set; }
        public Event? Event { get; set; }
    }
}
