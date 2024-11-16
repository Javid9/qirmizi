using Application.Helpers;
using Domain.Dtos.Photo;
using Microsoft.AspNetCore.Http;

namespace Application.Services
{
    public interface IPhotoService
    {
        Task<ResponseModel<bool>> CreateAsync(PhotoDto model, IFormFileCollection files);
        Task<ResponseModel<bool>> Delete(string id);
        Task<ResponseModel<List<PhotoDto>>> GetAllAsync(string? productId);
    }
}
