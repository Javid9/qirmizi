using Domain.Common;

namespace Domain.Entities.Languages
{
    public class BlogLanguage : BaseEntity
    {
        public string? Title { get; set; }
        public string? Text { get; set; }
        public string? Language_Code { get; set; }
        public string? SeoTitle { get; set; }
        public string? SeoDesc { get; set; }
        public string? SeoKey { get; set; }
        public string? BlogId { get; set; }
        public Blog? Blog { get; set; }
    }
}
