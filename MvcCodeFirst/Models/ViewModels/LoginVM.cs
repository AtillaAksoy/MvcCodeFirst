using System.ComponentModel.DataAnnotations;

namespace MvcCodeFirst.Models.ViewModels
{
    public class LoginVM
    {
        [Required(ErrorMessage = "Email boş geçilemez!")]
        [Display(Name = "Eposta")]
        [EmailAddress(ErrorMessage = "Lütfen eposta formatında değer girin.")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Şifre boş geçilemez!")]
        [Display(Name = "Şifre")]
        public string Password { get; set; }
    }
}
