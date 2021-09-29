using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebUI.Models.ViewModels
{
    public class RegisterVM
    {
        [Required(ErrorMessage = "kullanıcı adı boş geçilemez!")]
        [Display(Name = "Kullanıcı adı")]
        public string UserName { get; set; }

        [Required(ErrorMessage = "email boş geçilemez!")]
        [Display(Name = "Eposta")]
        public string Email { get; set; }

        [Required(ErrorMessage = "şifre boş geçilemez!")]
        [Display(Name = "Şifre")]
        public string Password { get; set; }

        [Required(ErrorMessage = "şifre(tekrar) boş geçilemez!")]
        [Display(Name = "Şifre(Tekrar)")]
        [Compare("Password", ErrorMessage = "şifreler uyuşmuyor.")]
        public string ConfirmPassword { get; set; }
    }
}
