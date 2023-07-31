using BilgeHotel.ENTITY.Entity;
using BilgeHotel.MAP.BaseOptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BilgeHotel.MAP.Options
{
    public class ExtraShiftMap : BaseMap<ExtraShift>
    {
        public ExtraShiftMap()
        {
            Property(x => x.HowManyHours).HasColumnName("Kaç Saat");
            Property(x => x.ShiftWagePerHour).HasColumnName("Ek Mesai Saat Ücreti");
            Property(x => x.ExtraShiftDate).HasColumnName("Ek Mesai Tarihi");
            Property(x => x.EmployeeID).HasColumnName("Çalışan");

        }
    }
}
