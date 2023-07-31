using BilgeHotel.ENTITY.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BilgeHotel.ENTITY.Entity
{
    public class RoomAndReservation : BaseEntity
    {
        public int RoomID { get; set; }
        public int ReservationID { get; set; }

        public int? GuestID { get; set; } //ŞİMDİ EKLEDİM 1-N ilişki için
        public Guest Guest { get; set; }
        public Room Room { get; set; }
        public Reservation Reservation { get; set; }
    }

}
