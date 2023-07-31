using BilgeHotel.BLL.Repositories.ConcRep;
using BilgeHotel.ENTITY.Entity;
using BilgeHotel.MVCUI.Areas.Management.Data.ViewModels.PureVMs;
using BilgeHotel.MVCUI.AuthenticationClasses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BilgeHotel.MVCUI.Areas.Management.Controllers
{
    [GuestAuthentication]
    public class GuestController : Controller
    {
        GuestRepository _guestrep;
        RoomAndReservationRepository _rrRep;

        public GuestController()
        {
            _guestrep = new GuestRepository();
            _rrRep = new RoomAndReservationRepository();
        }
        // GET: Management/Guest

        public ActionResult ListGuests()
        {
            //Guest g1 = new Guest()
            //{
            //    IdentificationNumber = "11111111111",
            //    FirstName = "Van tu",
            //    LastName = "Tsiri For"
            //};

            //_guestrep.Add(g1);

            List<GuestVM> guests = _guestrep.GetActives().Select(x => new GuestVM
            {
                ID = x.ID,
                FirstName = x.FirstName,
                LastName = x.LastName,
                IdentificationNumber = x.IdentificationNumber,
                Status = x.Status.ToString()
            }).ToList();

            return View(guests);
        }


        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(GuestVM gvm)
        {
            if (ModelState.IsValid)
            {
                if (_guestrep.Any(x => x.IdentificationNumber == gvm.IdentificationNumber))
                {
                    ViewBag.ErrorMessage = "Bu TC.Kimlik numarasına sahip müşteri zaten bulunmaktadır!";
                    return View();
                }
                else
                {
                    Guest guest = new Guest()
                    {
                        IdentificationNumber = gvm.IdentificationNumber,
                        FirstName = gvm.FirstName,
                        LastName = gvm.LastName,
                    };

                    _guestrep.Add(guest);


                    var data = _rrRep.FindForRoom(gvm.RoomNumber);

                    foreach (var item in data)
                    {
                        item.GuestID = guest.ID;
                    }

                    return RedirectToAction("ListGuests");
                }
            }
            else
            {
                ViewBag.ErrorMessage = "Girilen değerler hatalı, yeniden deneyiniz!";
                return View();
            }
        }


        [HttpGet]
        public ActionResult Update(int id)
        {
            Guest updated = _guestrep.Find(id);
            GuestVM model = new GuestVM()
            {
                ID = updated.ID,
                IdentificationNumber = updated.IdentificationNumber,
                FirstName = updated.FirstName,
                LastName = updated.LastName
            };

            return View(model);
        }

        [HttpPost]
        public ActionResult Update(GuestVM gv)
        {
            if (ModelState.IsValid)
            {
                Guest updated = _guestrep.Find(gv.ID);
                updated.FirstName = gv.FirstName;
                updated.LastName = gv.LastName;
                if (updated.IdentificationNumber != gv.IdentificationNumber && _guestrep.Any(x=>x.IdentificationNumber==gv.IdentificationNumber))
                {
                    ViewBag.ErrorMessage = "Girilen kimlik numarasına ait kayıt bulunmaktadır yeniden deneyiniz!";
                    return View();
                }
                else
                {
                        updated.IdentificationNumber = gv.IdentificationNumber;
                        _guestrep.Update(updated);
                        return RedirectToAction("ListGuests");
                }
            }
            else
            {
                ViewBag.ErrorMessage = "Girilen değerler hatalı, yeniden deneyiniz!";
                return View();
            }

            //GuestVM updated = _guestrep.Select(x => new Guest
            //{
            //    IdentificationNumber = gv.IdentificationNumber,
            //    FirstName = gv.FirstName,
            //    LastName = gv.LastName
            //}).Where(x => x.ID == gv.ID);


            //_guestrep.Update(updated);

            //Guest updated = _guestrep.Select(x => new GuestVM
            //{
            //    ID = updated.ID,
            //    FirstName = updated.FirstName,
            //    LastName = updated.LastName,
            //    IdentificationNumber = updated.IdentificationNumber,
            //    Status = updated.Status.ToString()
            //}).Where(x => x.ID == gv.ID);


        }

        public ActionResult Delete(int id)
        {
            _guestrep.Delete(_guestrep.Find(id));
            return RedirectToAction("Index");
        }

    }
}