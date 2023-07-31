using BilgeHotel.ENTITY.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BilgeHotel.ENTITY.Entity
{
    public class ExtraShift : BaseEntity
    {
        public decimal ShiftWagePerHour { get; set; }
        public DateTime ExtraShiftDate { get; set; }
        public decimal HowManyHours { get; set; }
        public decimal TotalWage { get; set;}
        public int EmployeeID { get; set; }

        //Relational Props
        public Employee Employee { get; set; }


    }
}
