using Application.Services;
using Infrastructure.Services;
using Microsoft.AspNetCore.Mvc;
using WebApp.Models;

namespace WebApp.Controllers
{
    public class BlogController(IBlogService blogService) : Controller
    {
        [Route("/{lang}/bloglar")]
        public async Task<IActionResult> Index(string lang = "az")
        {
            ViewBag.Lang = HttpContext.Session.GetString("lang") ?? lang;

            var blog = await blogService.GetClientAllAsync(lang);

            return View(blog.Data);
        }


        [Route("/{lang}/blog/{slugUrl}")]
        public async Task<IActionResult> Detail(string slugUrl, string lang = "az")
        {
            ViewBag.Lang = HttpContext.Session.GetString("lang") ?? lang;

            var blogList = await blogService.GetClientAllAsync(lang);

            var getBlog = await blogService.GetBySlugUrlAsync(slugUrl, lang);


            return View(new BlogVM
            {
                GetBlog = getBlog.Data,
                AllBlog = blogList.Data.Where(x => x.Id != getBlog?.Data?.Id).ToList()
            });
        }




    }
}
