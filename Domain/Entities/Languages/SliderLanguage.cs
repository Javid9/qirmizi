using Domain.Common;

namespace Domain.Entities.Languages
{
    public class SliderLanguage :BaseEntity
    {
        public string? SliderId { get; set; }
        public Slider? Slider { get; set; }
        public string? Title { get; set; }
        public string? Language_Code { get; set; }
        public string? SeoTitle { get; set; }
        public string? SeoDesc { get; set; }
        public string? SeoKey { get; set; }
     
    }
}
