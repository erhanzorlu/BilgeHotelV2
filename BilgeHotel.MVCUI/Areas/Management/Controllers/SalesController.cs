using BilgeHotel.BLL.Repositories.ConcRep;
using BilgeHotel.ENTITY.Entity;
using BilgeHotel.MVCUI.Areas.Management.Data.ViewModels.PureVMs;
using BilgeHotel.MVCUI.Areas.Management.Data.ViewModels.ReservationVMs;
using BilgeHotel.MVCUI.AuthenticationClasses;
using BilgeHotel.MVCUI.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Web;
using System.Web.Mvc;

namespace BilgeHotel.MVCUI.Areas.Management.Controllers
{

    public class SalesController : Controller
    {
        GuestRepository _guestRep;
        ReservationRepository _reservationsRep;
        RoomAndReservationRepository _roomAndReservationsRep;
        AppUserRepository _appUserRep;

        public SalesController()
        {
            _guestRep = new GuestRepository();
            _reservationsRep = new ReservationRepository();
            _roomAndReservationsRep = new RoomAndReservationRepository();
            _appUserRep = new AppUserRepository();
        }


        [SalesManagerAuthentication]
        public ActionResult ListReservations()
        {
            List<AppUserVM> appUserVM = _appUserRep.Select(x => new AppUserVM
            {
                AppUserID = x.ID,
                FirstName = x.FirstName,
                LastName = x.LastName,

            }).ToList();

            List<ReservationVM> reser = _reservationsRep.Select(x => new ReservationVM
            {
                ReservationID = x.ID,
                AppUserID = x.AppUserID,
                AdultCount = x.AdultCount,
                CampaignID = x.CampaignID,
                CheckInDate = x.CheckInDate,
                CheckOutDate = x.CheckOutDate,
                ChildrenCount = x.ChildrenCount,
                Package = x.Package,
                RoomCount = x.RoomCount,
                TotalPrice = x.TotalPrice,
                Type = x.Type,
                CreatedDate = x.CreatedDate,
                ModifiedDate = x.ModifiedDate,
                DeletedDate = x.DeletedDate,
                Status = x.Status

            }).ToList();

            ReservationsListPageVM reservationsListPageVM = new ReservationsListPageVM()
            {
                ReservationsVMs = reser,
                UserVMs = appUserVM,

            };

            return View(reservationsListPageVM);
        }

        [ShowGuestsAuthentication]
        public ActionResult RoomAndGuests(int reservationID)
        {
            List<GuestVM> guestVMs = _guestRep.Select(x => new GuestVM
            {
                ID = x.ID,
                FirstName = x.FirstName,
                IdentificationNumber = x.IdentificationNumber,
                LastName = x.LastName

            }).ToList();

            List<RoomAndReservationVM> roomAndRes = _roomAndReservationsRep.Select(x => new RoomAndReservationVM
            {
                GuestID = x.GuestID.Value,
                RoomID = x.RoomID,
                ReservationID = x.ReservationID,

            }).Where(x => x.ReservationID == reservationID).ToList();


            ReservationVM reser = _reservationsRep.Select(x => new ReservationVM
            {
                ReservationID = x.ID,
                AppUserID = x.AppUserID,
                CampaignID = x.CampaignID,
                CheckInDate = x.CheckInDate,
                CheckOutDate = x.CheckOutDate,

            }).FirstOrDefault(x => x.ReservationID == reservationID);

            AppUserVM appUserVM = _appUserRep.Select(x => new AppUserVM
            {
                AppUserID = x.ID,
                FirstName = x.FirstName,
                LastName = x.LastName,

            }).FirstOrDefault(x => x.AppUserID == reser.AppUserID);

            RoomAndGuestsListPageVM room = new RoomAndGuestsListPageVM
            {
                GuestVMs = guestVMs,
                ReservationsVM = reser,
                RoomAndReservationVMs = roomAndRes,
                UserVM = appUserVM
            };
            return View(room);
        }

        



    }
}
