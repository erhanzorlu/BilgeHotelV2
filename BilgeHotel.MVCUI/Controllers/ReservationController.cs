using BilgeHotel.BLL.Repositories.ConcRep;
using BilgeHotel.BLL.Repositories.IntRep;
using BilgeHotel.ENTITY.Entity;
using BilgeHotel.ENTITY.Enum;
using BilgeHotel.MVCUI.AuthenticationClasses;
using BilgeHotel.MVCUI.Models.ViewModels;
using BilgeHotel.MVCUI.Models.ViewModels.PageVMs;
using BilgeHotel.MVCUI.ReservationClasses;
using Microsoft.Ajax.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BilgeHotel.MVCUI.Controllers
{
    [UserAuthentication]
    public class ReservationController : Controller
    {
        ReservationRepository _resRep;
        RoomRepository _roomRep;
        RoomAndReservationRepository _rrRep;
        ImageRepository _imageRep;
        RoomFeatureRepository _featureRep;
        RoomAndImageRepository _roomAndImageRep;
        BedRepository _bedRep;
        RoomAndBedRepository _roombedRep;
        CampaignRepository _campRep;

        public ReservationController()
        {
            _resRep = new ReservationRepository();
            _roomRep = new RoomRepository();
            _rrRep = new RoomAndReservationRepository();
            _imageRep = new ImageRepository();
            _featureRep = new RoomFeatureRepository();
            _roomAndImageRep = new RoomAndImageRepository();
            _bedRep = new BedRepository();
            _roombedRep = new RoomAndBedRepository();
            _campRep = new CampaignRepository();
        }

        public static List<RoomVM> availableRoomList = new List<RoomVM>();

        public static List<CardItem> card = new List<CardItem>();

        public class Sabitler
        {
            public DateTime CheckInDate { get; set; }
            public DateTime CheckOutDate { get; set; }
            public ReservationPackage? Package { get; set; }
            public int AppUserID { get; set; }
        }

        // GET: Reservation
        public ActionResult FindRooms()
        {
            return View();
        }

        [HttpPost]
        public ActionResult FindRooms(DateTime checkIn, DateTime checkOut, int adult, int child, ReservationPackage? package) //ÜRÜN ARAT
        {
            availableRoomList.Clear();

            _resRep.SetTimes(ref checkIn, ref checkOut);
            int personCount = adult + child;
            TimeSpan dateDiff = checkIn.Date - DateTime.Today.Date;
            TimeSpan stayingDays = checkOut - checkIn;

            Session["CheckInDate"] = checkIn; //İLERİDE REZERVASYON OLUŞTURURKEN NE KADAR ERKEN DİYE KONTROL ETMEKÇİN
            //Session["CheckOutDate"] = checkOut;

            if (card.Count == 0)
            {
                if (checkIn.Date <= DateTime.Today.Date)
                {
                    ViewBag.DateTimeError = "Bu güne ve geçmişe ait rezervasyon oluşturulamaz!";
                    return View();

                }
                else if ((checkOut.Date - checkIn.Date).Days < 1)
                {
                    ViewBag.DateTimeError = "Çıkış tarihi giriş tarihinden geride olamaz!";
                    return View();
                }
                else if (dateDiff.Days > 120)
                {
                    ViewBag.DateTimeError = "120 günden daha ileri tarihte rezervasyon oluşturulamaz!";
                    return View();
                }
                else if (stayingDays.Days > 120)
                {
                    ViewBag.DateTimeError = "Otelimizde 120 günden daha uzun süre konaklanamaz!";
                    return View();
                }
                else if (personCount > 4)
                {
                    ViewBag.PersonCountError = "Kişi sayısı 4'ü aşamaz!";
                    return View();
                }
                else
                {

                    var reservations = _resRep.GetAllReservations(checkIn, checkOut);
                    var idler = _resRep.GetReservationIDs(reservations);
                    var odaIdler = _rrRep.FindReservedRoomIDs(idler);

                    List<RoomVM> availableForReservation = _roomRep.GetRoomsForReservation(odaIdler, personCount).Select(x => new RoomVM
                    {
                        RoomID = x.ID,
                        PricePerNight = x.PricePerNight,
                        Capacity = x.Capacity,
                        FeatureID = x.RoomFeatureID,
                        FloorNumber = x.FloorNumber,
                        RoomNumber = x.RoomNumber,
                        SubTotal = x.PricePerNight * stayingDays.Days
                    }).ToList();

                    TempData["ChoosenDates"] = checkIn.ToShortDateString() + "-" + checkOut.ToShortDateString();

                    availableRoomList.AddRange(availableForReservation);

                    Session["ReservationDays"] = stayingDays.Days;


                    CardItem cardItem = new CardItem()
                    {
                        CheckInDate = checkIn,
                        CheckOutDate = checkOut,
                        ChildrenCount = child,
                        AdultCount = adult,
                        StayingDays = stayingDays.Days,
                        Package = package.Value
                    };

                    Session["CardItem"] = cardItem;

                    return RedirectToAction("ListAvailableRooms");
                }

            }
            else if (card.Count <= 2)
            {

                if (checkIn.Date <= DateTime.Today.Date)
                {
                    ViewBag.DateTimeError = "Bu güne ve geçmişe ait rezervasyon oluşturulamaz!";
                    return View();

                }
                else if ((checkOut.Date - checkIn.Date).Days < 1)
                {
                    ViewBag.DateTimeError = "Çıkış tarihi giriş tarihinden geride olamaz!";
                    return View();
                }
                else if (dateDiff.Days > 120)
                {
                    ViewBag.DateTimeError = "120 günden daha ileri tarihte rezervasyon oluşturulamaz!";
                    return View();
                }
                else if (stayingDays.Days > 120)
                {
                    ViewBag.DateTimeError = "Otelimizde 120 günden daha uzun süre konaklanamaz!";
                    return View();
                }
                else if (personCount > 4)
                {
                    ViewBag.PersonCountError = "Kişi sayısı 4'ü aşamaz!";
                    return View();
                }
                else if (card.Any(x => x.CheckInDate != checkIn || x.CheckOutDate != checkOut))
                {
                    ViewBag.DateTimeError = "Oda eklerken giriş ve çıkış tarihleri aynı olmak zorundadır!";
                    return View();
                }
                else
                {
                    //_resRep.SetTimes(ref checkIn, ref checkOut);

                    var reservations = _resRep.GetAllReservations(checkIn, checkOut);
                    var idler = _resRep.GetReservationIDs(reservations);
                    var odaIdler = _rrRep.FindReservedRoomIDs(idler);

                    List<RoomVM> availableForReservation = _roomRep.GetRoomsForReservation(odaIdler, personCount).Select(x => new RoomVM
                    {
                        RoomID = x.ID,
                        PricePerNight = x.PricePerNight,
                        Capacity = x.Capacity,
                        FeatureID = x.RoomFeatureID,
                        FloorNumber = x.FloorNumber,
                        RoomNumber = x.RoomNumber,
                        SubTotal = x.PricePerNight * stayingDays.Days
                    }).ToList();

                    TempData["ChoosenDates"] = checkIn.ToShortDateString() + "-" + checkOut.ToShortDateString();

                    availableRoomList.AddRange(availableForReservation);

                    Session["ReservationDays"] = stayingDays.Days;


                    CardItem cardItem = new CardItem()
                    {
                        CheckInDate = checkIn,
                        CheckOutDate = checkOut,
                        ChildrenCount = child,
                        AdultCount = adult,
                        StayingDays = stayingDays.Days,
                        Package = package.Value
                    };

                    Sabitler sabitler = new Sabitler()
                    {
                        CheckInDate = checkIn,
                        CheckOutDate = checkOut,
                        Package = package,
                    };
                    Session["Sabitler"] = sabitler;

                    Session["CardItem"] = cardItem;

                    return RedirectToAction("ListAvailableRooms");
                }
            }

            return RedirectToAction("ListAvailableRooms");

        }


        public ActionResult ListAvailableRooms() //ÜRÜN SEÇ
        {
            List<RoomAndBedVM> roomAndBeds = _roombedRep.GetActives().Select(x => new RoomAndBedVM
            {
                BedID = x.BedID,
                Count = x.Count,
                RoomID = x.RoomID,

            }).ToList();

            List<BedVM> beds = _bedRep.GetActives().Select(x => new BedVM
            {
                BedID = x.ID,
                BedType = x.BedType,
                RoomAndBedVms = roomAndBeds
            }).ToList();

            List<RoomFeatureVM> feature = _featureRep.GetActives().Select(x => new RoomFeatureVM
            {
                Description = x.Description,
                FeatureID = x.ID
            }).ToList();

            List<RoomAndImageVM> roomAndImage = _roomAndImageRep.GetActives().Select(x => new RoomAndImageVM
            {
                ImageID = x.ImageID,
                RoomID = x.RoomID,
            }).ToList();

            List<ImageVM> images = _imageRep.GetActives().Select(x => new ImageVM
            {
                ImagePath = x.ImagePath,
                ImageID = x.ID,
                RoomAndImageVms = roomAndImage
            }).ToList();

            ListAvailableRoomsVM rooms = new ListAvailableRoomsVM()
            {
                ImagesVm = images,
                RoomAndImagesVm = roomAndImage,
                RoomFeaturesVm = feature,
                RoomsVm = availableRoomList,
                BedVm = beds,
                RoomAndBedVm = roomAndBeds

            };

            return View(rooms);
        }


        public ActionResult CreateReservation(int id) //SEPET SAYFASI
        {
            //int gunler = (int)Session["ReservationDays"];
            //int userID = (int)Session["UserAuth"];

            CardItem cardItem = Session["CardItem"] as CardItem;

            if (card.Count == 0)
            {
                RoomVM selectedRoom = _roomRep.GetActives().Select(x => new RoomVM
                {
                    Capacity = x.Capacity,
                    FloorNumber = x.FloorNumber,
                    PricePerNight = x.PricePerNight,
                    RoomID = x.ID,
                    RoomNumber = x.RoomNumber,
                    SubTotal = x.PricePerNight * cardItem.StayingDays, //cardItem.Days
                }).FirstOrDefault(x => x.RoomID == id);

                cardItem.RoomID = selectedRoom.RoomID;
                cardItem.Capacity = selectedRoom.Capacity;
                cardItem.FloorNumber = selectedRoom.FloorNumber;
                cardItem.SubTotal = selectedRoom.SubTotal;
                cardItem.RoomNumber = selectedRoom.RoomNumber;
                cardItem.TotalPrice += selectedRoom.SubTotal;
                cardItem.RoomCount++;

                card.Add(cardItem);

                return View(card);

            }
            else if (card.Count <= 2)
            {

                cardItem.RoomID = id;
                if (card.Any(x => x.RoomID == id))
                {
                    ViewBag.RoomCantChoose = "Bu odayı zaten seçtiniz! Bir başka oda ekleyiniz!";
                    return View(card);
                }
                else
                {
                    RoomVM selectedRoom = _roomRep.GetActives().Select(x => new RoomVM
                    {
                        Capacity = x.Capacity,
                        FloorNumber = x.FloorNumber,
                        PricePerNight = x.PricePerNight,
                        RoomID = x.ID,
                        RoomNumber = x.RoomNumber,
                        SubTotal = x.PricePerNight * cardItem.StayingDays, //cardItem.Days
                    }).FirstOrDefault(x => x.RoomID == id);

                    cardItem.Capacity = selectedRoom.Capacity;
                    cardItem.FloorNumber = selectedRoom.FloorNumber;
                    cardItem.SubTotal = selectedRoom.SubTotal;
                    cardItem.RoomNumber = selectedRoom.RoomNumber;
                    cardItem.TotalPrice += selectedRoom.SubTotal;
                    cardItem.RoomCount++;

                    card.Add(cardItem);

                    return View(card);
                }

            }
            else if (card.Count == 3)
            {
                ViewBag.RoomCountError = "Maksimum sayıda oda eklediniz!";
                return View(card);
            }

            return View(card);
        }

        [HttpPost]
        public ActionResult CreateReservation() //SEPET SAYFASI
        {
            Sabitler cartItem = Session["Sabitler"] as Sabitler;
            //en az bir ay önce yapılan AllInOne rezervasyonlarda % 18,
            //en az bir ay önce yapılan FullPension rezervasyonlarda % 16,
            //en az 3 ay önce yapılan rezervasyonlarda % 23 indirim.
            int adults = 0;
            int childrens = 0;
            double totalPrice = 0;

            foreach (var item in card)
            {
                adults += item.AdultCount.Value;
                childrens += item.ChildrenCount.Value;
                totalPrice += Convert.ToDouble(item.SubTotal);

            }


            if ((DateTime.Now.Date - cartItem.CheckInDate.Date).Days > 90)
            {
                totalPrice = totalPrice * (1 - 0.23);
            }
            else if ((DateTime.Now.Date - cartItem.CheckInDate.Date).Days > 30 && cartItem.Package == ReservationPackage.FullPension)
            {
                totalPrice = totalPrice * (1 - 0.16);
            }
            else if ((DateTime.Now.Date - cartItem.CheckInDate.Date).Days > 30 && cartItem.Package == ReservationPackage.AllInOne)
            {
                totalPrice = totalPrice * (1 - 0.18);
            }


            Reservation r = new Reservation()
            {
                AppUserID = (int)Session["UserAuth"],
                Package = cartItem.Package.Value,
                CheckInDate = cartItem.CheckInDate,
                CheckOutDate = cartItem.CheckOutDate,
                AdultCount = Convert.ToByte(adults),
                Type = ReservationType.Online,
                ChildrenCount = Convert.ToByte(childrens),
                TotalPrice = Convert.ToDecimal(totalPrice),
                RoomCount = Convert.ToByte(card.Count),
            };

            _resRep.Add(r);

            foreach (var item in card)
            {
                RoomAndReservation roomAndReservation = new RoomAndReservation
                {
                    ReservationID = r.ID,
                    RoomID = item.RoomID
                };
                _rrRep.Add(roomAndReservation);
            }

            return RedirectToAction("FindRooms");
        }


    }
}