using BilgeHotel.ENTITY.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BilgeHotel.MVCUI.Models.ViewModels.PageVMs
{
    public class IndexVM
    {
        public List<ImageVM> ImagesVm { get; set; }
        public List<RoomFeatureVM> RoomFeaturesVm { get; set; }
        public List<RoomVM> RoomsVm { get; set; }
        public List<RoomAndImageVM> RoomAndImagesVm { get; set; } //ara tabloVM'i
        public HotelInfoVM HotelInfosVm { get; set; } 
    }
}