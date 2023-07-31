using BilgeHotel.BLL.Repositories.BaseRep;
using BilgeHotel.ENTITY.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BilgeHotel.BLL.Repositories.ConcRep
{
    public class HotelInfoAndImageRepository : BaseRepository<HotelInfoAndImage>
    {
        public override void Update(HotelInfoAndImage item)
        {
            item.Status = ENTITY.Enum.DataStatus.Updated;
            item.ModifiedDate = DateTime.Now;
            HotelInfoAndImage toBeUpdated = Find(item.HotelInfoID, item.ImageID);
            _db.Entry(toBeUpdated).CurrentValues.SetValues(item);
            Save();
        }
    }
}
