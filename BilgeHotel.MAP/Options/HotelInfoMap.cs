using BilgeHotel.ENTITY.Entity;
using BilgeHotel.MAP.BaseOptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BilgeHotel.MAP.Options
{
    public class HotelInfoMap : BaseMap<HotelInfo>
    {
        public HotelInfoMap()
        {
            Property(x => x.Name).HasColumnName("İsim");
            Property(x => x.Address).HasColumnName("Adres");
            Property(x => x.Description).HasColumnName("Açıklama");

        }
    }
}
