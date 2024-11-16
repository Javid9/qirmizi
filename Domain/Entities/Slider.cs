using Domain.Common;
using Domain.Entities.Languages;

namespace Domain.Entities
{
    public class Slider :BaseEntity
    {
        public string? FileCode { get; set; }
        public string? SlugUrl { get; set; }
        public string? Link { get; set; }
        public List<SliderLanguage>? SliderLanguages { get; set; }
    }
}
