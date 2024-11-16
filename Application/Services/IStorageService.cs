using Application.Helpers;
using Microsoft.AspNetCore.Http;

namespace Application.Services
{
    public interface IStorageService
    {
        Task<ResponseModel<string>> UploadAsync(string path, IFormFile? file, bool isImageOptimize = false);
        ResponseModel<bool> Delete(string? path);
    }
}
