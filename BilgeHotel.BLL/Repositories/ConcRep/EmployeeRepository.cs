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
    public class EmployeeRepository : BaseRepository<Employee>, IEmployeeRepository
    {
        //public decimal CalculateSalary(Employee emp)
        //{
        //    if (emp.ExtraShifts != null)
        //    {
        //        var days = DateTime.DaysInMonth(DateTime.Now.Year, DateTime.Now.Month);
        //        emp.Salary = emp.WagePerHour * days
        //    }
        //}

        public List<Employee> GetReceptionists()
        {
            List<Employee> receps = _db.Employees.Where(x => x.Job.Name == "Resepsiyonist").ToList();
            return receps;
        }

        public decimal CalculateExtraShiftHourWage(Employee emp, decimal kacKati)
        {
            var whichEmp = _db.Employees.Find(emp.ID);
            
            decimal extraWage;
            if (whichEmp != null)
            {
                extraWage = (decimal)(emp.WagePerHour * kacKati);

                return extraWage;
            }

            return 0;
            
        }

        public void CalculateTotalExtraShiftWage(ExtraShift extraShift, decimal kacSaat)
        {
            if(extraShift.ShiftWagePerHour != 0)
            {
                extraShift.TotalWage = extraShift.ShiftWagePerHour * kacSaat;
            }
            else
            {
                extraShift.TotalWage = 0;
            }
            
            //extraShift.HowManyHours = kacSaat;
            
        }
    }
}
