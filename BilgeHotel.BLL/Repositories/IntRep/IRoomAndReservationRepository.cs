using BilgeHotel.ENTITY.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BilgeHotel.BLL.Repositories.IntRep
{
    public interface IRoomAndReservationRepository
    {

        List<int> FindReservedRoomIDs(int[] reservationIDs);

        List<RoomAndReservation> FindRangeForReservation(int[] id);
        List<RoomAndReservation> FindForReservation(int reservationId);
        List<RoomAndReservation> FindRangeForRoom(int[] id);
        List<int> FindReservedRoomIDsForOne(int reservationIDs);
        //List<Guest> FindGuests(List<int> roomIDs);
        List<RoomAndReservation> FindRangeForRoom(List<int> ids);
        List<RoomAndReservation> FindForRoom(int roomId);
        //List<int> FindGuestIDs(int[] reservationIDs);


    }

}
