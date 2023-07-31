using BilgeHotel.ENTITY.Base;
using BilgeHotel.ENTITY.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BilgeHotel.ENTITY.Entity
{
    public class Reservation : BaseEntity
    {

        public Reservation()
        {
            RoomAndReservations = new List<RoomAndReservation>();
        }
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

        //Relational Props

        public virtual Campaign Campaign { get; set; }
        public virtual List<RoomAndReservation> RoomAndReservations { get; set; }

        public virtual AppUser AppUser { get; set; }
    }

}
