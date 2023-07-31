using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BilgeHotel.MVCUI.Models.ViewModels
{
    public class BedVM
    {
        public int BedID { get; set; } 
        public string BedType { get; set; }

        public List<RoomAndBedVM> RoomAndBedVms { get; set; }
    }
}