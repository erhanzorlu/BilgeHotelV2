using BilgeHotel.ENTITY.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BilgeHotel.ENTITY.Entity
{
    public class RoomAndBed : BaseEntity
    {
        public int Count { get; set; }
        public int RoomID { get; set; }
        public int BedID { get; set; }

        public Bed Bed { get; set; }
        public Room Room { get; set; }
    }

}
