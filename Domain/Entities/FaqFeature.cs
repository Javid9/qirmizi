using Domain.Common;

namespace Domain.Entities
{
    public class FaqFeature : BaseEntity
    {
        public string? AboutId { get; set; }
        public About? About { get; set; }
        public string? Question { get; set; }
        public string? Answer { get; set; }
    }
}
