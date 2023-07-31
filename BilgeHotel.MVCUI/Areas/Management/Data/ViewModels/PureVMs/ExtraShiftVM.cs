using BilgeHotel.ENTITY.Enum;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BilgeHotel.MVCUI.Areas.Management.Data.ViewModels.PureVMs
{
    public class ExtraShiftVM
    {
        public int ExtraShiftID { get; set; }

        [Required(ErrorMessage = "Saatlik ücreti girmek zorunludur!")]
        //[RegularExpression("^[1-9]*[.,]?[0-9]+$", ErrorMessage = "Yalnızca sayı girişi yapınız!")]
        public decimal ShiftWagePerHour { get; set; } //disaridan kacKati girilecek bunu method hesaplayacak

        [Required(ErrorMessage = "Lütfen bir tarih seçiniz!")]
        public DateTime ExtraShiftDate { get; set; }

        [Required(ErrorMessage = "Mesai saatini girmek zorunludur!")]
        [RegularExpression("^[1-9]*[.,]?[0-9]+$", ErrorMessage = "Yalnızca sayı girişi yapınız!")]
        public decimal HowManyHours { get; set; } //disaridan girilecek

        public decimal TotalWage { get; set; } //methodla hesaplanacak
        public int EmployeeID { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public DateTime? DeletedDate { get; set; }
        public DataStatus Status { get; set; }
    }
}