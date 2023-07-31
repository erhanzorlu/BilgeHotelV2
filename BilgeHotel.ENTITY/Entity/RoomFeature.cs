using BilgeHotel.ENTITY.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BilgeHotel.ENTITY.Entity
{
    public class RoomFeature: BaseEntity
    {
        public string Description { get; set; }

        //Navigation Prop

        public virtual List<Room> Rooms { get; set; }
    }
}
