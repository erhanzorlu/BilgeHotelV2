using BilgeHotel.ENTITY.Base;
using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BilgeHotel.ENTITY.Entity
{
    public class Shift : BaseEntity
    {
        public string ShiftInterval { get; set; }
        //public int StartingHour { get; set; } //BUNLARIN DATA TİPİ İNT OLMAMALI NE OLMALI????!!!!
        //public int EndingHour { get; set; } 
        public int DailyWorkingHour { get; set; }

        //Relational Props

        public virtual List<Employee> Employees { get; set; }
    }

}
