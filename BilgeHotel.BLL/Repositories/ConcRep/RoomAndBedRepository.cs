using BilgeHotel.BLL.Repositories.BaseRep;
using BilgeHotel.ENTITY.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BilgeHotel.BLL.Repositories.ConcRep
{
    public class RoomAndBedRepository : BaseRepository<RoomAndBed>
    {
        public override void Update(RoomAndBed item)
        {
            item.Status = ENTITY.Enum.DataStatus.Updated;
            item.ModifiedDate = DateTime.Now;
            RoomAndBed toBeUpdated = Find(item.RoomID, item.BedID);
            _db.Entry(toBeUpdated).CurrentValues.SetValues(item);
            Save();
        }
    }
}
