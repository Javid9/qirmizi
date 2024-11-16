using Application.Services;
using Domain.Dtos.Photo;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace WebApp.Areas.CMS.Controllers
{
    [Area("CMS")]
    //[Authorize]
    public class PhotoController(IPhotoService _photoService) : Controller
    {

        [Route("/cms/resimler/{productId}")]
        public async Task<IActionResult> Index(string? productId)
        {
            var result = await _photoService.GetAllAsync(productId);

            PhotoVM model = new()
            {
                Photo = new(),
                Photos = result.Data
            };

            ViewBag.ProductId = productId;
           
            return View(model);
        }


        [HttpPost]
        [Route("/cms/resimler/ekle")]
        public async Task<IActionResult> Create(PhotoVM model, IFormFileCollection files)
        {
            await _photoService.CreateAsync(model.Photo!, files);
            return RedirectToAction(nameof(Index), new {productId = model?.Photo?.ProductId });
        }


        [HttpPost]
        [Route("/cms/resimler/sil/")]
        public async Task<IActionResult> Delete(string id)
        {
            await _photoService.Delete(id);
            return Ok();
        }



    }






}
