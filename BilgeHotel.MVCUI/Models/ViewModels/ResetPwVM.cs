using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BilgeHotel.MVCUI.Models.ViewModels
{
    public class ResetPwVM
    {
        public int ID { get; set; }

        [DataType(DataType.EmailAddress, ErrorMessage = "Lütfen email formatına uygun giriş yapınız!")]
        [Required(ErrorMessage = "Email adresi boş geçilemez!")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Şifre boş geçilemez!")]
        [MinLength(6, ErrorMessage = "Şifre en az 6 karakterli olabilir!")]
        [MaxLength(16, ErrorMessage = "Şifre en çok 16 karakterli olabilir!")]
        public string Password { get; set; }

        [Compare("Password", ErrorMessage = "Şifre tekrarınız uyuşmamaktadır!")]
        [Required(ErrorMessage = "Şifre tekrarı boş geçilemez!")]
        public string PasswordConfirmed { get; set; }
    }
}