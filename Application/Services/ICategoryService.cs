using Application.Helpers;
using Domain.Dtos.Category;

namespace Application.Services
{
    public interface ICategoryService
    {
        Task<ResponseModel<List<CategoryDto>>> GetAllAsync();
        Task<ResponseModel<UpdateCategoryDto>> GetByIdAsync(string id);
        Task<ResponseModel<CategoryDetailDto>> GetBySlugUrlAsync(string slugUrl, string lang);
        Task<ResponseModel<bool>> CreateAsync(CreateCategoryDto model);
        Task<ResponseModel<bool>> UpdateAsync(UpdateCategoryDto model);
        Task<ResponseModel<bool>> DeleteAsync(string id);

    }
}
