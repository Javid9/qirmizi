using Domain.Common;

namespace Domain.Entities.Languages
{
    public class CategoryLanguage : BaseEntity
    {
        public string? Title { get; set; }
        public string? Language_Code { get; set; }
        public string? SeoTitle { get; set; }
        public string? SeoDesc { get; set; }
        public string? SeoKey { get; set; }
        public string? CategoryId { get; set; }
        public Category? Category { get; set; }
      
       
    }
}
