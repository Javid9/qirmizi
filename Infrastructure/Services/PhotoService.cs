using Application.Context;
using Application.Helpers;
using Application.Services;
using Domain.Constants;
using Domain.Dtos.Photo;
using Domain.Entities;
using Mapster;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Services
{
    public class PhotoService(IStorageService storageService, IDatabaseContext context) : IPhotoService
    {
        public async Task<ResponseModel<bool>> CreateAsync(PhotoDto model, IFormFileCollection files)
        {
            try
            {
                foreach (var photo in files)
                {
                    var entity = model.Adapt<Photo>();

                    var uploadedPhoto = await storageService.UploadAsync(ImageUrl.Photos, photo);

                    entity.FileCode = uploadedPhoto.Data;
                    entity.Id = Guid.NewGuid().ToString();

                    await context.Photos.AddAsync(entity);
                    await context.SaveChangesAsync();
                }

                return ResponseModel<bool>.Success(true, 200);
            }
            catch (Exception e)
            {
                return ResponseModel<bool>.Fail(e.Message, 400);
            }
        }



        public async Task<ResponseModel<bool>> Delete(string id)
        {
            var entity = await context.Photos.FirstOrDefaultAsync(x => x.Id == id);

            if (entity == null)
                return ResponseModel<bool>.Fail(Messages.NoDataFound, 400);

            storageService.Delete(entity.FileCode!);
           

            await Task.FromResult(context.Photos.Remove(entity));

            await context.SaveChangesAsync();

            return ResponseModel<bool>.Success(true, 200);
        }

        public async Task<ResponseModel<List<PhotoDto>>> GetAllAsync(string? productId)
        {
            var entities = await context.Photos.Where(x => x.ProductId == productId).ToListAsync();

            var result = entities.Adapt<List<PhotoDto>>();

            return ResponseModel<List<PhotoDto>>.Success(result, 200);
        }


    }
}
