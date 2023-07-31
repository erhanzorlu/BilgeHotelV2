using BilgeHotel.BLL.Repositories.BaseRep;
using BilgeHotel.BLL.Repositories.IntRep;
using BilgeHotel.ENTITY.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace BilgeHotel.BLL.Repositories.ConcRep
{
    public class ReservationRepository : BaseRepository<Reservation>, IReservationRepository
    {
        //public decimal CalculateTotalPrice(RoomAndReservation ra, int reservationId)
        //{
        //    var reservations = 
        //}

        public List<Reservation> GetOnlineReservations(DateTime checkIn, DateTime checkOut)
        {
            var actives = GetActives();
            SetTimes(ref checkIn, ref checkOut);
            if (actives != null)
            {
                List<Reservation> reservations = actives.Where(x => x.CheckInDate <= checkIn && x.CheckOutDate > checkIn && x.Type == ENTITY.Enum.ReservationType.Online || x.CheckInDate < checkOut && x.CheckOutDate >= checkOut && x.Type == ENTITY.Enum.ReservationType.Online || x.CheckInDate >= checkIn && x.CheckOutDate <= checkOut && x.Type == ENTITY.Enum.ReservationType.Online).ToList();
                return reservations;
            }
            else
            {
                return GetActives();
            }
            
        }

        public List<Reservation> GetPhoneReservations(DateTime checkIn, DateTime checkOut)
        {
            var actives = GetActives();
            SetTimes(ref checkIn, ref checkOut);
            if (actives != null)
            {
                List<Reservation> reservations = actives.Where(x => x.CheckInDate <= checkIn && x.CheckOutDate > checkIn && x.Type == ENTITY.Enum.ReservationType.ByPhone || x.CheckInDate < checkOut && x.CheckOutDate >= checkOut && x.Type == ENTITY.Enum.ReservationType.ByPhone || x.CheckInDate >= checkIn && x.CheckOutDate <= checkOut && x.Type == ENTITY.Enum.ReservationType.ByPhone).ToList();

                return reservations;
            }
            else
            {
                return GetActives();
            }

        }

        public List<Reservation> GetAllReservations(DateTime checkIn, DateTime checkOut)
        {
            var actives = GetActives();
            SetTimes(ref checkIn, ref checkOut);
            if (actives != null && actives.Count != 0)
            {

                List<Reservation> reservations = actives.Where(x => x.CheckInDate <= checkIn && x.CheckOutDate > checkIn || x.CheckInDate < checkOut && x.CheckOutDate >= checkOut || x.CheckInDate >= checkIn && x.CheckOutDate <= checkOut).ToList();

                //List<Reservation> reservations = actives.Where(x => x.CheckInDate <= checkIn && x.CheckOutDate >= checkOut).ToList();
                //List<Reservation> reservations2 = actives.Where(x => x.CheckInDate >= checkIn && x.CheckOutDate <= checkOut).ToList();
                //reservations.AddRange(reservations2);
                return reservations;
            }
            else
            {
                return GetActives();
            }
        }

        public int[] GetReservationIDs(List<Reservation> reservations)
        {
            int[] ids = new int[reservations.Count];
            for (int i = 0; i < reservations.Count; i++)
            {
                ids[i] = reservations[i].ID;
            }
            return ids;
        }

        //public int[] GetReservationIDs(List<Reservation> reservations)
        //{
        //    int[] IDs = new int[reservations.Count];

        //    for (int i = 0; i < reservations.Count; i++)
        //    {
        //        IDs[i] = reservations[i].ID;
        //    }
        //    return IDs;
        //}
        public void SetTimes( ref DateTime checkIn, ref DateTime checkOut)
        {
            checkIn = checkIn.AddHours(14);
            checkOut = checkOut.AddHours(10);
        }

        public List<Reservation> ListEndedReservations()
        {
            var ended = GetAll().Where(x => x.CheckOutDate.Date == DateTime.Today.Date).ToList();
            return ended;
        }
    }
}
