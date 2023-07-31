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
    public class GuestRepository : BaseRepository<Guest>, IGuestRepository
    {
        public List<Guest> GetGuestsForReservations(List<int> guestIDs)
        {
            List<Guest> guests = new List<Guest>();

            foreach (var item in GetActives())
            {
                if (guestIDs.Contains(item.ID))
                {
                    guests.Add(item);
                }
            }

            return guests;
        }
    }
}
