using BilgeHotel.ENTITY.Entity;
using BilgeHotel.MAP.BaseOptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BilgeHotel.MAP.Options
{
    public class ImageMap: BaseMap<Image>
    {
        public ImageMap()
        {
            Property(x => x.ImagePath).HasColumnName("Fotoğraf Yolu");
        }
    }
}
