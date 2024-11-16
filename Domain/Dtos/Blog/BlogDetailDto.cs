using Domain.Dtos.Category;

namespace Domain.Dtos.Blog
{
    public class BlogDetailDto
    {
        public string? Id { get; set; }
        public string? CategoryId { get; set; }
        public string? SlugUrl { get; set; }
        public string? FileCode { get; set; }
        public string? Title { get; set; }
        public string? Text { get; set; }
        public string? Clock { get; set; }
        public string? CreateDate { get; set; }
        public string? SeoTitle { get; set; }
        public string? SeoDesc { get; set; }
        public string? SeoKey { get; set; }
        public CategoryDetailDto? CategoryDetail { get; set; }
    }
}
