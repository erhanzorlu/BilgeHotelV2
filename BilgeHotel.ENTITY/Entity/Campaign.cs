using BilgeHotel.ENTITY.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BilgeHotel.ENTITY.Entity
{
    public class Campaign : BaseEntity
    {

        public decimal DiscountPercentage { get; set; }

        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }


        //Relational Props

        public virtual List<Reservation> Reservations { get; set; }
    }
}
