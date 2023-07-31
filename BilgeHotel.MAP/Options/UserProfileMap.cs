using BilgeHotel.ENTITY.Entity;
using BilgeHotel.ENTITY.Enum;
using BilgeHotel.MAP.BaseOptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BilgeHotel.MAP.Options
{
    public class UserProfileMap : BaseMap<UserProfile>
    {
        public UserProfileMap()
        {
            Property(x => x.UserName).HasColumnName("Kullanıcı Adı"); 
            Property(x => x.Password).HasColumnName("Şifre");
            Property(x => x.ActivationCode).HasColumnName("Aktivasyon Kodu");
            Property(x => x.Email).HasColumnName("Mail Adresi");
            Property(x => x.Role).HasColumnName("Kullanıcı Rolü");
        }
    }
    
}
