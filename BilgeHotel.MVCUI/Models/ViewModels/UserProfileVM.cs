using BilgeHotel.ENTITY.Enum;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BilgeHotel.MVCUI.Models.ViewModels
{
    public class UserProfileVM
    {
        public int UserProfileID { get; set; }


        [Required(ErrorMessage = "Kullanıcı Adı boş geçilemez!")]
        [MaxLength(16, ErrorMessage = "En çok 16 karakter girebilirsiniz!")]
        [MinLength(3, ErrorMessage = "En az 3 karakter girmelisiniz!")]
        public string UserName { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public UserRole Role { get; set; }
    }
}