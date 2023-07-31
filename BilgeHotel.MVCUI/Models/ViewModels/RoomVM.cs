using BilgeHotel.ENTITY.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BilgeHotel.MVCUI.Models.ViewModels
{
    public class RoomVM
    {
        public int RoomID { get; set; }
        public int RoomNumber { get; set; }
        public int FloorNumber { get; set; }
        public byte Capacity { get; set; }
        public decimal PricePerNight { get; set; }
        public decimal SubTotal { get; set; } //ARA TOPLAMA AKTARILACAK
        public int FeatureID { get; set; }
    }
}