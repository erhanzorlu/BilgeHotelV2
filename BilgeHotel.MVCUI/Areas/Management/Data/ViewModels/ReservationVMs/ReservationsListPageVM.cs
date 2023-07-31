using BilgeHotel.MVCUI.Areas.Management.Data.ViewModels.PureVMs;
using BilgeHotel.MVCUI.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BilgeHotel.MVCUI.Areas.Management.Data.ViewModels.ReservationVMs
{
    public class ReservationsListPageVM
    {
        public List<AppUserVM> UserVMs { get; set; }
        public List<GuestVM> GuestVMs { get; set;}
        public List<ReservationVM> ReservationsVMs { get;set; }
        public List<RoomAndReservationVM> roomAndReservationVMs { get; set; }




    }
}