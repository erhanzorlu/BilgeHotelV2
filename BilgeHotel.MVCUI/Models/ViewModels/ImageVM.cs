using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BilgeHotel.MVCUI.Models.ViewModels
{
    public class ImageVM
    {
        public string ImagePath { get; set; }
        public int ImageID { get; set; }

        public List<RoomAndImageVM> RoomAndImageVms { get; set; }
    }
}