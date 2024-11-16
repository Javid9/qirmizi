using Application.Services;
using Domain.Dtos.AppConfig;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace WebApp.Areas.CMS.Controllers
{
    [Area("CMS")]
    //[Authorize]
    public class AppConfigController(IAppConfigService _appConfigService) : Controller
    {

        [Route("/cms/appconfig")]
        public async Task<IActionResult> Index()
        {
            var response = await _appConfigService.GetAllAsync();
            if (response.Data != null)
                return View(response.Data);

            TempData["error"] = response.Message;
            return View();
        }



        [Route("/cms/appconfig/yarat")]
        public IActionResult Create()
        {
            return View();
        }


        [Route("/cms/appconfig/yarat")]
        [HttpPost]
        public async Task<IActionResult> Create(AppConfigDto appConfigDto, IFormFile logoFile)
        {
            var response = await _appConfigService.CreateAsync(appConfigDto, logoFile);
            if (response.IsSuccess)
            {
                TempData["success"] = response.Message;
                return RedirectToAction(nameof(Index));
            }
            TempData["error"] = response.Message;
            return View(appConfigDto);
        }



        [Route("/cms/appconfig/update")]
        public async Task<IActionResult> Update(string id)
        {
            var result = await _appConfigService.GetByIdAsync(id);
            if (result.IsSuccess)
            {
                TempData["success"] = result.Message;
                return View(result.Data);
            }
            TempData["error"] = result.Message;
            return View();

        }



        [Route("/cms/appconfig/update")]
        [HttpPost]
        public async Task<IActionResult> Update(AppConfigDto appConfigDto, IFormFile logoFile)
        {
            var response = await _appConfigService.UpdateAsync(appConfigDto, logoFile);
            if (response.IsSuccess)
            {
                TempData["success"] = response.Message;
                return RedirectToAction(nameof(Index));
            }
            TempData["error"] = response.Message;
            return View();
        }



        public async Task<IActionResult> Delete(string id)
        {
            var result = await _appConfigService.DeleteAsync(id);
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
