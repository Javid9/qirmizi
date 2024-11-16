using Application.Context;
using Application.Helpers;
using Application.Services;
using Domain.Constants;
using Domain.Dtos.Language;
using Domain.Entities;
using Mapster;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Services
{
    public class LanguageService(IDatabaseContext _context) : ILanguageService
    {

		public async Task<ResponseModel<bool>> CreateLanguageAsync(CreateLanguage createLanguage)
		{
			try
			{
				var entity = createLanguage.Adapt<Language>();
				await _context.Languages.AddAsync(entity);
				await _context.SaveChangesAsync();
				return ResponseModel<bool>.Success(true, 200);

			}
			catch (Exception e)
			{

				return ResponseModel<bool>.Fail(e.Message, 400);
			}
		}


		public async Task<ResponseModel<bool>> DeleteLanguageAsync(string id)
		{
			try
			{
                var entity = await _context.Languages.FirstOrDefaultAsync(x => x.Id == id);
				if (entity == null)
					return ResponseModel<bool>.Fail(Messages.NoDataFound, 400);

				_context.Languages.Remove(entity);
				await _context.SaveChangesAsync();
				return ResponseModel<bool>.Success(true, 200);
            }
			catch (Exception e)
			{
				return ResponseModel<bool>.Fail(e.Message, 400);
			}
		}



		public async  Task<ResponseModel<List<LanguageDto>>> GetAllLangAsync()
		{
			var entities = await _context.Languages.Select(x =>
			new LanguageDto()
			{
				Id = x.Id.ToString(),
				Name = x.Name,
				Code = x.Code,
			}).OrderBy(x=>x.Code).ToListAsync();

			return ResponseModel<List<LanguageDto>>.Success(entities, 200);
		}


        public async Task<ResponseModel<LanguageDto>> GetLangAsync(string id)
        {
			var entity = await _context.Languages.FirstOrDefaultAsync(x => x.Id == id);
            if (entity == null)
                return ResponseModel<LanguageDto>.Fail(Messages.NoDataFound, 400);
            var result = entity.Adapt<LanguageDto>();
            return ResponseModel<LanguageDto>.Success(result, 200);
        }


        public async Task<ResponseModel<bool>> UpdateLanguageAsync(LanguageDto model)
        {
            try
            {
                var entity = model.Adapt<Language>();
                _context.Languages.Update(entity);
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
