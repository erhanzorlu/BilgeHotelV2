using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BilgeHotel.MVCUI.Areas.Management.Data.ViewModels.PureVMs
{
    public class GuestVM
    {
        public int ID { get; set; }
        public int RoomNumber { get; set; }

        [Required(ErrorMessage = "TC.Kimlik Numarası boş geçilemez!")]
        [RegularExpression(@"^\d{11}$", ErrorMessage = "Geçerli bir TC kimlik numarası girin")]
        public string IdentificationNumber { get; set; }

        [Required(ErrorMessage = "Ad boş geçilemez!")]
        [MaxLength(25, ErrorMessage = "En çok 25 karakter girebilirsiniz!")]
        [MinLength(2, ErrorMessage = "En az 3 karakter girebilirsiniz!")]
        //[RegularExpression(@"^[\p{L}]+$", ErrorMessage = "Sadece harf girişi yapınız!")]
        [RegularExpression("^[^A - Z] +$", ErrorMessage = "Sadece harf girişi yapınız!")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Soyad boş geçilemez!")]
        [MaxLength(25, ErrorMessage = "En çok 25 karakter girebilirsiniz!")]
        [MinLength(2, ErrorMessage = "En az 3 karakter girebilirsiniz!")]
        [RegularExpression("^[^A - Z] +$", ErrorMessage = "Sadece harf girişi yapınız!")]
        public string LastName { get; set; }
        public string Status { get; set; }

    }
}