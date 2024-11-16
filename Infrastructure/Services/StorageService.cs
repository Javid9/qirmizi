using Application.Helpers;
using Application.Services;
using Domain.Constants;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;

namespace Infrastructure.Services
{
    public class StorageService(IWebHostEnvironment _environment) : IStorageService
    {
        public ResponseModel<bool> Delete(string? path)
        {
            if (path == null) throw new ArgumentNullException(nameof(path));
            var uploadPath = Path.Combine(_environment.WebRootPath, path);
            File.Delete(uploadPath);
            return ResponseModel<bool>.Success(true, 200);
        }



        public async Task<ResponseModel<string>> UploadAsync(string path, IFormFile? file, bool isImageOptimize = false)
        {
            if (file?.Length <= 0 || file is null)
            {
                return ResponseModel<string>.Fail(Messages.NoDataFound, 404);
            }
            if (string.IsNullOrEmpty(_environment.WebRootPath))
                _environment.WebRootPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot");

            var uploadPath = Path.Combine(_environment.WebRootPath, path);

            if (!Directory.Exists(uploadPath))
                Directory.CreateDirectory(uploadPath);

            var fileNewName = $"{Path.GetRandomFileName()}{Path.GetExtension(file.FileName)}";

            var newPath = uploadPath + "/" + fileNewName;
            await CopyFileAsync(newPath, file);

            if (isImageOptimize)
                await file.ImageOptimize(newPath);


            return ResponseModel<string>.Success($"{path}/{fileNewName}", 200);
        }


        private static async Task CopyFileAsync(string path, IFormFile? file)
        {
            await using FileStream fileStream = new(path, FileMode.Create, FileAccess.Write, FileShare.None, 1024 * 1024,
                useAsync: false);

            if (file != null) await file.CopyToAsync(fileStream);

            await fileStream.FlushAsync();
        }






    }
}
