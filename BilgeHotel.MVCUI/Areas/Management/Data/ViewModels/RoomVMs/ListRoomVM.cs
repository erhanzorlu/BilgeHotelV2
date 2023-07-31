using BilgeHotel.MVCUI.Areas.Management.Data.ViewModels.PureVMs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BilgeHotel.MVCUI.Areas.Management.Data.ViewModels.RoomVMs
{
    public class ListRoomVM
    {
        public List<AdminRoomVM> AdminRoomVMs { get; set; }
        public List<RoomFeatureVM> RoomFeatureVMs { get; set; }
         
    }
}