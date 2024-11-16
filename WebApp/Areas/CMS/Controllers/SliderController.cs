using Application.Services;
using Domain.Dtos.Slider;
using Microsoft.AspNetCore.Mvc;

namespace WebApp.Areas.CMS.Controllers
{
    [Area("CMS")]
    //[Authorize]
    public class SliderController(ISliderService sliderService) : Controller
    {
        public async Task<IActionResult> Index()
        {
            var resposne = await sliderService.GetAllAsync();
            return View(resposne.Data);
        }

        public IActionResult Create()
        {
            return View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(CreateSliderDto sliderDto, IFormFile file)
        {
            var response = await sliderService.CreateAsync(sliderDto, file);
            if (response.IsSuccess)
            {
                TempData["success"] = response.Message;
                return RedirectToAction(nameof(Index));
            }
            return View(sliderDto);
        }


        public async Task<IActionResult> Update(string id)
        {
            var result = await sliderService.GetByIdAsync(id);

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
        public async Task<IActionResult> Update(UpdateSliderDto sliderDto, IFormFile file)
        {
            var response = await sliderService.UpdateAsync(sliderDto, file);
            if (response.IsSuccess)
            {
                TempData["success"] = response.Message;
                return RedirectToAction(nameof(Index));
            }

            TempData["error"] = response.Message;
            return View(sliderDto);

        }


        public async Task<IActionResult> Delete(string id)
        {
            var result = await sliderService.DeleteAsync(id);
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
