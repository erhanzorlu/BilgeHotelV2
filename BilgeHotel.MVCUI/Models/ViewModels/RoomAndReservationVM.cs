using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BilgeHotel.MVCUI.Models.ViewModels
{
    public class RoomAndReservationVM
    {
        public int RoomID { get; set; } 
        public int ReservationID { get; set; }
        public int? GuestID { get; set; }
    }
}