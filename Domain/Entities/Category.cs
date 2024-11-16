using Domain.Common;
using Domain.Entities.Languages;

namespace Domain.Entities
{
    public class Category : BaseEntity
    {
        public string? SlugUrl { get; set; }
        public List<CategoryLanguage>? CategoryLanguages { get; set; }
        public List<EventCategory>? EventCategories { get; set; }
        public List<Blog>? Blogs { get; set; }
    }
}
