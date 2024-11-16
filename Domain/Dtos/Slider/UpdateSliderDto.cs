namespace Domain.Dtos.Slider
{
    public class UpdateSliderDto
    {
        public string? Id { get; set; }
        public string? FileCode { get; set; }
        public string? SlugUrl { get; set; }
        public string? Link { get; set; }
        public List<SliderLanguageDto>? SliderLanguages { get; set; }
    }
}
