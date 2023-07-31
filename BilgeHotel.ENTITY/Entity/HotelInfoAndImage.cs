using BilgeHotel.ENTITY.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BilgeHotel.ENTITY.Entity
{
    public class HotelInfoAndImage : BaseEntity
    {
        public int HotelInfoID { get; set; }
        public int ImageID { get; set; }

        public HotelInfo HotelInfo { get; set; }
        public Image Image { get; set; }
    }
}
