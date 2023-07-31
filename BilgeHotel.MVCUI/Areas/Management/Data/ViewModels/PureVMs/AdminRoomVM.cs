using BilgeHotel.ENTITY.Enum;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BilgeHotel.MVCUI.Areas.Management.Data.ViewModels.PureVMs
{
    public class AdminRoomVM
    {
        public int RoomID { get; set; }
        public int FloorNumber { get; set; }
        public int RoomNumber { get; set; }
        public byte Capacity { get; set; }

        [Required(ErrorMessage = "Gecelik ücret boş geçilemez!")]
        [RegularExpression("^[0-9]*[.,]?[0-9]+$", ErrorMessage = "Yalnızca sayı girişi yapınız!")]
        public decimal PricePerNight { get; set; }

        public RoomType RoomType { get; set; }
        public RoomStatus RoomStatus { get; set; }

        public int? RoomFeatureID { get; set; }
    }
}