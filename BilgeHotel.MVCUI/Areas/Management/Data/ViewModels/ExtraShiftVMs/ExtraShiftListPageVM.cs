using BilgeHotel.MVCUI.Areas.Management.Data.ViewModels.PureVMs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BilgeHotel.MVCUI.Areas.Management.Data.ViewModels.ExtraShiftVMs
{
    public class ExtraShiftListPageVM
    {
        public List<EmployeeVM> EmployeeVMs { get; set; }
        public List<ExtraShiftVM> ShiftVMs { get; set; }


    }
}