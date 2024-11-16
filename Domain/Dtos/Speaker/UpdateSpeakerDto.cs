namespace Domain.Dtos.Speaker
{
    public class UpdateSpeakerDto
    {
        public string? Id { get; set; }
        public string? FileCode { get; set; }
        public string? SlugUrl { get; set; }
        public string? Instagram { get; set; }
        public string? Facebook { get; set; }
        public string? Twitter { get; set; }
        public string? LinkedIn { get; set; }
        public List<SpeakerLanguageDto>? SpeakerLanguages { get; set; }
    }
}
