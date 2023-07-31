using BilgeHotel.BLL.Repositories.BaseRep;
using BilgeHotel.BLL.Repositories.IntRep;
using BilgeHotel.ENTITY.Entity;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Core.Metadata.Edm;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace BilgeHotel.BLL.Repositories.ConcRep
{
    public class RoomRepository : BaseRepository<Room>, IRoomRepository
    {

        public void ChangeRoomStatusToRenovation(Room room)
        {
            var r = _db.Rooms.FirstOrDefault(x => x.ID == room.ID);
            r.RoomStatus = ENTITY.Enum.RoomStatus.Renovation;
            r.ModifiedDate = DateTime.Now;
            Save();
        }

        public List<Room> GetAvailableRooms()
        {
            var rooms = _db.Rooms.Where(x => x.RoomStatus == ENTITY.Enum.RoomStatus.Available && x.Status != ENTITY.Enum.DataStatus.Deleted).ToList();
            return rooms;
        }
        public List<Room> GetRoomsForReservation(List<int> reservedRoomIDs, int personCount)
        {
            List<Room> availableRooms = new List<Room>();
            foreach (var item in GetAvailableRooms())
            {
                if(!reservedRoomIDs.Contains(item.ID) && item.Capacity >= personCount)
                {
                    availableRooms.Add(item);
                }
                else if(reservedRoomIDs.Count == GetAvailableRooms().Count)
                {
                    return availableRooms;
                }
            }
            return availableRooms;

            
        }

        //public List<Room> GetRoomsForReservation(List<int> ids)
        //{
        //    List<Room> availableRooms = new List<Room>();

        //    foreach (var item in GetAvailableRooms())
        //    {
        //        if (!ids.Contains(item.ID))
        //        {
        //            availableRooms.Add(item);
        //        }
        //    }

        //    return availableRooms;

        //}

        public Room GetCapFourRoom()
        {
            var room = _db.Rooms.Where(x => x.Capacity == 4 && x.Status != ENTITY.Enum.DataStatus.Deleted && x.RoomStatus == ENTITY.Enum.RoomStatus.Available).Take(1).FirstOrDefault();

            return room;
        }

        public Room GetCapOneRoom()
        {
            var room = _db.Rooms.Where(x => x.Capacity == 1 && x.Status != ENTITY.Enum.DataStatus.Deleted && x.RoomStatus == ENTITY.Enum.RoomStatus.Available).Take(1).FirstOrDefault();

            return room;
        }

        public Room GetCapThreeRoom()
        {
            var room = _db.Rooms.Where(x => x.Capacity == 3 && x.Status != ENTITY.Enum.DataStatus.Deleted && x.RoomStatus == ENTITY.Enum.RoomStatus.Available).Take(1).FirstOrDefault();

            return room;
        }

        public Room GetCapTwoRoom()
        {
            var room = _db.Rooms.Where(x => x.Capacity == 2 && x.Status != ENTITY.Enum.DataStatus.Deleted && x.RoomStatus == ENTITY.Enum.RoomStatus.Available).Take(1).FirstOrDefault();

            return room;
        }

        public Room GetKingSuit()
        {
            var room = _db.Rooms.Where(x => x.RoomType == ENTITY.Enum.RoomType.KingSuit).FirstOrDefault();
            return room;
        }



        public List<Reservation> NotifyForEndingReservations(Reservation reservation)
        {
            var reservs = _db.Reservations.Where(x => Convert.ToInt32(reservation.CheckOutDate - DateTime.Now) <= 24).ToList();
            return reservs;
        }

    }
}
