using Application.Services;
using Domain.Dtos.About;
using Microsoft.AspNetCore.Mvc;

namespace WebApp.Areas.CMS.Controllers
{
    [Area("CMS")]
    //[Authorize]
    public class AboutController(IAboutService aboutService) : Controller
    {
        public async Task<IActionResult> Index()
        {
            var resposne = await aboutService.GetAllAsync();

            return View(resposne.Data);
        }


        public IActionResult Create()
        {
            return View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(CreateAboutDto createAboutDto)
        {
            var resposne = await aboutService.CreateAsync(createAboutDto);

            if(resposne.IsSuccess)
            {
                TempData["success"] = resposne.Message;

                return RedirectToAction("index");
            }

            return View(createAboutDto);
        }


        public async Task<IActionResult> Update(string id)
        {
            var result = await aboutService.GetByIdAsync(id);

            if (result.IsSuccess)
            {
                TempData["success"] = result.Message;

                return View(result.Data);
            }

            TempData["error"] = result.Message;

            return RedirectToAction(nameof(Index));
        }



        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Update(UpdateAboutDto updateAboutDto)
        {
            var response = await aboutService.UpdateAsync(updateAboutDto);
            if (response.IsSuccess)
            {
                TempData["success"] = response.Message;

                return RedirectToAction(nameof(Index));
            }

            TempData["error"] = response.Message;

            return View(updateAboutDto);
        }



        public async Task<IActionResult> Delete(string id)
        {
            var result = await aboutService.DeleteAsync(id);

            if (result.IsSuccess)
            {
                TempData["success"] = result.Message;

                return RedirectToAction(nameof(Index));
            }

               TempData["error"] = result.Message;
            return RedirectToAction(nameof(Index));
        }


    }
}
