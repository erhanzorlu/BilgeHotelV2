using BilgeHotel.ENTITY.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BilgeHotel.MVCUI.Models.ViewModels
{
    public class RoomAndImageVM
    {
        public int RoomID { get; set; }
        public int ImageID { get; set; }
        public ImageVM ImageVms { get; set; } //Image'in kendisine ulaşmakçin kullandım ama vM olmalıydı!!!!!!!!!!
    }
}