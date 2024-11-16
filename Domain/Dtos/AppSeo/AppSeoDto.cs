namespace Domain.Dtos.AppSeo
{
    public class AppSeoDto
    {
        public string? Id { get; set; }
        public string? PageName { get; set; }
        public List<AppSeoLanguageDto>? AppSeoLanguages { get; set; } 
    }
}
