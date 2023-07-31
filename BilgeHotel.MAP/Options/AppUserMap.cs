using BilgeHotel.ENTITY.Entity;
using BilgeHotel.MAP.BaseOptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BilgeHotel.MAP.Options
{
    public class AppUserMap : BaseMap<AppUser>
    {
        public AppUserMap()
        {
            Property(x => x.FirstName).HasColumnName("İsim");
            Property(x => x.LastName).HasColumnName("Soyisim");
            Property(x => x.IdentificationNumber).HasColumnName("TC. Kimlik Numarası");
            Property(x => x.PhoneNumber).HasColumnName("Telefon Numarası");

            //Birebir iliski tanimlamasi???
            HasOptional(x => x.Profile).WithRequired(x => x.AppUser);

        }
    }
}
