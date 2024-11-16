using Application.Context;
using Application.Helpers;
using Application.Services;
using Domain.Constants;
using Domain.Dtos.Blog;
using Domain.Dtos.Category;
using Domain.Entities;
using Domain.Entities.Languages;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using System.Globalization;

namespace Infrastructure.Services
{
    public class BlogService(IDatabaseContext context, IStorageService storageService) : IBlogService
    {
        public async Task<ResponseModel<List<BlogDto>>> GetAllAsync()
        {
            var blogs = await context.Blogs.Include(x => x.BlogLanguages)
                .AsNoTracking()
                .ToListAsync(); 

            var entity = blogs.Select(x => new BlogDto
            {
                Id = x.Id,
                SlugUrl = x.SlugUrl,
                FileCode = x.FileCode,
                Title = x.BlogLanguages != null && x.BlogLanguages.Any()
                    ? x.BlogLanguages.FirstOrDefault(b => b.Language_Code == "az")?.Title
                    : null
            }).ToList();

            return ResponseModel<List<BlogDto>>.Success(entity, 200);
        }


        public async Task<ResponseModel<List<BlogClientDto>>> GetClientAllAsync(string? lang)
        {
            if (string.IsNullOrEmpty(lang))
            {
                return ResponseModel<List<BlogClientDto>>.Fail("Language parameter is required.", 400);
            }

            var entity = await context.Blogs
                .Include(x => x.BlogLanguages)
                .Include(x => x.Category)
                .Select(x => new BlogClientDto
                {
                    Id = x.Id,
                    SlugUrl = x.SlugUrl,
                    FileCode = x.FileCode,
                    Clock = x.Clock,
                    CreateDate = x.CreateDate!.Value.ToString("dd MMMM yyyy", new CultureInfo("az-Latn-AZ")),
                    Text = x.BlogLanguages!.FirstOrDefault(s => s.Language_Code == lang)!.Text,
                    Title = x.BlogLanguages!.FirstOrDefault(s => s.Language_Code == lang)!.Title,

                    Categories = new List<CategoryDto>
                    {
                        new CategoryDto
                        {
                            Id = x.CategoryId,
                            Title = x.Category!.CategoryLanguages!.FirstOrDefault(c=>c.Language_Code == lang)!.Title
                        }
                    }


                }).ToListAsync();

            return ResponseModel<List<BlogClientDto>>.Success(entity, 200);
        }



        public async Task<ResponseModel<UpdateBlogDto>> GetByIdAsync(string id)
        {
            var entity = await context
                 .Blogs
                 .Include(x => x.BlogLanguages)
                 .Include(x => x.Category)
                 .FirstOrDefaultAsync(x => x.Id == id);

            if (entity == null)
            {
                return ResponseModel<UpdateBlogDto>.Fail(Messages.NoDataFound, 404);
            }

            var model = new UpdateBlogDto
            {
                Id = entity.Id,
                SlugUrl = entity.SlugUrl,
                FileCode = entity.FileCode,
                CreateDate = entity.CreateDate,
                Clock = entity.Clock,
                CategoryId = entity.CategoryId,
                BlogLanguages = entity?.BlogLanguages!.Select(x => new BlogLanguageDto
                {
                    LangId = x.Id,
                    BlogId = x.BlogId,
                    Language_Code = x.Language_Code,
                    Title = x.Title,
                    Text = x.Text,
                    SeoDesc = x.SeoDesc,
                    SeoKey = x.SeoKey,
                    SeoTitle = x.SeoTitle,

                }).ToList(),
            };

            return ResponseModel<UpdateBlogDto>.Success(model, 200);
        }


      
        public async Task<ResponseModel<BlogDetailDto>> GetBySlugUrlAsync(string slugUrl, string lang)
        {
            var entity = await context
                .Blogs
                .Include(x => x.BlogLanguages)
                .Include(x => x.Category)
                .ThenInclude(x => x.CategoryLanguages)
                .FirstOrDefaultAsync(x => x.SlugUrl == slugUrl);

            if (entity == null)
            {
                return ResponseModel<BlogDetailDto>.Fail(Messages.NoDataFound, 404);
            }

            BlogLanguage? blogLanguage = entity.BlogLanguages?.FirstOrDefault(x => x.Language_Code == lang);

            var model = new BlogDetailDto
            {
                Id = entity.Id,
                SlugUrl = entity.SlugUrl,
                FileCode = entity.FileCode,
                CreateDate = entity.CreateDate.HasValue ? entity.CreateDate.Value.ToString("dd MMMM, yyyy", new CultureInfo(lang)) : "",
                Clock = entity.Clock,
                CategoryId = entity.CategoryId,
                Title = blogLanguage?.Title,
                Text = blogLanguage?.Text,
                SeoDesc = blogLanguage?.SeoDesc,
                SeoKey = blogLanguage?.SeoKey,
                SeoTitle = blogLanguage?.SeoTitle,

               
                CategoryDetail = entity.Category != null
                    ? new CategoryDetailDto
                    {
                        Id = entity.Category.Id,
                        Title = entity.Category.CategoryLanguages!.FirstOrDefault(cl => cl.Language_Code == lang)?.Title ?? string.Empty
                    }
                    : null
            };

            return ResponseModel<BlogDetailDto>.Success(model, 200);
        }




        public async Task<ResponseModel<bool>> CreateAsync(CreateBlogDto model, IFormFile file)
        {
            try
            {
                var fileCode = await storageService.UploadAsync(ImageUrl.Blog, file);

                if (!fileCode.IsSuccess)
                {
                    return ResponseModel<bool>.Fail(Messages.NoDataFound, 404);
                }

                var slugUrl = UrlSeoOperation.UrlSeo(model?.BlogLanguages?[0].Title!);

                var entity = new Blog
                {
                    FileCode = fileCode.Data,
                    Clock = model?.Clock,
                    CreateDate = model?.CreateDate,
                    SlugUrl = slugUrl,
                    CategoryId = model?.CategoryId,

                    BlogLanguages = model?.BlogLanguages?.Select(x => new BlogLanguage
                    {
                        Language_Code = x.Language_Code,
                        BlogId = x.BlogId,
                        Title = x.Title,
                        Text = x.Text,
                        SeoDesc = x.SeoDesc,
                        SeoTitle = x.SeoTitle,
                        SeoKey = x.SeoKey,
                    }).ToList()
                };

                await context.Blogs.AddAsync(entity);

                await context.SaveChangesAsync();

                return ResponseModel<bool>.Success(true, 200);
            }
            catch (Exception e)
            {

                return ResponseModel<bool>.Fail(e.Message, 400);
            }
        }



        public async Task<ResponseModel<bool>> UpdateAsync(UpdateBlogDto model, IFormFile file)
        {
            try
            {

                var filePhoto = await storageService.UploadAsync(ImageUrl.Blog, file);


                if (filePhoto.IsSuccess)
                {
                    if (model.FileCode is not null)
                    {
                        storageService.Delete(model.FileCode);
                    }

                    model.FileCode = filePhoto.Data;
                }

                var blogDb = await context.Blogs.Include(x => x.BlogLanguages).FirstOrDefaultAsync(x => x.Id == model.Id);

                if (blogDb is null)
                {
                    return ResponseModel<bool>.Fail(Messages.NoDataFound, 404);
                }

                blogDb.FileCode = model!.FileCode;
                blogDb.CreateDate = model!.CreateDate;
                blogDb.Clock = model.Clock;
                blogDb.CategoryId = model!.CategoryId;
                blogDb.SlugUrl = UrlSeoOperation.UrlSeo(model?.BlogLanguages?[0].Title!);


                blogDb.BlogLanguages = model?.BlogLanguages!.Select(x => new BlogLanguage
                {
                    BlogId = x.BlogId,
                    Language_Code = x.Language_Code,
                    Title = x.Title,
                    Text = x.Text,
                    SeoDesc = x.SeoDesc,
                    SeoKey = x.SeoKey,
                    SeoTitle = x.SeoTitle,
                }).ToList();


                context.Blogs.Update(blogDb);

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
                .Blogs.Include(x => x.BlogLanguages)
                .Include(x => x.Category)
                .FirstOrDefaultAsync(x => x.Id == id);


                if (entity == null)
                {
                    return ResponseModel<bool>.Fail(Messages.NoDataFound, 404);
                }

                if (entity.FileCode is not null)
                {
                    storageService.Delete(entity.FileCode);
                }

                if (entity.BlogLanguages is { Count: > 0 })
                    context.BlogLanguages.RemoveRange(entity.BlogLanguages);



                context.Blogs.Remove(entity);

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
