using BilgeHotel.ENTITY.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BilgeHotel.ENTITY.Entity
{
    public class HotelInfo : BaseEntity
    {
        public string Name { get; set; }
        public string Address { get; set; }
        public string Description { get; set; }

        //Relational Props
        public virtual List<HotelInfoAndImage> HotelPhotos { get; set; }
    }
}
