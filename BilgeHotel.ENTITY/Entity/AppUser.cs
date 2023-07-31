using BilgeHotel.ENTITY.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BilgeHotel.ENTITY.Entity
{
    public class AppUser:BaseEntity
    {
        public AppUser()
        {
            Reservations = new List<Reservation>();
            
        }
        public string IdentificationNumber { get; set; } //ARAYANLA ONLİNE MÜŞTERİYİ AYIRT EDİP DB'YE İKİ KEZ KAYDETMEMEK İÇİN
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PhoneNumber { get; set; }

        //Relational Properties
        public virtual UserProfile Profile { get; set; }

        public virtual List<Reservation> Reservations { get; set; }
    }
}
