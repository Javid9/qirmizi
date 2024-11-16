using Application.Context;
using Application.Helpers;
using Application.Services;
using Domain.Constants;
using Domain.Dtos.Speaker;
using Domain.Entities;
using Domain.Entities.Languages;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Services
{
    public class SpeakerService(IDatabaseContext context, IStorageService storageService) : ISpeakerService
    {
        public async Task<ResponseModel<List<SpeakerDto>>> GetAllAsync()
        {
           var entity = await context.Speakers.Include(x => x.SpeakerLanguages).Select(x => new SpeakerDto
            {
                Id = x.Id,
                FileCode = x.FileCode,
                FullName = x.SpeakerLanguages!.FirstOrDefault(l => l.Language_Code == "az")!.FullName,
                Postion = x.SpeakerLanguages!.FirstOrDefault(l => l.Language_Code == "az")!.Postion,
                SlugUrl = x.SlugUrl,
                Facebook = x.Facebook,
                Instagram = x.Instagram,
                Linkedin = x.Linkedin,
                Twitter = x.Twitter,

            }).ToListAsync();

            return ResponseModel<List<SpeakerDto>>.Success(entity, 200);
        }

        public async Task<ResponseModel<List<SpeakerClientDto>>> GetClientAllAsync(string? lang)
        {
            var entity = await context.Speakers
                .Include(x=>x.SpeakerLanguages)
                .Select(x => new SpeakerClientDto
                {
                    Id = x.Id,
                    FileCode = x.FileCode,
                    Instagram = x.Instagram,
                    Facebook = x.Facebook,
                    Twitter = x.Twitter,
                    LinkedIn = x.Linkedin,
                    FullName = x.SpeakerLanguages!.FirstOrDefault(l => l.Language_Code == lang)!.FullName,
                    Postion = x.SpeakerLanguages!.FirstOrDefault(l => l.Language_Code == lang)!.Postion,
                    Text = x.SpeakerLanguages!.FirstOrDefault(l=> l.Language_Code == lang)!.Text,
                    Title = x.SpeakerLanguages!.FirstOrDefault(l => l.Language_Code == lang)!.Title,
                }).ToListAsync();

            return ResponseModel<List<SpeakerClientDto>>.Success(entity, 200);      
        }



        public async Task<ResponseModel<UpdateSpeakerDto>> GetByIdAsync(string id)
        {
            var entity = await context.Speakers.Include(x => x.SpeakerLanguages).FirstOrDefaultAsync(x => x.Id == id);

            if (entity == null)
            {
                return ResponseModel<UpdateSpeakerDto>.Fail(Messages.NoDataFound, 404);
            }

            var result = new UpdateSpeakerDto
            {
                Id = entity.Id,
                FileCode = entity.FileCode,
                SlugUrl = entity.SlugUrl,
                Instagram = entity.Instagram,
                Facebook = entity.Facebook,
                Twitter = entity.Twitter,
                LinkedIn = entity.Linkedin,
                SpeakerLanguages = entity.SpeakerLanguages!.Select(x => new SpeakerLanguageDto
                {
                    LangId = x.Id,
                    Language_Code = x.Language_Code,
                    FullName = x.FullName,
                    Postion = x.Postion,
                    Text = x.Text,
                    SeoTitle = x.SeoTitle,
                    SeoDesc = x.SeoDesc,
                    SeoKey = x.SeoKey
                }).ToList()
            };

            return ResponseModel<UpdateSpeakerDto>.Success(result, 200);

        }

      

        public async Task<ResponseModel<bool>> CreateAsync(CreateSpeakerDto model, IFormFile file)
        {
            try
            {
                var fileCode = await storageService.UploadAsync(ImageUrl.Speaker, file);

                if (!fileCode.IsSuccess)
                {
                    return ResponseModel<bool>.Fail(Messages.NoDataFound, 404);
                }

                    var slugUrl = UrlSeoOperation.UrlSeo(model?.SpeakerLanguages?[0].FullName!);

                    var entity = new Speaker
                    {
                        FileCode = fileCode.Data,
                        SlugUrl = slugUrl,
                        Facebook = model?.Facebook,
                        Instagram = model?.Instagram,
                        Twitter = model?.Twitter,
                        Linkedin = model?.LinkedIn,
                  
                        SpeakerLanguages = model?.SpeakerLanguages?.Select(x => new SpeakerLanguage
                        {
                            Language_Code = x.Language_Code,
                            FullName = x.FullName,
                            Postion = x.Postion,
                            Text = x.Text,
                            Title = x.Title,
                            SeoTitle = x.SeoTitle,
                            SeoDesc = x.SeoDesc,
                            SeoKey = x.SeoKey
                        }).ToList()
                    };

                await context.Speakers.AddAsync(entity);

                await context.SaveChangesAsync();

                return ResponseModel<bool>.Success(true, 200);
            }


            catch (Exception e)
            {

               return ResponseModel<bool>.Fail(e.Message, 500);
            }
        }



        public async Task<ResponseModel<bool>> UpdateAsync(UpdateSpeakerDto model, IFormFile file)
        {
            try
            {
                var filePhoto = await storageService.UploadAsync(ImageUrl.Speaker, file);

                if (filePhoto.IsSuccess)
                {
                    if (model.FileCode is not null)
                    {
                        storageService.Delete(model.FileCode);
                    }

                    model.FileCode = filePhoto.Data;
                }

                model!.SlugUrl = UrlSeoOperation.UrlSeo(model?.SpeakerLanguages?[0].FullName!);

                var entity = new Speaker
                {
                    Id = model?.Id!,
                    FileCode = model?.FileCode,
                    SlugUrl = model?.SlugUrl,
                    Facebook = model?.Facebook,
                    Instagram = model?.Instagram,
                    Twitter = model?.Twitter,
                    Linkedin = model?.LinkedIn,

                    SpeakerLanguages = model?.SpeakerLanguages?.Select(x => new Domain.Entities.Languages.SpeakerLanguage
                    {
                        Id = x.LangId!,
                        SpeakerId = x.SpeakerId,
                        Language_Code = x.Language_Code,
                        Text = x.Text,
                        FullName = x.FullName,
                        Postion = x.Postion,
                        Title = x.Title,
                        SeoKey = x.SeoKey,
                        SeoDesc = x.SeoDesc,
                        SeoTitle = x.SeoTitle,
                    }).ToList()
                };

                context.Speakers.Update(entity);

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
                var entity = await context.Speakers.Include(x => x.SpeakerLanguages).FirstOrDefaultAsync(x => x.Id == id);

                if (entity == null)
                    return ResponseModel<bool>.Fail(Messages.NoDataFound, 400);

                if (entity.FileCode is not null)
                    storageService.Delete(entity.FileCode);

                if (entity.SpeakerLanguages is { Count: > 0 })
                    context.SpeakerLanguages.RemoveRange(entity.SpeakerLanguages);

                context.Speakers.Remove(entity);
                await context.SaveChangesAsync();

                return ResponseModel<bool>.Success(true, 200);
            }
            catch (Exception e)
            {
                return ResponseModel<bool>.Fail(e.Message, 400);
            }
        }



        public async Task<ResponseModel<List<SpeakerClientDto>>> SearchSpeakersAsync(string query, string? lang)
        {
          
            lang ??= "az";

            var speakers = await context.Speakers
                .Include(x => x.SpeakerLanguages)

                .Where(x => x.SpeakerLanguages!.Any(sl =>
                    (sl.FullName!.Contains(query) ||
                    sl.Postion!.Contains(query) ||
                    sl.Text!.Contains(query))))
                .Select(x => new SpeakerClientDto
                {
                    Id = x.Id,
                    FileCode = x.FileCode,
                    FullName = x.SpeakerLanguages!.FirstOrDefault(l => l.Language_Code == lang)!.FullName,
                    Postion = x.SpeakerLanguages!.FirstOrDefault(l => l.Language_Code == lang)!.Postion,
                    SlugUrl = x.SlugUrl,
                    Facebook = x.Facebook,
                    Instagram = x.Instagram,
                    LinkedIn = x.Linkedin,
                    Twitter = x.Twitter,
                })
                .ToListAsync();

            // Eğer sonuç boş ise uygun bir hata dönebiliriz
            if (speakers == null || speakers.Count == 0)
            {
                return ResponseModel<List<SpeakerClientDto>>.Fail(Messages.NoDataFound, 404);
            }

            // Başarılı bir sonuç döndürülür
            return ResponseModel<List<SpeakerClientDto>>.Success(speakers, 200);
        }




    }
}
