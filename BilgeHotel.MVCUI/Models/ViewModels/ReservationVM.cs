using BilgeHotel.ENTITY.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BilgeHotel.MVCUI.Models.ViewModels
{
    public class ReservationVM
    {
        public int ReservationID { get; set; }
        public DateTime CheckInDate { get; set; } //=> saati 14:00
        public DateTime CheckOutDate { get; set; } //=> saati 10:00

        public byte RoomCount { get; set; }
        public byte AdultCount { get; set; }
        public byte ChildrenCount { get; set; }

        public decimal TotalPrice { get; set; } //musteri ui resepsiyon ui

        //public int HowManyDays { get => (CheckOutDate.Day - CheckInDate.Day); }
        public ReservationPackage Package { get; set; } //Her sey dahil = 1, Tam pansiyon = 2

        public ReservationType Type { get; set; }
        public int? CampaignID { get; set; }

        public int AppUserID { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public DateTime? DeletedDate { get; set; }
        public DataStatus Status { get; set; }
    }
}