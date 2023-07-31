using BilgeHotel.ENTITY.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BilgeHotel.ENTITY.Entity
{
    public class RoomAndImage : BaseEntity
    {
        public int ImageID { get; set; }
        public int RoomID { get; set; }
        public Room Room { get; set; }
        public Image Image { get; set; }
    }

}
