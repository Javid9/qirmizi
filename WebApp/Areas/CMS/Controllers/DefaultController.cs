using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Web.Areas.Cms.Controllers;

[Area("Cms")]
//[Authorize]
public class DefaultController : Controller
{
  
    [Route("/cms/default")]
    [Route("/cms")]
    public IActionResult Index()
    {
        return View();
    }
}