using Application.Services;
using Domain.Dtos.Category;
using Microsoft.AspNetCore.Mvc;

namespace WebApp.Areas.CMS.Controllers
{
    [Area("CMS")]
    //[Authorize]
    public class CategoryController(ICategoryService categoryService) : Controller
    {
        public async Task<IActionResult> Index()
        {
            var response = await categoryService.GetAllAsync();

            return View(response.Data);
        }

        public IActionResult Create()
        {
            return View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(CreateCategoryDto createDto)
        {
            var response = await categoryService.CreateAsync(createDto);
            if (response.IsSuccess)
            {
                TempData["success"] = response.Message;
                return RedirectToAction(nameof(Index));
            }
            return View(createDto);
        }


        public async Task<IActionResult> Update(string id)
        {
            var result = await categoryService.GetByIdAsync(id);

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
        public async Task<IActionResult> Update(UpdateCategoryDto updateDto)
        {
            var response = await categoryService.UpdateAsync(updateDto);
            if (response.IsSuccess)
            {
                TempData["success"] = response.Message;
                return RedirectToAction(nameof(Index));
            }

            TempData["error"] = response.Message;
            return View(updateDto);
        }


        public async Task<IActionResult> Delete(string id)
        {
            var result = await categoryService.DeleteAsync(id);
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
