using Application.Services;
using Domain.Dtos.Event;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace WebApp.Areas.CMS.Controllers
{
    [Area("CMS")]
    //[Authorize]
    public class EventController(IEventService eventService,
        ISpeakerService speakerService,
        ICategoryService categoryService) : Controller
    {

        public async Task<IActionResult> Index()
        {
            var resposne = await eventService.GetAllAsync();

            return View(resposne.Data);
        }


        public async Task<IActionResult> Create()
        {

            var speaker = await speakerService.GetAllAsync();

            ViewData["Speakers"] = new SelectList(speaker.Data, "Id", "FullName");


            var category = await categoryService.GetAllAsync();

            ViewData["Categories"] = new SelectList(category.Data, "Id", "Title");

            return View();
        }



        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(CreateEventDto createEventDto, IFormFile file, IFormFile partnerLogo)
        {
            var response = await eventService.CreateAsync(createEventDto, file, partnerLogo);

            if (response.IsSuccess)
            {
                TempData["success"] = response.Message; 
                return RedirectToAction(nameof(Index));
            }

            var speaker = await speakerService.GetAllAsync();

            ViewData["Speakers"] = new SelectList(speaker.Data, "Id", "FullName");

            var category = await categoryService.GetAllAsync();

            ViewData["Categories"] = new SelectList(category.Data, "Id", "Title");

            TempData["error"] = response.Message; 
            return View(createEventDto);
        }



        public async Task<IActionResult> Update(string id)
        {
            var result = await eventService.GetByIdAsync(id); 

            if (result.IsSuccess)
            {
                var speaker = await speakerService.GetAllAsync();

                var category = await categoryService.GetAllAsync();

            

                ViewData["Speakers"] = new SelectList(speaker.Data, "Id", "FullName");

                ViewData["Categories"] = new SelectList(category.Data, "Id", "Title");

                return View(result.Data); 
            }

            TempData["error"] = result.Message;

            return RedirectToAction(nameof(Index));
        }




        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Update(UpdateEvenetDto eventDto, IFormFile file, IFormFile partnerLogo)
        {
            var response = await eventService.UpdateAsync(eventDto, file, partnerLogo); 
            if (response.IsSuccess)
            {
                TempData["success"] = response.Message;

                return RedirectToAction(nameof(Index));
            }

            var speaker = await speakerService.GetAllAsync(); 

            ViewData["Speakers"] = new SelectList(speaker.Data, "Id", "FullName");

            var category = await categoryService.GetAllAsync();

            ViewData["Categories"] = new SelectList(category.Data, "Id", "Title");

            TempData["error"] = response.Message; 

            return View(eventDto);
        }



        public async Task<IActionResult> Delete(string id)
        {
            var result = await eventService.DeleteAsync(id);

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
