using Application.Helpers;
using Domain.Dtos.AppConfig;
using Microsoft.AspNetCore.Http;

namespace Application.Services
{
    public interface IAppConfigService
    {
        Task<ResponseModel<List<AppConfigDto>>> GetAllAsync();
        Task<ResponseModel<AppConfigDto?>> GetConfigAsync();
        Task<ResponseModel<AppConfigDto>> GetByIdAsync(string id);
        Task<ResponseModel<bool>> CreateAsync(AppConfigDto model, IFormFile file);
        Task<ResponseModel<bool>> UpdateAsync(AppConfigDto model, IFormFile file);
        Task<ResponseModel<bool>> DeleteAsync(string id);
       
    }
}
