using Application.Context;
using Application.Helpers;
using Application.Services;
using Domain.Constants;
using Domain.Dtos.AppConfig;
using Domain.Entities;
using Mapster;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Services
{
    public class AppConfigService(IStorageService _storageService, IDatabaseContext _context) : IAppConfigService
    {

        public async Task<ResponseModel<List<AppConfigDto>>> GetAllAsync()
        {
            var entities = await _context.AppConfigs.ProjectToType<AppConfigDto>().ToListAsync();

            return ResponseModel<List<AppConfigDto>>.Success(entities, 200);

        }


        public async Task<ResponseModel<AppConfigDto>> GetByIdAsync(string id)
        {
            var entity = await _context.AppConfigs.FirstOrDefaultAsync(x => x.Id == (id));

            if (entity == null)
                return ResponseModel<AppConfigDto>.Fail(Messages.NoDataFound, 400);

            var result = entity.Adapt<AppConfigDto>();

            return ResponseModel<AppConfigDto>.Success(result, 200);

        }


        public async Task<ResponseModel<AppConfigDto?>> GetConfigAsync()
        {
            var entities = await _context.AppConfigs.ProjectToType<AppConfigDto>().FirstOrDefaultAsync();
            return ResponseModel<AppConfigDto?>.Success(entities, 200);
        }


        public async Task<ResponseModel<bool>> CreateAsync(AppConfigDto model, IFormFile file)
        {
            try
            {
                var fileCode = await _storageService.UploadAsync(ImageUrl.AppConfig, file);
                if (!fileCode.IsSuccess)
                    return ResponseModel<bool>.Fail(Messages.NoDataFound, 400);

                model.FileCode = fileCode.Data;

                var entity = new AppConfig
                {
                    FileCode = model.FileCode,
                    Address = model.Address,
                    GoogleAnalytics = model.GoogleAnalytics,
                    Email = model.Email,
                    PhoneNumber = model.PhoneNumber,
                    FacebookPixel  = model.FacebookPixel,
                    Facebook = model.Facebook,
                    Instagram = model.Instagram,
                    Twitter = model.Twitter,
                    Linkedin = model.Linkedin,

                };

                await _context.AppConfigs.AddAsync(entity);
                await _context.SaveChangesAsync();

                return ResponseModel<bool>.Success(true, 200);

            }
            catch (Exception e)
            {
                return ResponseModel<bool>.Fail(e.Message, 400);
            }
        }




        public async Task<ResponseModel<bool>> UpdateAsync(AppConfigDto model, IFormFile file)
        {
            try
            {
                var fileCode = await _storageService.UploadAsync(ImageUrl.AppConfig, file);
                if (fileCode.IsSuccess)
                {
                    _storageService.Delete(model.FileCode!);
                    model.FileCode = fileCode.Data;
                }

                var entity = model.Adapt<AppConfig>();

                 _context.AppConfigs.Update(entity);

                await _context.SaveChangesAsync();

                return ResponseModel<bool>.Success(true, 200);

            }
            catch (Exception e)
            {

                return ResponseModel<bool>.Fail(e.Message, 400);
            }
        }


        public async Task<ResponseModel<bool>> DeleteAsync(string id)
        {
            try
            {
                var entity = await _context.AppConfigs.FirstOrDefaultAsync(x => x.Id == (id));

                if (entity == null)
                    return ResponseModel<bool>.Fail(Messages.NoDataFound, 400);

                _storageService.Delete(entity.FileCode!);

                _context.AppConfigs.Remove(entity);

                await _context.SaveChangesAsync();

                return ResponseModel<bool>.Success(true, 200);

            }
            catch (Exception e)
            {
                return ResponseModel<bool>.Fail(e.Message, 400);
            }
        }



    }
}
