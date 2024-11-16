using Domain.Common;

namespace Domain.Entities.Languages
{
    public class AppSeoLanguage: BaseEntity
    {
        public string? AppSeoId { get; set; }
        public string? Language_Code { get; set; }
        public string? Title { get; set; }
        public string? Keyword { get; set; }
        public string? Description { get; set; }
        public AppSeo? AppSeo { get; set; }
    }
}
