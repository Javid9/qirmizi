using Application.Helpers;
using Domain.Dtos.Event;
using Microsoft.AspNetCore.Http;

namespace Application.Services
{
    public interface IEventService
    {
        Task<ResponseModel<List<EventDto>>> GetAllAsync();
        Task<ResponseModel<List<EventClientDto>>> GetClientAllAsync(string? lang);
        Task<ResponseModel<UpdateEvenetDto>> GetByIdAsync(string id);
        Task<ResponseModel<EventDetailDto>> GetBySlugUrlAsync(string slugUrl, string lang);
        Task<ResponseModel<bool>> CreateAsync(CreateEventDto model, IFormFile file, IFormFile partnerLogo);
        Task<ResponseModel<bool>> UpdateAsync(UpdateEvenetDto model, IFormFile file, IFormFile partnerLogo);
        Task<ResponseModel<bool>> DeleteAsync(string id);
        Task<ResponseModel<bool>> AddSpeakerToEventAsync(string eventId, string speakerId);

    }
}
