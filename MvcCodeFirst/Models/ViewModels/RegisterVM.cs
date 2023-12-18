using MvcCodeFirst.Models.Entities.Enums;
using System.ComponentModel.DataAnnotations;

namespace MvcCodeFirst.Models.ViewModels
{
    public class RegisterVM
    {
        [Required(ErrorMessage = "Kullanıcı adı boş geçilemez!")]
        [Display(Name = "Kullanıcı Adı")]
        public string? Username { get; set; }

        [Required(ErrorMessage = "Email boş geçilemez!")]
        [Display(Name = "Eposta")]
        [EmailAddress(ErrorMessage = "Lütfen eposta formatında değer girin.")]
        public string Email { get; set; }

        [Display(Name = "Ad")]
        public string? Firstname { get; set; }

        [Display(Name = "Soyad")]
        public string? Lastname { get; set; }

        [Required(ErrorMessage = "Şifre boş geçilemez!")]
        [Display(Name = "Şifre")]
        public string Password { get; set; }

        [Display(Name = "Cinsiyet")]
        public Gender Gender { get; set; }

        [Required(ErrorMessage = "Şifre(Tekrar) boş geçilemez!")]
        [Display(Name = "Şifre (Tekrar)")]
        [Compare("Password", ErrorMessage = "Şifreler uyuşmuyor")]
        public string ConfirmPassword { get; set; }
    }
}
