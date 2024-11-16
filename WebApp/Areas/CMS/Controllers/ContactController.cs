using Application.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace WebApp.Areas.CMS.Controllers
{
    [Area("CMS")]
    //[Authorize]
    public class ContactController(IContactService _contactService) : Controller
    {

        [Route("/cms/kontalar")]
        public async Task<IActionResult> Index()
        {
            var result = await _contactService.GetList();
            return View(result.Data);
        }



        [Route("/cms/detail")]
        public async Task<IActionResult> Detail(string id)
        {
            var result = await _contactService.GetById(id);
            return View(result.Data);
        }


        public async Task<IActionResult> Delete(string id)
        {
            var result = await _contactService.Delete(id);
            if (result.IsSuccess)
            {
                TempData["Success"] = result.Message;
                return RedirectToAction(nameof(Index));
            }
            return NotFound();
        }





    }
}
