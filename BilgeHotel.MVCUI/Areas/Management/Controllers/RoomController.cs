using BilgeHotel.BLL.Repositories.ConcRep;
using BilgeHotel.ENTITY.Entity;
using BilgeHotel.MVCUI.Areas.Management.Data.ViewModels.PureVMs;
using BilgeHotel.MVCUI.Areas.Management.Data.ViewModels.RoomVMs;
using BilgeHotel.MVCUI.AuthenticationClasses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BilgeHotel.MVCUI.Areas.Management.Controllers
{
    //[RoomAuthentication]
    public class RoomController : Controller
    {
        // GET: Management/Room

        RoomRepository _roomRep;
        RoomFeatureRepository _roomFeaRep;

        public RoomController()
        {
            _roomRep = new RoomRepository();
            _roomFeaRep = new RoomFeatureRepository();
        }
        public ActionResult ListRooms()
        {
            List<AdminRoomVM> rooms = _roomRep.Select(x => new AdminRoomVM
            {
                RoomID = x.ID,
                Capacity = x.Capacity,
                FloorNumber = x.FloorNumber,
                PricePerNight = x.PricePerNight,
                RoomNumber = x.RoomNumber,
                RoomStatus = x.RoomStatus,
                RoomFeatureID = x.RoomFeatureID,
                RoomType = x.RoomType
            }).ToList();

            List<RoomFeatureVM> roomFeatures = _roomFeaRep.Select(x => new RoomFeatureVM
            {
                FeatureID=x.ID,
                Description=x.Description

            }).ToList();

            ListRoomVM model = new ListRoomVM
            {
                AdminRoomVMs = rooms,
                RoomFeatureVMs = roomFeatures
            };

            return View(model);
        }

        public ActionResult UpdateRoom(int id) 
        {
            Room updated = _roomRep.FirstOrDefault(x => x.ID == id);

            AdminRoomVM roomVm = new AdminRoomVM
            {
                RoomID = updated.ID,
                Capacity = updated.Capacity,
                FloorNumber = updated.FloorNumber,
                PricePerNight = updated.PricePerNight,
                RoomNumber = updated.RoomNumber,
                RoomStatus = updated.RoomStatus,
                RoomType = updated.RoomType,
                RoomFeatureID = updated.RoomFeatureID
            };

            //List<RoomFeatureVM> rfVm = _roomFeaRep.Select(x => new RoomFeatureVM
            //{
            //    Description = x.Description,
            //    FeatureID = x.ID
            //}).ToList();

            //RoomUpdatePageVM model = new RoomUpdatePageVM
            //{
            //    AdminRoomVM = roomVm,
            //    RoomFeatureVMs = rfVm
            //};
            return View(roomVm);
        }

        [HttpPost]
        public ActionResult UpdateRoom(AdminRoomVM adminRoom)
        {
            if (ModelState.IsValid)
            {
                Room updated = _roomRep.FirstOrDefault(x => x.ID == adminRoom.RoomID);
                updated.RoomStatus = adminRoom.RoomStatus;
                updated.PricePerNight = adminRoom.PricePerNight;
                _roomRep.Update(updated);

                return RedirectToAction("ListRooms");
            }
            else
            {
                Room updated = _roomRep.FirstOrDefault(x => x.ID == adminRoom.RoomID);

                AdminRoomVM roomVm = new AdminRoomVM
                {
                    RoomID = updated.ID,
                    Capacity = updated.Capacity,
                    FloorNumber = updated.FloorNumber,
                    PricePerNight = updated.PricePerNight,
                    RoomNumber = updated.RoomNumber,
                    RoomStatus = updated.RoomStatus,
                    RoomType = updated.RoomType,
                    RoomFeatureID = updated.RoomFeatureID
                };
                return View(roomVm);
            }
            
        }

        //[HttpPost]
        //public ActionResult UpdateRoom(AdminRoomVM roomVm)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        Room updated = _roomRep.Find(roomVm.RoomID);
        //        updated.PricePerNight = roomVm.PricePerNight;
        //        updated.RoomStatus = roomVm.RoomStatus;
        //        _roomRep.Update(updated);
        //        return RedirectToAction("ListRooms");
        //    }
        //    else
        //    {
        //        Room updated = _roomRep.FirstOrDefault(x => x.ID == roomVm.RoomID);

        //        AdminRoomVM rvm = new AdminRoomVM
        //        {
        //            RoomID = updated.ID,
        //            Capacity = updated.Capacity,
        //            FloorNumber = updated.FloorNumber,
        //            PricePerNight = updated.PricePerNight,
        //            RoomNumber = updated.RoomNumber,
        //            RoomStatus = updated.RoomStatus,
        //            RoomType = updated.RoomType,
        //            RoomFeatureID = updated.RoomFeatureID
        //        };

        //        List<RoomFeatureVM> rfVm = _roomFeaRep.Select(x => new RoomFeatureVM
        //        {
        //            Description = x.Description,
        //            FeatureID = x.ID
        //        }).ToList();

        //        RoomUpdatePageVM model = new RoomUpdatePageVM
        //        {
        //            AdminRoomVM = rvm,
        //            RoomFeatureVMs = rfVm
        //        };
        //        return View(model);
        //    }
            
        //}

        public ActionResult DeleteRoom(int id)
        {
            Room deleted = _roomRep.Find(id);
            _roomRep.Delete(deleted);

            return RedirectToAction("ListRooms");
        }

        public ActionResult ReserveRoom(/*int id*/)
        {
            return View();
        }
        
    }
}