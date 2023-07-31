using BilgeHotel.ENTITY.Entity;
using BilgeHotel.MAP.BaseOptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BilgeHotel.MAP.Options
{
    public class ReservationMap : BaseMap<Reservation>
    {
        public ReservationMap()
        {
            Property(x => x.CheckInDate).HasColumnName("Giriş Tarihi");
            Property(x => x.CheckOutDate).HasColumnName("Çıkış Tarihi");
            Property(x => x.AdultCount).HasColumnName("Yetişkin Sayısı");
            Property(x => x.ChildrenCount).HasColumnName("Çocuk Sayısı");
            Property(x => x.TotalPrice).HasColumnName("Ödeme Tutarı");
            Property(x => x.Type).HasColumnName("Tip");
            Property(x => x.CampaignID).HasColumnName("Kampanya");
            Property(x => x.AppUserID).HasColumnName("Müşteri");


        }
    }
}
