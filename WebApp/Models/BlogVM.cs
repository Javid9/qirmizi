using Domain.Dtos.Blog;

namespace WebApp.Models
{
    public class BlogVM
    {
        public List<BlogClientDto>? AllBlog { get; set; }
        public BlogDetailDto? GetBlog { get; set; }
    }
}
