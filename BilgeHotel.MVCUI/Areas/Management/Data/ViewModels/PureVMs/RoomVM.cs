using BilgeHotel.ENTITY.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BilgeHotel.MVCUI.Areas.Management.Data.ViewModels.PureVMs
{
    public class RoomVM
    {
        public int RoomID { get; set; }
        public int FloorNumber { get; set; }
        public int RoomNumber { get; set; }
        public byte Capacity { get; set; }
        public decimal PricePerNight { get; set; }

        public string RoomType { get; set; }
        public string RoomStatus { get; set; }

        public int RoomFeatureID { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public DateTime? DeletedDate { get; set; }
        public DataStatus Status { get; set; }
    }
}