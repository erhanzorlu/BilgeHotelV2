using BilgeHotel.ENTITY.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BilgeHotel.BLL.Repositories.IntRep
{
    public interface IReservationRepository
    {
        //decimal CalculateTotalPrice(RoomAndReservation ra);

        // GECELİK ÜCRET * (ÇIKIŞ - GİRİŞ)

        List<Reservation> GetOnlineReservations(DateTime checkIn, DateTime checkOut);
        List<Reservation> GetAllReservations(DateTime checkIn, DateTime checkOut);
        List<Reservation> GetPhoneReservations(DateTime checkIn, DateTime checkOut);
        int[] GetReservationIDs(List<Reservation> reservations);

        void SetTimes(ref DateTime checkIn, ref DateTime checkOut);

        List<Reservation> ListEndedReservations();
    }
}
