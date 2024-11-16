namespace Domain.Dtos.Category
{
    public class UpdateCategoryDto
    {
        public string? Id { get; set; }
        public string? SlugUrl { get; set; }
        public List<CategoryLanguageDto>? CategoryLanguages { get; set; }
    }
}
