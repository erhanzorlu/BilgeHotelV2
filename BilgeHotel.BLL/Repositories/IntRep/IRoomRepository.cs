using BilgeHotel.ENTITY.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BilgeHotel.BLL.Repositories.IntRep
{
    public interface IRoomRepository
    {
        void ChangeRoomStatusToRenovation(Room room);

        List<Reservation> NotifyForEndingReservations(Reservation reservation);

        List<Room> GetAvailableRooms();
        List<Room> GetRoomsForReservation(List<int> reservedRoomIDs, int personCount);

        Room GetCapOneRoom();
        Room GetCapTwoRoom();
        Room GetCapThreeRoom();
        Room GetCapFourRoom();

        Room GetKingSuit();


    }
}
