using Application.Services;
using Domain.Dtos.Contact;
using Microsoft.AspNetCore.Mvc;

namespace WebApp.Controllers;

public class ContactController(IContactService contactService) : Controller
{
    [Route("/{lang}/əlaqe")]
    public IActionResult Index(string lang = "az")
    {
        ViewBag.Lang = HttpContext.Session.GetString("lang") ?? lang;
        return View();
    }


    [HttpPost, ValidateAntiForgeryToken]
    public async Task<IActionResult> SendMessage(CreateContact model, string lang = "az")
    {
        ViewBag.Lang = HttpContext.Session.GetString(lang) ?? lang;

        var result = await contactService.WriteToUsMessage(model);

        if (result.IsSuccess)
        {
            TempData["Success"] = "Mesajınız uğurla göndərildi";
        }
        else
        {
            TempData["Error"] = "Əməliyyat zamanı xəta baş verdi";
        }

        return RedirectToAction("Index", "Contact", new { lang });

    }


}
