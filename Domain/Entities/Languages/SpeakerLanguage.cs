﻿using Domain.Common;

namespace Domain.Entities.Languages
{
    public class SpeakerLanguage : BaseEntity
    {
        public string? SpeakerId { get; set; }
        public Speaker? Speaker { get; set; }
        public string? FullName { get; set; }
        public string? Text { get; set; }
        public string? Postion { get; set; }
        public string? Title { get; set; }
        public string? Language_Code { get; set; }
        public string? SeoTitle { get; set; }
        public string? SeoDesc { get; set; }
        public string? SeoKey { get; set; }
    }
}
