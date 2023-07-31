using BilgeHotel.ENTITY.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BilgeHotel.ENTITY.Entity
{
    public class Guest : BaseEntity
    {
        public Guest()
        {
            RoomAndReservations = new List<RoomAndReservation>();
        }
        public string IdentificationNumber { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }

        //Relational Props

        public virtual List<RoomAndReservation> RoomAndReservations { get; set; }
    }
}
