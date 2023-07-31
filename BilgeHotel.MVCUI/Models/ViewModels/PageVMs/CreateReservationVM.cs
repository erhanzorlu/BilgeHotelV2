using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BilgeHotel.MVCUI.Models.ViewModels.PageVMs
{
    public class CreateReservationVM
    { 
        public List<ImageVM> ImagesVm { get; set; }
        public List<RoomFeatureVM> FeaturesVm { get; set; }
        public RoomVM RoomVm { get; set; }
        public List<BedVM> BedVm { get; set; }
        public List<RoomAndBedVM> RoomAndBedVm { get; set; }
        public List<RoomAndImageVM> RoomAndImagesVm { get; set; }
        public int RoomCount { get; set; }
        public int AppUserID { get; set; }
        public decimal SubTotal { get; set; }

    }
}