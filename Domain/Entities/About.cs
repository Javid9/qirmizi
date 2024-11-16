using Domain.Common;
using Domain.Entities.Languages;

namespace Domain.Entities
{
    public class About :BaseEntity
    {
        public string? SlugUrl { get; set; }
        public List<FaqFeature>? FaqFeatures { get; set; }

    }
}
