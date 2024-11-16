using Application.Helpers;
using Domain.Dtos.User;
using NeyeyekApp.Domain.Dtos.User;

namespace Application.Services
{
    public interface IUserService
    {
        Task<ResponseModel<UserProfilDto>> GetUserProfil(string id);
        Task<ResponseModel<UpdateUserDto>> GetByIdAsync(string id);
        Task<ResponseModel<bool>> ChangePasswordAsync(string userId, string oldPassword, string newPassword);
        Task<ResponseModel<bool>> RegisterUserAsync(RegisterUserDto model);
        Task<ResponseModel<bool>> LoginUserAsync(LoginUserDto model);

    }
}
