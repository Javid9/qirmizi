using Application.Services;
using Domain.Dtos.Speaker;
using Infrastructure.Services;
using Microsoft.AspNetCore.Mvc;

namespace WebApp.Controllers
{
    public class SpeakerController(ISpeakerService speakerService) : Controller
    {
        [Route("/{lang}/spikerlər")]
        public async Task<IActionResult> Index(string lang = "az")
        {
            ViewBag.Lang = HttpContext.Session.GetString("lang") ?? lang;

            var speakers = await speakerService.GetClientAllAsync(lang);

            return View(speakers.Data);
        }


        //[HttpGet]
        //[Route("/{lang}/spikerler/ara")]
        //public async Task<IActionResult> Search(string query, string lang = "az")
        //{
        //    ViewBag.Lang = HttpContext.Session.GetString("lang") ?? lang;


        //    if (string.IsNullOrEmpty(query))
        //    {
        //        return View("Index", new List<SpeakerClientDto>());
        //    }

        //    var response = await speakerService.SearchSpeakersAsync(query, lang);

        //    return View("Index", response.Data);
        //}



        [HttpGet]
        [Route("/{lang}/spikerler/ara")]
        public async Task<IActionResult> Search(string query, string lang = "az")
        {
             //if (string.IsNullOrEmpty(query))
             //   {
             //       return BadRequest("Search query is required");
             //   }

             //   var response = await speakerService.SearchSpeakersAsync(query, lang);

             //   if (response == null)
             //   {
             //       return NotFound("No speakers found");
             //   }

             //   return Ok(response.Data);

            return Ok(new
            {
                data = new List<SpeakerClientDto>
                {
                    new SpeakerClientDto
                    {
                        Id = "1",
                        FileCode = "1",
                        Instagram = "instagram",
                        Facebook = "facebook",
                        Twitter = "twitter",
                        LinkedIn = "linkedin",
                        FullName = "Full Name",
                        Postion = "Position",
                        Text = "Text",
                        Title = "Title"
                    }
                }
            });
            

        }



    }
}
