using Application.Context;
using Application.Helpers;
using Application.Services;
using Domain.Constants;
using Domain.Dtos.Category;
using Domain.Entities;
using Domain.Entities.Languages;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Services
{
    public class CategoryService(IDatabaseContext context) : ICategoryService
    {

        public async Task<ResponseModel<List<CategoryDto>>> GetAllAsync()
        {
            var categories = await context.Categories
            .Include(x => x.CategoryLanguages)
            .Select(x => new CategoryDto
            {
                Id = x.Id,
                SlugUrl = x.SlugUrl,
                Title = x.CategoryLanguages!.FirstOrDefault(x => x.Language_Code == "az")!.Title
            }).AsNoTracking().ToListAsync();

            return ResponseModel<List<CategoryDto>>.Success(categories, 200);

        }


        public async Task<ResponseModel<UpdateCategoryDto>> GetByIdAsync(string id)
        {
            var entity = await context
                .Categories.Include(x => x.CategoryLanguages)
                .FirstOrDefaultAsync(x => x.Id == id);

            if (entity == null)
                return ResponseModel<UpdateCategoryDto>.Fail(Messages.NoDataFound, 400);

            var result = new UpdateCategoryDto
            {
                Id = id,
                SlugUrl = entity.SlugUrl,
                CategoryLanguages = entity.CategoryLanguages!.Select(x => new CategoryLanguageDto
                {
                    LangId = x.Id,
                    Language_Code = x.Language_Code,
                    CategoryId = x.CategoryId,
                    Title = x.Title,
                    SeoDesc = x.SeoDesc,
                    SeoTitle = x.SeoTitle,
                    SeoKey = x.SeoKey

                }).ToList()
            };

            return ResponseModel<UpdateCategoryDto>.Success(result, 200);
        }



        public async Task<ResponseModel<CategoryDetailDto>> GetBySlugUrlAsync(string slugUrl, string lang)
        {
            var entity = await context.Categories
               .Include(x => x.CategoryLanguages)
               .FirstOrDefaultAsync(x => x.SlugUrl == slugUrl);

            if (entity == null)
                return ResponseModel<CategoryDetailDto>.Fail(Messages.NoDataFound, 400);

            var categoryLang = entity.CategoryLanguages?.FirstOrDefault(x => x.Language_Code == lang);

            var result = new CategoryDetailDto()
            {
                Id = entity.Id,
                SlugUrl = entity.SlugUrl,
                Title = categoryLang?.Title,
            };

             return ResponseModel<CategoryDetailDto>.Success(result, 200);

        }


        public async Task<ResponseModel<bool>> CreateAsync(CreateCategoryDto model)
        {
            try
            {

                var slugUrl = UrlSeoOperation.UrlSeo(model?.CategoryLanguages?[0].Title!);

                var entity = new Category
                {

                    CategoryLanguages = model?.CategoryLanguages?.Select(x => new CategoryLanguage
                    {
                        Language_Code = x.Language_Code,
                        CategoryId = x.CategoryId,
                        Title = x.Title,
                        SeoDesc = x.SeoDesc,
                        SeoTitle = x.SeoTitle,
                        SeoKey = x.SeoKey,
                    }).ToList()
                };

                entity.SlugUrl = slugUrl;

                await context.Categories.AddAsync(entity);

                await context.SaveChangesAsync();

                return ResponseModel<bool>.Success(true, 200);
            }
            catch (Exception e)
            {

                return ResponseModel<bool>.Fail(e.Message, 400);
            }
        }



        public async Task<ResponseModel<bool>> UpdateAsync(UpdateCategoryDto model)
        {
            try
            {
                if (model is null)
                {
                    return ResponseModel<bool>.Fail(Messages.NoDataFound, 404);
                }

                var categoryDb = await context.Categories.Include(x => x.CategoryLanguages).FirstOrDefaultAsync(x => x.Id == model.Id);

                if (categoryDb is null)
                {
                    return ResponseModel<bool>.Fail(Messages.NoDataFound, 404);
                }

                categoryDb.SlugUrl = UrlSeoOperation.UrlSeo(model?.CategoryLanguages?[0].Title!);


                categoryDb.CategoryLanguages = model?.CategoryLanguages!.Select(x => new CategoryLanguage
                {
                    CategoryId = x.CategoryId,
                    Language_Code = x.Language_Code,
                    Title = x.Title,
                    SeoDesc = x.SeoDesc,
                    SeoKey = x.SeoKey,
                    SeoTitle = x.SeoTitle,
                }).ToList();


                context.Categories.Update(categoryDb);

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
                var entity = await context
                    .Categories
                    .Include(x => x.CategoryLanguages)
                    .FirstOrDefaultAsync(x => x.Id == id);

                if (entity == null)
                    return ResponseModel<bool>.Fail(Messages.NoDataFound, 400);

                 context.Categories.Remove(entity);

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
