using Domain.Common;

namespace Domain.Entities
{
    public class EventCategory : BaseEntity
    {
        public string? CategoryId { get; set; }
        public Category? Category { get; set; }
        public string? EventId { get; set; }
        public Event? Event { get; set; }

    }
}
