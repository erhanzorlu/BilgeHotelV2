using BilgeHotel.MVCUI.Areas.Management.Data.ViewModels.PureVMs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BilgeHotel.MVCUI.Areas.Management.Data.ViewModels.EmployeeVMs
{
    public class EmployeeListPageVMs
    {
        public List<EmployeeVM> EmployeeVMs { get; set; }
        public List<JobVM> JobVMs { get; set; }
        public List<ImageVM> ImageVMs { get; set; }
        public List<ShiftVM> ShiftVMs { get; set; }

       
    }
}