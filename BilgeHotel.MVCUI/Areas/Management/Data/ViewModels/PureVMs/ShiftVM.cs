using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BilgeHotel.MVCUI.Areas.Management.Data.ViewModels.PureVMs
{
    public class ShiftVM
    {
        public int ShiftID { get; set; }
        public string ShiftInterval { get; set; }
        public int DailyWorkingHour { get; set; }
    }
    
}