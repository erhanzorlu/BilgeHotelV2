using BilgeHotel.ENTITY.Base;
using BilgeHotel.ENTITY.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BilgeHotel.ENTITY.Entity
{
    public class Employee : BaseEntity
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Address { get; set; }
        public string PhoneNumber { get; set; }
        public WeekDays OffDay { get; set; }

        //public int WorkingDayCount { get; set; }
        public decimal? Salary { get; set; }
        public decimal? WagePerHour { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public int? JobID { get; set; }
        public int? ShiftID { get; set; }
        public int? ImageID { get; set; }

        //Relational Props
        public Shift Shift { get; set; }
        public virtual List<ExtraShift> ExtraShifts { get; set; }
        public Job Job { get; set; }
        public Image Image { get; set; }

        
    }


}
    

