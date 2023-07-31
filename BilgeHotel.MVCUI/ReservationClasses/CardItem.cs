using BilgeHotel.ENTITY.Enum;
using BilgeHotel.MVCUI.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BilgeHotel.MVCUI.ReservationClasses
{
    public class CardItem
    {
        public int RoomID { get; set; }
        public int RoomNumber { get; set; }
        public int FloorNumber { get; set; }
        public byte Capacity { get; set; }
        public decimal PricePerNight { get; set; }
        public decimal SubTotal { get; set; } //ARA TOPLAMA AKTARILACAK
        
        public int AppUserID { get; set; }

        public DateTime? CheckInDate { get; set; } 
        public DateTime? CheckOutDate { get; set; }

        public int StayingDays { get; set; }

        public int? RoomCount { get; set; }
        public int? AdultCount { get; set; }
        public int? ChildrenCount { get; set; }

        public decimal? TotalPrice { get; set; } 
        public ReservationPackage? Package { get; set; } //Her sey dahil = 1, Tam pansiyon = 2

        public int? CampaignID { get; set; }
    }
}