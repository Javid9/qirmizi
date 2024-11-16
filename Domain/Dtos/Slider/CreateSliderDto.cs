namespace Domain.Dtos.Slider
{
    public class CreateSliderDto
    {
        public string? Link { get; set; }
        public List<SliderLanguageDto>? SliderLanguages { get; set; }
    }
}
