using Application.Helpers;
using Application.Services;
using Domain.Dtos.User;
using Domain.Entities;
using Microsoft.AspNetCore.Identity;
using NeyeyekApp.Domain.Dtos.User;

namespace Infrastructure.Services
{
    public class UserService(UserManager<User> userManager, SignInManager<User> signInManager) : IUserService
    {
        public async Task<ResponseModel<UpdateUserDto>> GetByIdAsync(string id)
        {

            var user = await userManager.FindByIdAsync(id);
            if (user == null)
            {
                return ResponseModel<UpdateUserDto>.Fail("User not found.", 404);
            }

            var updateUserDto = new UpdateUserDto
            {
                Id = user.Id,
                UserName = user.UserName,
                Email = user.Email,
                Name = user.Name,
                Surname = user.Surname,
                PhoneNumber = user.PhoneNumber,
                Birthday = user.Birthday,
            };

            return ResponseModel<UpdateUserDto>.Success(updateUserDto, 200);
        }



        public async Task<ResponseModel<UserProfilDto>> GetUserProfil(string id)
        {
            var user = await userManager.FindByIdAsync(id);

            if (user == null)
            {
                return ResponseModel<UserProfilDto>.Fail("User not found.", 404);
            }


            var updateUserProfil = new UserProfilDto
            {
                Id = user.Id,
                UserName = user.UserName,
                Email = user.Email,
                Name = user.Name,
                Surname = user.Surname,
                PhoneNumber = user.PhoneNumber,
                Birthday = user.Birthday,
            };

            return ResponseModel<UserProfilDto>.Success(updateUserProfil, 200);
        }


        public async Task<ResponseModel<bool>> RegisterUserAsync(RegisterUserDto model)
        {
            var existingUser = await userManager.FindByEmailAsync(model.Email!);
            if (existingUser != null)
            {
                return ResponseModel<bool>.Fail(new List<string> { "Bu e-mail artıq istifadə olunur." }, 400);
            }

            var user = new User
            {
                UserName = string.IsNullOrEmpty(model.UserName) ? model.Email : model.UserName,
                Email = model.Email,
                Name = model.Name,
                Surname = model.Surname,
                PhoneNumber = model.PhoneNumber,
            };

            var result = await userManager.CreateAsync(user, model.Password!);
            if (!result.Succeeded)
            {
                var errors = result.Errors.Select(e => e.Description).ToList();
                return ResponseModel<bool>.Fail(errors, 400);
            }

            return ResponseModel<bool>.Success(true, 200);
        }


        public async Task<ResponseModel<bool>> LoginUserAsync(LoginUserDto model)
        {
            var user = await userManager.FindByEmailAsync(model.Email!);

            if (user == null)
            {
                return ResponseModel<bool>.Fail("Email veya şifre yanlış.", 400);
            }

            var result = await signInManager.PasswordSignInAsync(user.UserName!, model.Password!, isPersistent: false, lockoutOnFailure: false);

            if (result.Succeeded)
            {
                return ResponseModel<bool>.Success(true, 200);
            }

            if (result.IsLockedOut)
            {
                return ResponseModel<bool>.Fail("Hesabınız kilitlenmiş. Xais olunur daha sonra tekrar yoxlayin.", 403);
            }

            if (result.RequiresTwoFactor)
            {
                return ResponseModel<bool>.Fail("Iki faktorlu autentifikasiya tələb edir.", 401);
            }

            if (result.IsNotAllowed)
            {
                return ResponseModel<bool>.Fail("Girişe izin verilmir. Zəhmət olmasa e-poçt ünvanınızı və ya telefon nömrənizi yoxlayın.", 401);
            }

            return ResponseModel<bool>.Fail("Giriş Ugursuz.Zəhmət olmasa məlumatınızı yoxlayın və yenidən cəhd edin.", 400);
        }


        public async Task<ResponseModel<bool>> ChangePasswordAsync(string userId, string oldPassword, string newPassword)
        {
            var user = await userManager.FindByIdAsync(userId);
            if (user == null)
            {
                return ResponseModel<bool>.Fail("Istifadeci tapilmadi.", 404);
            }

            var checkPasswordResult = await userManager.CheckPasswordAsync(user, oldPassword);
            if (!checkPasswordResult)
            {
                return ResponseModel<bool>.Fail("Eski şifre yanlış", 400);
            }

            var result = await userManager.ChangePasswordAsync(user, oldPassword, newPassword);

            if (!result.Succeeded)
            {
                return ResponseModel<bool>.Fail(result.Errors.FirstOrDefault()?.Description ?? "Şifre değişikliği ugursuz oldu.", 400);
            }

            return ResponseModel<bool>.Success(true, 200);
        }


    }
}
