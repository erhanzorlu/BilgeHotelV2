using BilgeHotel.ENTITY.Entity;
using BilgeHotel.MAP.BaseOptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BilgeHotel.MAP.Options
{
    public class ShiftMap : BaseMap<Shift>
    {
        public ShiftMap()
        {
            
            Property(x => x.ShiftInterval).HasColumnName("Mesai Saatleri");

        }
    }
}
