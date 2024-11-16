using Application.Context;
using Application.Helpers;
using Application.Services;
using Domain.Constants;
using Domain.Dtos.About;
using Domain.Entities;
using Domain.Entities.Languages;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Services
{
    public class AboutService(IDatabaseContext context) : IAboutService
    {
        public async Task<ResponseModel<List<AboutDto>>> GetAllAsync()
        {
           var abouts = await context.Abouts
                .Include(x=>x.FaqFeatures)
                .ToListAsync();
          
           var entity = abouts.Select(x=> new AboutDto
           {
               Id = x.Id,
               SlugUrl = x.SlugUrl,

               FaqFeatures = x?.FaqFeatures!.Select(f=> new FaqFeatureDto
                {
                     Id = f.Id,
                     AboutId = f.AboutId,
                     Question = f.Question,
                     Answer = f.Answer,
                }).ToList()

           }).ToList();

            return ResponseModel<List<AboutDto>>.Success(entity, 200);
        }


        public async Task<ResponseModel<List<AboutClientDto>>> GetClientAllAsync(string? lang)
        {
            var abouts = await context.Abouts
                .Include(x => x.FaqFeatures)
                .ToListAsync();

            var entity = abouts.Select(x => new AboutClientDto
            {
                Id = x.Id,
                SlugUrl = x.SlugUrl,

                FaqFeatures = x?.FaqFeatures!.Select(f => new FaqFeatureDto
                {
                    Id = f.Id,
                    AboutId = f.AboutId,
                    Question = f.Question,
                    Answer = f.Answer,
                }).ToList()

            }).ToList();

            return ResponseModel<List<AboutClientDto>>.Success(entity, 200);
        }



        public async Task<ResponseModel<UpdateAboutDto>> GetByIdAsync(string id)
        {
           var entity = await context.Abouts
                .Include(x=> x.FaqFeatures)
                .FirstOrDefaultAsync(x=>x.Id == id);

            if (entity == null)
            {
                return ResponseModel<UpdateAboutDto>.Fail(Messages.NoDataFound, 404);
            }

            var model = new UpdateAboutDto
            {
                Id = id,
                SlugUrl = entity.SlugUrl,

                FaqFeatures = entity?.FaqFeatures!.Select(f=> new FaqFeatureDto
                {
                    Id = f.Id,
                    AboutId = f.AboutId,
                    Question = f.Question,
                    Answer = f.Answer,
                }).ToList()
                
            };

            return ResponseModel<UpdateAboutDto>.Success(model, 200);
        }


        public async Task<ResponseModel<bool>> CreateAsync(CreateAboutDto model)
        {
            try
            {
                
                var slugUrl = UrlSeoOperation.UrlSeo(model?.FaqFeatures?[0].Question!);

                var entity = new About
                {
                    SlugUrl = slugUrl,

                    FaqFeatures = model?.FaqFeatures?.Select(f=> new FaqFeature
                    {
                        Question = f.Question,
                        Answer = f.Answer,
                    }).ToList()
                   
                };

                await context.Abouts.AddAsync(entity);

                await context.SaveChangesAsync();

                return ResponseModel<bool>.Success(true, 200);
            }
            catch (Exception e)
            {

                return ResponseModel<bool>.Fail(e.Message, 400);
            }

        }



        public async Task<ResponseModel<bool>> UpdateAsync(UpdateAboutDto model)
        {
            try
            {
               

                var aboutDb = await context.Abouts.Include(x=>x.FaqFeatures).FirstOrDefaultAsync(x => x.Id == model.Id);


                if (aboutDb == null)
                {
                    return ResponseModel<bool>.Fail(Messages.NoDataFound, 404);
                }
              

                if (aboutDb.FaqFeatures is not null && aboutDb.FaqFeatures.Count > 0)
                {
                    await context.FaqFeatures.Where(x => x.AboutId == model.Id).ExecuteDeleteAsync();
                }

                model.SlugUrl = UrlSeoOperation.UrlSeo(model?.FaqFeatures?[0].Question!);


                context.Abouts.Update(aboutDb);

                await context.SaveChangesAsync();

                await UpdateFeature(model!);

                return ResponseModel<bool>.Success(true, 200);
            }
            catch (Exception e)
            {
                return ResponseModel<bool>.Fail(e.Message, 400);
            }
        }



        private async Task UpdateFeature(UpdateAboutDto model)
        {
            var feature = new List<FaqFeature>();

            feature = model.FaqFeatures?.Select(x => new FaqFeature
            {
                Answer = x.Answer,
                Question = x.Question,
                AboutId = model.Id,
            }).ToList();


            await context.FaqFeatures.AddRangeAsync(feature!);

            await context.SaveChangesAsync();
        }




        public async Task<ResponseModel<bool>> DeleteAsync(string id)
        {
            try
            {
                var entity = await context.Abouts
                .Include(x => x.FaqFeatures)
                .FirstOrDefaultAsync(r => r.Id == id);

                if (entity == null)
                {
                    return ResponseModel<bool>.Fail(Messages.NoDataFound, 404);
                }

                if(entity.FaqFeatures is { Count: > 0 })
                {
                    context.FaqFeatures.RemoveRange(entity.FaqFeatures);
                }

                  context.Abouts.Remove(entity);
 
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
