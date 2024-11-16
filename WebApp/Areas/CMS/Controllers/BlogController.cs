using Application.Services;
using Domain.Dtos.Blog;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace WebApp.Areas.CMS.Controllers
{
    [Area("CMS")]
    //[Authorize]
    public class BlogController(IBlogService blogService, ICategoryService categoryService) : Controller
    {
        public async Task<IActionResult> Index()
        {
            var response = await blogService.GetAllAsync();

            return View(response.Data);
        }


        public async Task<IActionResult> Create()
        {
            var category = await categoryService.GetAllAsync();

            ViewData["Categories"] = new SelectList(category.Data, "Id", "Title");


            return View();
        }



        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(CreateBlogDto blogDto, IFormFile file)
        {
            var response = await blogService.CreateAsync(blogDto, file);
            if (response.IsSuccess)
            {
                TempData["success"] = response.Message;
                return RedirectToAction(nameof(Index));
            }

            var category = await categoryService.GetAllAsync();

            ViewData["Categories"] = new SelectList(category.Data, "Id", "Title");

            return View(blogDto);
        }



        public async Task<IActionResult> Update(string id)
        {

            var result = await blogService.GetByIdAsync(id);

            if (result.IsSuccess)
            {
                TempData["success"] = result.Message;

                var category = await categoryService.GetAllAsync();

                ViewData["Categories"] = new SelectList(category.Data, "Id", "Title");

                return View(result.Data);
            }

            TempData["error"] = result.Message;

            return RedirectToAction(nameof(Index));
        }



        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Update(UpdateBlogDto blogDto, IFormFile file)
        {
            var response = await blogService.UpdateAsync(blogDto, file);
            if (response.IsSuccess)
            {
                TempData["success"] = response.Message;
                return RedirectToAction(nameof(Index));
            }

            var category = await categoryService.GetAllAsync();

            ViewData["Categories"] = new SelectList(category.Data, "Id", "Title");

            TempData["error"] = response.Message;

            return View(blogDto);
        }


        public async Task<IActionResult> Delete(string id)
        {
            var result = await blogService.DeleteAsync(id);

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
