using BilgeHotel.ENTITY.Entity;
using BilgeHotel.MAP.BaseOptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BilgeHotel.MAP.Options
{
    public class EmployeeMap : BaseMap<Employee>
    {
        public EmployeeMap()
        {
            Property(x => x.FirstName).HasColumnName("İsim");
            Property(x => x.LastName).HasColumnName("Soyisim");
            Property(x => x.Address).HasColumnName("Adres");
            Property(x => x.Email).HasColumnName("Mail Adresi");
            Property(x => x.WagePerHour).HasColumnName("Saat Ücreti");
            Property(x => x.Salary).HasColumnName("Maaş");
            Property(x => x.PhoneNumber).HasColumnName("Telefon Numarası");
            Property(x => x.OffDay).HasColumnName("İzin Günü");
            Property(x => x.JobID).HasColumnName("Meslek");
            Property(x => x.ShiftID).HasColumnName("Vardiya");



        }
    }
}
