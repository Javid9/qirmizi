using Domain.Common;
using Domain.Entities.Languages;

namespace Domain.Entities
{
    public class Blog : BaseEntity
    {
        public string? FileCode { get; set; }
        public string? SlugUrl { get; set; }
        public DateTime? CreateDate { get; set; }
        public string? Clock { get; set; }
        public string? CategoryId { get; set; }
        public Category? Category { get; set; }
        public List<BlogLanguage>? BlogLanguages { get; set; }
    }
}
