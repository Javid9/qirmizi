using Application.Services;
using Domain.Dtos.Language;
using Microsoft.AspNetCore.Mvc;

namespace WebApp.Areas.CMS.Controllers
{
    [Area("CMS")]
    //[Authorize]
    public class LanguageController(ILanguageService _languageService) : Controller
    {
      
        public async Task<IActionResult> Index()
        {
            var result = await _languageService.GetAllLangAsync();
            return View(result.Data);
        }


        public IActionResult Create()
        {
            return View();
        }



        [HttpPost]
        public async Task<IActionResult> Create(CreateLanguage model)
        {
            var result = await _languageService.CreateLanguageAsync(model);
            if (result.IsSuccess)
            {
                TempData["success"] = result.Message;
                return RedirectToAction(nameof(Index));
            }

            return View();
        }



        public async Task<IActionResult> Update(string id)
        {
            var lang = await _languageService.GetLangAsync(id);
            if (lang.Data is not null)
            {
                TempData["success"] = lang.Message;
                return View(lang.Data);
            }
            TempData["Error"] = lang.Message;
            return View();
        }



        [HttpPost]
        public async Task<IActionResult> Update(LanguageDto model)
        {
            var result = await _languageService.UpdateLanguageAsync(model);
            if (result.IsSuccess)
            {
                TempData["success"] = result.Message;
                return RedirectToAction(nameof(Index));
            }
            return View();
        }


        public async Task<IActionResult> Delete(string id)
        {
            var result = await _languageService.DeleteLanguageAsync(id);
            if (result.IsSuccess)
            {
                TempData["success"] = result.Message;
                return RedirectToAction(nameof(Index));
            }
            TempData["Error"] = result.Message;
            return RedirectToAction(nameof(Index));
        }


    }
}
