﻿namespace NeyeyekApp.Domain.Dtos.User
{
    public class ChangePasswordDto
    {
        public string? UserId { get; set; }
        public string? OldPassword { get; set; }
        public string? NewPassword { get; set; }
        public string? ConfirmNewPassword { get; set; }
    }
}
