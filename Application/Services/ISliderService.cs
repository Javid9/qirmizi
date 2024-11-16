using Application.Helpers;
using Domain.Dtos.Slider;
using Microsoft.AspNetCore.Http;

namespace Application.Services
{
    public interface ISliderService
    {
        Task<ResponseModel<List<SliderDto>>> GetAllAsync();
        Task<ResponseModel<List<SliderClientDto>>> GetClientAllAsync(string? lang);
        Task<ResponseModel<UpdateSliderDto>> GetByIdAsync(string id);
        Task<ResponseModel<bool>> CreateAsync(CreateSliderDto model, IFormFile file);
        Task<ResponseModel<bool>> UpdateAsync(UpdateSliderDto model, IFormFile file);
        Task<ResponseModel<bool>> DeleteAsync(string id);
    }
}
