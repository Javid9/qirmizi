using Application.Services;
using Microsoft.AspNetCore.Mvc;

namespace WebApp.Controllers;

public class SpeakerController(ISpeakerService speakerService) : Controller
{
    [Route("/{lang}/spikerlər")]
    public async Task<IActionResult> Index(string lang = "az")
    {
        ViewBag.Lang = HttpContext.Session.GetString("lang") ?? lang;

        var speakers = await speakerService.GetClientAllAsync(lang);

        return View(speakers.Data);
    }


    [HttpGet]
    [Route("/{lang}/spikerler/ara")]
    public async Task<IActionResult> Search(string query, string lang)
    {
        if (string.IsNullOrEmpty(query))
        {
            var speakers = await speakerService.GetClientAllAsync(lang);
            return PartialView(speakers.Data);
        }

        var response = await speakerService.SearchSpeakersAsync(query, lang);

        return response.IsSuccess ? PartialView(response.Data) : PartialView();
    }
}