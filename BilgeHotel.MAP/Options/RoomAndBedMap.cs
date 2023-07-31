using BilgeHotel.ENTITY.Entity;
using BilgeHotel.MAP.BaseOptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BilgeHotel.MAP.Options
{
    public class RoomAndBedMap : BaseMap<RoomAndBed>
    {
        public RoomAndBedMap()
        {
            Ignore(x => x.ID);
            HasKey(x => new
            {
                x.BedID,
                x.RoomID
            });

            Property(x => x.Count).HasColumnName("Kaç Adet");
        }
    }
}
