using BilgeHotel.MVCUI.Areas.Management.Data.ViewModels.PureVMs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BilgeHotel.MVCUI.Areas.Management.Data.ViewModels.ExtraShiftVMs
{
    public class ExtraShiftAddUpdateVM
    {
        public EmployeeVM Employee { get; set; }
        public ExtraShiftVM ExtraShift { get; set; }
        public List<EmployeeVM> EmployeeVMs { get; set; }
    }
}