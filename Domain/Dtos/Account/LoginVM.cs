using System.ComponentModel.DataAnnotations;

namespace Domain.Dtos.Account
{
    public class LoginVM
    {
        [Required(ErrorMessage = "Doldurulmalıdır"), RegularExpression(@"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$", ErrorMessage = "Düzgün email daxil edin")]
        public string? Email { get; set; }
        [Required(ErrorMessage = "Doldurulmalıdır"), RegularExpression(@"(?=^.{8,}$)((?=.*\d)|(?=.*\W+))(?![.\n])(?=.*[A-Z])(?=.*[a-z]).*$", ErrorMessage = "Düzgün şifrə daxil edin"), DataType(DataType.Password)]
        public string? Password { get; set; }
        public bool RememberMe { get; set; }
    }
}
