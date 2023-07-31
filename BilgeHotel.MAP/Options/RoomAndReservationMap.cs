using BilgeHotel.ENTITY.Entity;
using BilgeHotel.MAP.BaseOptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BilgeHotel.MAP.Options
{
    public class RoomAndReservationMap : BaseMap<RoomAndReservation>
    {
        public RoomAndReservationMap()
        {
            Ignore(x => x.ID);
            HasKey(x => new
            {
                x.RoomID,
                x.ReservationID,
            });
        }
    }
}
