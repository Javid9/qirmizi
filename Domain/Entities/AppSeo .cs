using Domain.Common;
using Domain.Entities.Languages;

namespace Domain.Entities
{
    public class AppSeo: BaseEntity
    {
        public string? PageName { get; set; }
        public List<AppSeoLanguage>? AppSeoLanguages{ get; set; }
    }
}
