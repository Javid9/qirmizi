using Application.Services;
using Microsoft.AspNetCore.Mvc;
using WebApp.Models;

namespace WebApp.Controllers
{
    public class HomeController(ISliderService sliderService,
        ISpeakerService speakerService, IEventService eventService) : Controller
    {
        [Route("/")]
        [Route("/{lang}")]
        [Route("/{lang}/anasehife")]
        public async Task<IActionResult> Index(string lang = "az")
        {
            ViewBag.Lang = HttpContext.Session.GetString("lang") ?? lang;


            var slider = await sliderService.GetClientAllAsync(lang);

            var speakers = await speakerService.GetClientAllAsync(lang);

            var events = await eventService.GetClientAllAsync(lang);


            return View( new HomeVm
            {
                SliderClients = slider.Data,
                SpeakerClients = speakers.Data,
                EventClinets = events.Data
            });
        }

    }
}
