using Application.Helpers;
using Domain.Dtos.Speaker;
using Microsoft.AspNetCore.Http;

namespace Application.Services
{
    public interface ISpeakerService
    {
       
        Task<ResponseModel<List<SpeakerDto>>> GetAllAsync();
        Task<ResponseModel<List<SpeakerClientDto>>> SearchSpeakersAsync(string query, string? lang);
        Task<ResponseModel<List<SpeakerClientDto>>> GetClientAllAsync(string? lang);
        Task<ResponseModel<UpdateSpeakerDto>> GetByIdAsync(string id);
        Task<ResponseModel<bool>> CreateAsync(CreateSpeakerDto model, IFormFile file);
        Task<ResponseModel<bool>> UpdateAsync(UpdateSpeakerDto model, IFormFile file);
        Task<ResponseModel<bool>> DeleteAsync(string id);
    }
}
