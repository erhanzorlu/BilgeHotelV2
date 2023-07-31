using BilgeHotel.ENTITY.Base;
using BilgeHotel.ENTITY.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BilgeHotel.ENTITY.Entity
{
    public class Bed : BaseEntity
    {

        public string BedType { get; set; }

        //Relational Props

        public virtual List<RoomAndBed> RoomAndBeds { get; set; }


    }
}
