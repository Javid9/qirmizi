using Domain.Common;

namespace Domain.Entities
{
    public class Photo : BaseEntity
    {
        public string? FileCode { get; set; }
        public string? ProductId { get; set; }
    }
}
