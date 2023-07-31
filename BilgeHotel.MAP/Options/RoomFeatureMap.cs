using BilgeHotel.ENTITY.Entity;
using BilgeHotel.MAP.BaseOptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BilgeHotel.MAP.Options
{
    public class RoomFeatureMap : BaseMap<RoomFeature>
    {
        public RoomFeatureMap()
        {
            Property(x => x.Description).HasColumnName("Açıklama");
        }
    }
}
