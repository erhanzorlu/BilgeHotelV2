using BilgeHotel.MVCUI.Areas.Management.Data.ViewModels.PureVMs;
using BilgeHotel.MVCUI.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BilgeHotel.MVCUI.Areas.Management.Data.ViewModels.ReservationVMs
{
    public class RoomAndGuestsListPageVM
    {
        public List<RoomAndReservationVM> RoomAndReservationVMs { get; set; }
        public List<GuestVM> GuestVMs { get; set; }
        public AppUserVM UserVM { get; set; }
        public ReservationVM ReservationsVM { get; set; }
    }
}