using Domain.Common;

namespace Domain.Entities;

public class AppUser : BaseEntity
{
    public string? FullName { get; set; } 
    public string? Email { get; set; }
    public string? PasswordHash { get; set; }
    public string? SecretKey { get; set; } = Guid.NewGuid().ToString().Replace("-", "") + DateTime.Now.ToString().Replace("-", "").Replace(" ", "").Replace(":", "");
    public string? Role { get; set; }

}
