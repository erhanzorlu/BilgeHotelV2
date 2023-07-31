using BilgeHotel.BLL.Repositories.BaseRep;
using BilgeHotel.BLL.Repositories.IntRep;
using BilgeHotel.ENTITY.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BilgeHotel.BLL.Repositories.ConcRep
{
    public class RoomAndImageRepository : BaseRepository<RoomAndImage>
    { 
        public override void Update(RoomAndImage item)
        {
            item.Status = ENTITY.Enum.DataStatus.Updated;
            item.ModifiedDate = DateTime.Now;
            RoomAndImage toBeUpdated = Find(item.RoomID, item.ImageID);
            _db.Entry(toBeUpdated).CurrentValues.SetValues(item);
            Save();
        }
    }
}
