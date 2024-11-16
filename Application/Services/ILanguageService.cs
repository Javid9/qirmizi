using Application.Helpers;
using Domain.Dtos.Language;

namespace Application.Services
{
    public interface ILanguageService
    {
        Task<ResponseModel<List<LanguageDto>>> GetAllLangAsync();
        Task<ResponseModel<LanguageDto>> GetLangAsync(string id);
        Task<ResponseModel<bool>> CreateLanguageAsync(CreateLanguage language);
        Task<ResponseModel<bool>> UpdateLanguageAsync(LanguageDto model);
        Task<ResponseModel<bool>> DeleteLanguageAsync(string id);

    }
}
