using Application.Services;
using Infrastructure.Services;
using Microsoft.AspNetCore.Mvc;
using WebApp.Models;

namespace WebApp.Controllers
{
    public class EventController(IEventService eventService, IPhotoService photoService) : Controller
    {

        [Route("/{lang}/tədbirlər")]
        public async Task<IActionResult> Index(string lang = "az")
        {
            ViewBag.Lang = HttpContext.Session.GetString("lang") ?? lang;

            var evnt = await eventService.GetClientAllAsync(lang);

            return View(evnt.Data);
        }



        [Route("/{lang}/tədbir/{slugUrl}")]
        public async Task<IActionResult> Detail(string slugUrl, string lang = "az")
        {
            ViewBag.Lang = HttpContext.Session.GetString("lang") ?? lang;

            var getEvent = await eventService.GetBySlugUrlAsync(slugUrl, lang);
            
            var photos = await photoService.GetAllAsync(getEvent.Data.Id);

            return View(new EventVM
            {
                GetEvent = getEvent.Data,
                Photos = photos.Data
            });
           
        }

    }
}
