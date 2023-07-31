using BilgeHotel.BLL.Repositories.ConcRep;
using BilgeHotel.COMMON.Tools;
using BilgeHotel.ENTITY.Entity;
using BilgeHotel.MVCUI.Areas.Management.Data.ViewModels.EmployeeVMs;
using BilgeHotel.MVCUI.Areas.Management.Data.ViewModels.PureVMs;
using BilgeHotel.MVCUI.AuthenticationClasses;
using BilgeHotel.MVCUI.Models.CustomTools;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Helpers;
using System.Web.Mvc;

namespace BilgeHotel.MVCUI.Areas.Management.Controllers
{

    public class ManagerController : Controller
    {
        // GET: Management/Manager

        public ActionResult Index()
        {
            return View();
        }

        
    }
}