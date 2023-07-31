using BilgeHotel.ENTITY.Enum;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BilgeHotel.MVCUI.Areas.Management.Data.ViewModels.PureVMs
{
    public class EmployeeVM
    {
        //public EmployeeVM()
        //{
            //ExtraShiftVMs = new List<ExtraShiftVM>();
        //}
        public int EmployeeID { get; set; }

        [Required(ErrorMessage = "Ad boş geçilemez!")]
        [MaxLength(25, ErrorMessage = "En çok 25 karakter girebilirsiniz!")]
        [MinLength(2, ErrorMessage = "En az 3 karakter girebilirsiniz!")]
        [RegularExpression(@"^[\p{L}]+$", ErrorMessage = "Sadece harf girişi yapınız!")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Soyad boş geçilemez!")]
        [MaxLength(25, ErrorMessage = "En çok 25 karakter girebilirsiniz!")]
        [MinLength(2, ErrorMessage = "En az 3 karakter girmelisiniz!")]
        [RegularExpression(@"^[a-zA-ZğüşöçıİĞÜŞÖÇ]+$", ErrorMessage = "Sadece harf girişi yapınız!")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "Adres boş geçilemez!")]
        [MaxLength(250, ErrorMessage = "En çok 250 karakter girebilirsiniz!")]
        [MinLength(2, ErrorMessage = "En az 3 karakter girmelisiniz!")]
        public string Address { get; set; }

        [Required(ErrorMessage = "Telefon numarası boş geçilemez!")]
        [RegularExpression("^\\+?[0-9][0-9]{7,14}$", ErrorMessage = "Uygun formatta giriş yapınız!")]
        public string PhoneNumber { get; set; }
        public WeekDays OffDay { get; set; }

        [RegularExpression("^[0-9]*[.,]?[0-9]+$", ErrorMessage = "Yalnızca sayı girişi yapınız!")]
        //alt gr + t => tl sign
        public decimal? Salary { get; set; }

        [RegularExpression("^[0-9]*[.,]?[0-9]+$", ErrorMessage = "Yalnızca sayı girişi yapınız!")]
        public decimal? WagePerHour { get; set; }

        [DataType(DataType.EmailAddress, ErrorMessage = "Lütfen email formatına uygun giriş yapınız!")]
        [Required(ErrorMessage = "Email adresi boş geçilemez!")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Şifre boş geçilemez!")]
        [MinLength(6, ErrorMessage = "Şifre en az 6 karakterli olabilir!")]
        [MaxLength(16, ErrorMessage = "Şifre en çok 16 karakterli olabilir!")]
        public string Password { get; set; }
        public int? JobID { get; set; }
        public int? ShiftID { get; set; }
        public int? ImageID { get; set; }

        public DateTime SalaryDay { get; set; }

        public string ImagePath { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public DateTime? DeletedDate { get; set; }
        public DataStatus Status { get; set; }
    }
}