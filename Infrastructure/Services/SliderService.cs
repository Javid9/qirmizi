using Application.Context;
using Application.Helpers;
using Application.Services;
using Domain.Constants;
using Domain.Dtos.Slider;
using Domain.Entities;
using Mapster;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Services
{
    public class SliderService(IDatabaseContext context, IStorageService storageService) : ISliderService
    {

        public async Task<ResponseModel<List<SliderDto>>> GetAllAsync()
        {
            var entity = await context.Sliders.Include(x => x.SliderLanguages).Select(x => new SliderDto
            {
                Id = x.Id,
                FileCode = x.FileCode,
                Title = x.SliderLanguages!.FirstOrDefault(l => l.Language_Code == "az")!.Title,
                SlugUrl = x.SlugUrl,
            }).ToListAsync();

            return ResponseModel<List<SliderDto>>.Success(entity, 200);
        }


        public async Task<ResponseModel<List<SliderClientDto>>> GetClientAllAsync(string? lang)
        {
            var sliders = context.Sliders
               .Include(x => x.SliderLanguages)
               .AsQueryable();

            var result = await sliders.Select(x =>
                    new SliderClientDto
                    {
                        Id = x.Id,
                        FileCode = x.FileCode,
                        SlugUrl = x.SlugUrl,
                        Link = x.Link,
                        Title = x.SliderLanguages!.FirstOrDefault(l => l.Language_Code == lang)!.Title,
                    })
                .ToListAsync();

            return ResponseModel<List<SliderClientDto>>.Success(result, 200);
        }



        public async Task<ResponseModel<UpdateSliderDto>> GetByIdAsync(string id)
        {
            var entity = await context.Sliders.Include(x => x.SliderLanguages).FirstOrDefaultAsync(x => x.Id == id);

            if (entity == null)
                return ResponseModel<UpdateSliderDto>.Fail(Messages.NoDataFound, 400);

            var result = new UpdateSliderDto
            {
                Id = id,
                FileCode = entity.FileCode,
                Link = entity.Link,
                SliderLanguages = entity.SliderLanguages!.Select(x => new SliderLanguageDto
                {
                    LangId = x.Id,
                    Language_Code = x.Language_Code,
                    SliderId = x.SliderId,
                    Title = x.Title
                }).ToList()
            };

            return ResponseModel<UpdateSliderDto>.Success(result, 200);
        }


        public async Task<ResponseModel<bool>> CreateAsync(CreateSliderDto model, IFormFile file)
        {
            try
            {
                var fileCode = await storageService.UploadAsync(ImageUrl.Slider, file, false);

                if (!fileCode.IsSuccess)
                    return ResponseModel<bool>.Fail(Messages.NoDataFound, 400);


                var slugUrl = UrlSeoOperation.UrlSeo(model?.SliderLanguages?[0].Title!);
                var result = model.Adapt<Slider>();

                result.FileCode = fileCode.Data;
                result.SlugUrl = slugUrl;

                await context.Sliders.AddAsync(result);

                await context.SaveChangesAsync();
                return ResponseModel<bool>.Success(true, 200);
            }
            catch (Exception e)
            {
                return ResponseModel<bool>.Fail(e.Message, 400);
            }
        }



        public async Task<ResponseModel<bool>> UpdateAsync(UpdateSliderDto model, IFormFile file)
        {
            try
            {
                var filePhoto = await storageService.UploadAsync(ImageUrl.Slider, file);

                if (filePhoto.IsSuccess)
                {
                    if (model.FileCode is not null)
                    {
                        storageService.Delete(model.FileCode);
                    }

                    model.FileCode = filePhoto.Data;
                }

                var entity = new Slider
                {
                    Id = model.Id!,
                    FileCode = model.FileCode,
                    SlugUrl = model.SlugUrl,
                    Link = model.Link,
                   
                    SliderLanguages = model?.SliderLanguages?.Select(x => new Domain.Entities.Languages.SliderLanguage
                    {
                        Id = x.LangId!,
                        SliderId = x.SliderId,
                        Language_Code = x.Language_Code,
                        Title = x.Title,
                    }).ToList()
                };

                context.Sliders.Update(entity);

                await context.SaveChangesAsync();

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
                var entity = await context.Sliders.Include(x => x.SliderLanguages).FirstOrDefaultAsync(x => x.Id == id);

                if (entity == null)
                    return ResponseModel<bool>.Fail(Messages.NoDataFound, 400);

                if (entity.FileCode is not null)
                    storageService.Delete(entity.FileCode);

                if (entity.SliderLanguages is { Count: > 0 })
                    context.SliderLanguages.RemoveRange(entity.SliderLanguages);

                context.Sliders.Remove(entity);
                await context.SaveChangesAsync();

                return ResponseModel<bool>.Success(true, 200);
            }
            catch (Exception e)
            {
                return ResponseModel<bool>.Fail(e.Message, 400);
            }
        }


    }
}
