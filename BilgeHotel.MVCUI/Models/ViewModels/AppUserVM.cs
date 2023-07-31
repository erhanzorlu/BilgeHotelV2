using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BilgeHotel.MVCUI.Models.ViewModels
{
    public class AppUserVM
    {
        public int AppUserID { get; set; }

        [Required(ErrorMessage = "TC.Kimlik Numarası boş geçilemez!")]
        [RegularExpression(@"^\d{11}$", ErrorMessage = "Geçerli bir TC kimlik numarası girin")]
        public string IdentificationNumber { get; set; }

        [Required(ErrorMessage = "Ad boş geçilemez!")]
        [MinLength(2, ErrorMessage = "En az 3 karakter girmelisiniz!")]
        [MaxLength(25, ErrorMessage = "En çok 25 karakter girebilirsiniz!")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Soyad boş geçilemez!")]
        [MinLength(2, ErrorMessage = "En az 3 karakter girmelisiniz!")]
        [MaxLength(25, ErrorMessage = "En çok 25 karakter girebilirsiniz!")]
        public string LastName { get; set; }
        public string PhoneNumber { get; set; }
    }
}