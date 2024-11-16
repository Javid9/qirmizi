using Application.Services;
using Domain.Dtos.Photo;
using Domain.Entities;
using Infrastructure.Services;
using Microsoft.AspNetCore.Mvc;
using WebApp.Models;

namespace WebApp.Controllers
{
    public class AboutsController(IAboutService aboutService, IPhotoService photoService) : Controller
    {
        [Route("/{lang}/haqqimizda")]
        public async Task<IActionResult> Index(string lang = "az")
        {
            ViewBag.Lang = HttpContext.Session.GetString("lang") ?? lang;

            var blogs = await aboutService.GetClientAllAsync(lang);

            var getBlog = await aboutService.GetByIdAsync(blogs?.Data?.FirstOrDefault()?.Id!);

            var photos = await photoService.GetAllAsync(getBlog.Data.Id);

            return View( new AboutVM
            {
                AboutClients = blogs?.Data,
                Photos = photos.Data
            });
        }








    }




    }
