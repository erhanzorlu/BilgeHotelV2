using BilgeHotel.ENTITY.Entity;
using BilgeHotel.MAP.BaseOptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BilgeHotel.MAP.Options
{
    public class BedMap : BaseMap<Bed>
    {
        public BedMap()
        {
            Property(x => x.BedType).HasColumnName("Yatak Tipi");

        }
    }
}
