using BilgeHotel.ENTITY.Entity;
using BilgeHotel.MAP.BaseOptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BilgeHotel.MAP.Options
{
    public class CampaignMap : BaseMap<Campaign>
    {
        public CampaignMap()
        {
            Property(x => x.DiscountPercentage).HasColumnName("İndirim Yüzdesi");
            Property(x => x.StartDate).HasColumnName("Başlangıç Tarihi");
            Property(x => x.EndDate).HasColumnName("Bitiş Tarihi");
        }
    }
}
