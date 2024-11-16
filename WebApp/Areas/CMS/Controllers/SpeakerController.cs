using Application.Services;
using Domain.Dtos.Speaker;
using Microsoft.AspNetCore.Mvc;

namespace WebApp.Areas.CMS.Controllers
{
    [Area("CMS")]
    //[Authorize]
    public class SpeakerController(ISpeakerService speakerService) : Controller
    {

        public async Task<IActionResult> Index()
        {
            var resposne = await speakerService.GetAllAsync();
            return View(resposne.Data);
        }

        public IActionResult Create()
        {
            return View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(CreateSpeakerDto speakerDto, IFormFile file)
        {
            var response = await speakerService.CreateAsync(speakerDto, file);
            if (response.IsSuccess)
            {
                TempData["success"] = response.Message;
                return RedirectToAction(nameof(Index));
            }
            return View(speakerDto);
        }



        public async Task<IActionResult> Update(string id)
        {
            var result = await speakerService.GetByIdAsync(id);

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
        public async Task<IActionResult> Update(UpdateSpeakerDto speakerDto, IFormFile file)
        {
            var response = await speakerService.UpdateAsync(speakerDto, file);
            if (response.IsSuccess)
            {
                TempData["success"] = response.Message;
                return RedirectToAction(nameof(Index));
            }

            TempData["error"] = response.Message;

            return View(speakerDto);
        }



        public async Task<IActionResult> Delete(string id)
        {
            var result = await speakerService.DeleteAsync(id);
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
