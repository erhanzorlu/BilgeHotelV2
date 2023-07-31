using BilgeHotel.BLL.Repositories.BaseRep;
using BilgeHotel.BLL.Repositories.IntRep;
using BilgeHotel.ENTITY.Entity;
using BilgeHotel.ENTITY.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace BilgeHotel.BLL.Repositories.ConcRep
{
    public class RoomAndReservationRepository : BaseRepository<RoomAndReservation>, IRoomAndReservationRepository
    {

        public List<int> FindReservedRoomIDs(int[] reservationIDs)
        {
            //int[] roomIds = new int[(reservationIDs.Length) * 3];
            List<int> roomIds = new List<int>();
            var data = FindRangeForReservation(reservationIDs);

            foreach (var item in data)
            {
                roomIds.Add(item.RoomID);
            }

            return roomIds;
        }

        public List<int> FindReservedRoomIDsForOne(int reservationIDs)
        {
            //int[] roomIds = new int[(reservationIDs.Length) * 3];
            List<int> roomIds = new List<int>();
            var data = FindForReservation(reservationIDs);

            foreach (var item in data)
            {
                roomIds.Add(item.RoomID);
            }

            return roomIds;
        }

        public List<RoomAndReservation> FindRangeForReservation(int[] id)
        {
            List<RoomAndReservation> someData = _db.RoomAndReservations.Where(x => id.Contains(x.ReservationID)).ToList();
            return someData;

        }

        public List<RoomAndReservation> FindRangeForRoom(int[] id)
        {
            List<RoomAndReservation> someData = _db.RoomAndReservations.Where(x => id.Contains(x.RoomID)).ToList();
            return someData;
        }

        public List<RoomAndReservation> FindRangeForRoom(List<int> ids)
        {
            List<RoomAndReservation> someData = _db.RoomAndReservations.Where(x => ids.Contains(x.RoomID)).ToList();
            return someData;
        }

        public override void Update(RoomAndReservation item)
        {
            item.Status = ENTITY.Enum.DataStatus.Updated;
            item.ModifiedDate = DateTime.Now;
            RoomAndReservation toBeUpdated = Find(item.RoomID, item.ReservationID);
            _db.Entry(toBeUpdated).CurrentValues.SetValues(item);
            Save();
        }

        //public List<int> FindGuestIDs(List<int> roomIDs)
        //{
        //    List<int> guestIDs = new List<int>();
        //    var data = FindRangeForRoom(roomIDs);

        //    foreach (var item in data)
        //    {
        //        if(item.G)
        //        guestIDs.Add(item.RoomID);
        //    }

        //    return guestIDs;
        //}

        public List<RoomAndReservation> FindForReservation(int reservationId)
        {
            List<RoomAndReservation> someData = _db.RoomAndReservations.Where(x => x.ReservationID == reservationId).ToList();
            return someData;
        }

        public List<RoomAndReservation> FindForRoom(int roomId)
        {
            List<RoomAndReservation> someData = _db.RoomAndReservations.Where(x => x.RoomID == roomId).ToList();
            return someData;
        }
    }
}
