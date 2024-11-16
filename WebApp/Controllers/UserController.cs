using Application.Services;
using Domain.Dtos.User;
using Domain.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using NeyeyekApp.Domain.Dtos.User;

namespace WebApp.Controllers
{
    public class UserController(IUserService userService, SignInManager<User> signInManager) : Controller
    {

        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

       
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Register(RegisterUserDto model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var result = await userService.RegisterUserAsync(model);

            if (result.IsSuccess)
            {
                return RedirectToAction(nameof(Login));
            }


            if (result.Errors != null && result.Errors.Any())
            {
                TempData["ErrorMessage"] = string.Join(" ", result.Errors);
            }

            return View(model);
        }


        [HttpGet]
        public IActionResult Login()
        {

            if (User.Identity != null && User.Identity.IsAuthenticated)
            {
                return RedirectToAction("Index", "Home");
            }
            return View();
        }



        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(LoginUserDto model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var result = await userService.LoginUserAsync(model);

            if (result.IsSuccess)
            {
                return RedirectToAction("Index", "Home");
            }

            foreach (var error in result.Errors!)
            {
                ModelState.AddModelError(string.Empty, error);
            }

            return View(model);
        }


        public async Task<IActionResult> Logout()
        {
            await signInManager.SignOutAsync();
            return RedirectToAction("Index", "Home");
        }


    }
}
