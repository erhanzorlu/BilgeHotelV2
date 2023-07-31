using BilgeHotel.ENTITY.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BilgeHotel.ENTITY.Entity
{
    public class Image: BaseEntity
    {
        public string ImagePath { get; set; }
        public string Description { get; set; }


        //Relational Props

        public virtual List<Employee> Employees { get; set; }
        public virtual List<HotelInfoAndImage> HotelImages { get; set; }
        public virtual List<RoomAndImage> RoomImages { get; set; }
    }

}
