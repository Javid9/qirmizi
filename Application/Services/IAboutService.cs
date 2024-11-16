using Application.Helpers;
using Domain.Dtos.About;
using Domain.Dtos.Blog;
using Microsoft.AspNetCore.Http;

namespace Application.Services
{
    public interface IAboutService
    {
        Task<ResponseModel<List<AboutDto>>> GetAllAsync();
        Task<ResponseModel<List<AboutClientDto>>> GetClientAllAsync(string? lang);
        Task<ResponseModel<UpdateAboutDto>> GetByIdAsync(string id);
        Task<ResponseModel<bool>> CreateAsync(CreateAboutDto model);
        Task<ResponseModel<bool>> UpdateAsync(UpdateAboutDto model);
        Task<ResponseModel<bool>> DeleteAsync(string id);
    }
}
