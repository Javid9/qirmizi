using Application.Helpers;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.CustomMigrations
{
    public static class UserSeed
    {
        public static void Seed(ModelBuilder builder)
        {
            var admin = new AppUser()
            {
                FullName = "Admin",
                Email = "admin@admin.com",
                Role = "admin"
            };
            admin.PasswordHash = HashingHelper.CreatePasswordHashOld("Admin123", admin.SecretKey!);
            builder.Entity<AppUser>().HasData(admin);
        }


    }
}
