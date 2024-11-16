namespace Domain.Dtos.About
{
    public class AboutDto
    {
        public string? Id { get; set; }
        public string? SlugUrl { get; set; }
        public List<FaqFeatureDto>? FaqFeatures { get; set; }
    }
}
