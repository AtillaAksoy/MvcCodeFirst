using System.ComponentModel.DataAnnotations;

namespace MvcCodeFirst.Models.ViewModels
{
    public class ForgotPasswordVM
    {
        [Required(ErrorMessage = "Email boş geçilemez!")]
        [Display(Name = "Eposta")]
        [EmailAddress(ErrorMessage = "Lütfen eposta formatında değer girin.")]
        public string Email { get; set; }
    }
}
