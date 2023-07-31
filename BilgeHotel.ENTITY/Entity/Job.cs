using BilgeHotel.ENTITY.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BilgeHotel.ENTITY.Entity
{
    public class Job : BaseEntity
    {
        public string Name { get; set; }

        //Relational Props

        public virtual List<Employee> Employees { get; set; }
    }

}
