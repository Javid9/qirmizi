using Application.Helpers;
using Domain.Dtos.Blog;
using Microsoft.AspNetCore.Http;

namespace Application.Services
{
    public interface IBlogService
    {
        Task<ResponseModel<List<BlogDto>>> GetAllAsync();
        Task<ResponseModel<List<BlogClientDto>>> GetClientAllAsync(string? lang);
        Task<ResponseModel<UpdateBlogDto>> GetByIdAsync(string id);
        Task<ResponseModel<BlogDetailDto>> GetBySlugUrlAsync(string slugUrl, string lang);
        Task<ResponseModel<bool>> CreateAsync(CreateBlogDto model, IFormFile file);
        Task<ResponseModel<bool>> UpdateAsync(UpdateBlogDto model, IFormFile file);
        Task<ResponseModel<bool>> DeleteAsync(string id);
    }
}
