using BilgeHotel.ENTITY.Entity;
using BilgeHotel.MAP.BaseOptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BilgeHotel.MAP.Options
{
    public class RoomMap : BaseMap<Room>
    {
        public RoomMap()
        {
            Property(x => x.RoomNumber).HasColumnName("Oda Numarası");
            Property(x => x.FloorNumber).HasColumnName("Kat Numarası");
            Property(x => x.Capacity).HasColumnName("Kapasite");
            Property(x => x.PricePerNight).HasColumnName("Gecelik Ücret");
            Property(x => x.RoomStatus).HasColumnName("Durum");

        }
    }
}
