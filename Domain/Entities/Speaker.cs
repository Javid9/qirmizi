using Domain.Common;
using Domain.Entities.Languages;

namespace Domain.Entities
{
    public class Speaker : BaseEntity
    {
        public string? FileCode { get; set; }
        public string? Facebook { get; set; }
        public string? Instagram { get; set; }
        public string? Twitter { get; set; }
        public string? Linkedin { get; set; }
        public string? SlugUrl { get; set; }
        public List<SpeakerLanguage>? SpeakerLanguages { get; set; }
        public List<SpeakerEvent>? SpeakerEvents { get; set; }
    }
}
