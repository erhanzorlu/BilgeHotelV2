using BilgeHotel.BLL.Repositories.ConcRep;
using BilgeHotel.ENTITY.Entity;
using BilgeHotel.ENTITY.Enum;
using BilgeHotel.MVCUI.Areas.Management.Data.ViewModels.ReservationVMs;
using BilgeHotel.MVCUI.AuthenticationClasses;
using BilgeHotel.MVCUI.Models.ViewModels;
using BilgeHotel.MVCUI.Models.ViewModels.PageVMs;
using BilgeHotel.MVCUI.ReservationClasses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BilgeHotel.MVCUI.Areas.Management.Controllers
{
    //[ReceptionistAuthentication]
    public class ReceptionistController : Controller
    {
        ReservationRepository _resRep;
        RoomRepository _roomRep;
        RoomAndReservationRepository _rrRep;
        ImageRepository _imageRep;
        RoomFeatureRepository _featureRep;
        RoomAndImageRepository _roomAndImageRep;
        BedRepository _bedRep;
        RoomAndBedRepository _roombedRep;
        AppUserRepository _appUserRep;

        public ReceptionistController()
        {
            _resRep = new ReservationRepository();
            _roomRep = new RoomRepository();
            _rrRep = new RoomAndReservationRepository();
            _imageRep = new ImageRepository();
            _featureRep = new RoomFeatureRepository();
            _roomAndImageRep = new RoomAndImageRepository();
            _bedRep = new BedRepository();
            _roombedRep = new RoomAndBedRepository();
            _appUserRep=new AppUserRepository();
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
        public ActionResult FindRooms(DateTime checkIn, DateTime checkOut, int adult, int child,ReservationPackage? package,AppUserVM appUser) //ÜRÜN ARAT
        {
            availableRoomList.Clear();

            _resRep.SetTimes(ref checkIn, ref checkOut);
            int personCount = adult + child;
            TimeSpan dateDiff = checkIn.Date - DateTime.Today.Date;
            TimeSpan stayingDays = checkOut - checkIn;

            //Session["CheckInDate"] = checkIn;
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
                        Package = package.Value,
                        
                    };
                    
                    if (_appUserRep.GetActives().Any(x=>x.IdentificationNumber==appUser.IdentificationNumber)) // Eğer TC Kimlik veritabanında kayıtlıysas
                    {
                        AppUser app=  _appUserRep.GetActives().FirstOrDefault(x => x.IdentificationNumber == appUser.IdentificationNumber);

                        Sabitler sabitler = new Sabitler()
                        {
                            CheckInDate = checkIn,
                            CheckOutDate = checkOut,
                            Package = package,
                            AppUserID = app.ID,
                        };
                        Session["Sabitler"] = sabitler;
                    }
                    else // TCSİ Veritabanında kayıtlı değilse
                    {
                        AppUser user = new AppUser()
                        {
                            IdentificationNumber = appUser.IdentificationNumber,
                            FirstName = appUser.FirstName,
                            LastName = appUser.LastName,
                            PhoneNumber = appUser.PhoneNumber,
                        };
                        _appUserRep.Add(user);

                        Sabitler sabitler = new Sabitler()
                        {
                            CheckInDate = checkIn,
                            CheckOutDate = checkOut,
                            Package = package,
                            AppUserID = user.ID,
                        };
                        Session["Sabitler"] = sabitler;
                    }
                  
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
                        Package=package,
                        
                    };

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
            int adults=0;
            int childrens=0;
            decimal totalPrice = 0;
            foreach (var item in card)
            {
                adults += item.AdultCount.Value;
                childrens += item.ChildrenCount.Value;
                totalPrice += item.SubTotal ;

            }

            Reservation r = new Reservation()
            {
                AppUserID =cartItem.AppUserID,
                Package = cartItem.Package.Value,
                CheckInDate=cartItem.CheckInDate,
                CheckOutDate=cartItem.CheckOutDate,
                AdultCount=Convert.ToByte(adults),
                Type=ReservationType.ByPhone,
                ChildrenCount=Convert.ToByte(childrens),
                TotalPrice=totalPrice,    
                RoomCount=Convert.ToByte(card.Count),
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