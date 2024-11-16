namespace Domain.Dtos.Blog
{
    public class CreateBlogDto
    {
        public string? FileCode { get; set; }
        public DateTime? CreateDate { get; set; }
        public string? Clock { get; set; }
        public string? CategoryId { get; set; }
        public List<BlogLanguageDto>? BlogLanguages { get; set; }
    }
}
