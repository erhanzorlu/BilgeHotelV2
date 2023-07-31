using BilgeHotel.BLL.Repositories.ConcRep;
using BilgeHotel.ENTITY.Entity;
using BilgeHotel.MVCUI.Areas.Management.Data.ViewModels.ExtraShiftVMs;
using BilgeHotel.MVCUI.Areas.Management.Data.ViewModels.PureVMs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using static System.Data.Entity.Infrastructure.Design.Executor;

namespace BilgeHotel.MVCUI.Areas.Management.Controllers
{
    public class ExtraShiftController : Controller
    {
        EmployeeRepository _empRep;
        ExtraShiftRepository _extraShiftRep;
        public ExtraShiftController()
        {
            _empRep = new EmployeeRepository();
            _extraShiftRep = new ExtraShiftRepository();
        }
        // GET: Management/Shift
        public ActionResult ListExtraShifts()
        {
            var extras = _extraShiftRep.Select(x => new ExtraShiftVM
            {
                ExtraShiftID = x.ID,
                ShiftWagePerHour = x.ShiftWagePerHour,
                HowManyHours = x.HowManyHours,
                TotalWage = x.TotalWage,
                ExtraShiftDate = x.ExtraShiftDate,
                EmployeeID = x.EmployeeID,
                CreatedDate = x.CreatedDate,
                DeletedDate = x.DeletedDate,
                ModifiedDate = x.ModifiedDate,
                Status = x.Status

            }).ToList();

            var emps = _empRep.Select(x => new EmployeeVM
            {
                EmployeeID = x.ID,
                FirstName = x.FirstName,
                LastName = x.LastName,
                WagePerHour = x.WagePerHour

            }).ToList();

            ExtraShiftListPageVM model = new ExtraShiftListPageVM()
            {
                EmployeeVMs = emps,
                ShiftVMs = extras
            };

            return View(model);

        }

        #region Eski
        //public ActionResult AddExtraShift(int id)
        //{
        //    var emps = _empRep.GetActives().Select(x => new EmployeeVM
        //    {
        //        EmployeeID = x.ID,
        //        FirstName = x.FirstName,
        //        LastName = x.LastName,
        //        WagePerHour = x.WagePerHour

        //    }).FirstOrDefault(x => x.EmployeeID == id);

        //    ExtraShiftVM extraShiftVM = new ExtraShiftVM();

        //    var model = new ExtraShiftAddUpdateVM()
        //    {
        //        Employee = emps,
        //        ExtraShift = extraShiftVM

        //    };

        //    return View(model);
        //}

        //[HttpPost]
        //public ActionResult AddExtraShift(ExtraShiftVM extraShiftVM, DateTime extraShiftDate)
        //{
        //    decimal total = extraShiftVM.HowManyHours * extraShiftVM.Percent * extraShiftVM.ShiftWagePerHour;

        //    ExtraShift extraShift = new ExtraShift()
        //    {
        //        EmployeeID = extraShiftVM.EmployeeID,
        //        ExtraShiftDate = extraShiftDate.Date,
        //        HowManyHours = extraShiftVM.HowManyHours,
        //        ShiftWagePerHour = extraShiftVM.ShiftWagePerHour,
        //        TotalWage = total
        //    };

        //    _extraShiftRep.Add(extraShift);

        //    return RedirectToAction("ListExtraShifts");
        //}
        #endregion

        public ActionResult AddExtraShift(int id)
        {
            EmployeeVM emps = _empRep.GetActives().Select(x => new EmployeeVM
            {
                EmployeeID = x.ID,
                FirstName = x.FirstName,
                LastName = x.LastName,
                WagePerHour = x.WagePerHour

            }).FirstOrDefault(x => x.EmployeeID == id);

            ExtraShiftVM extraShiftVM = new ExtraShiftVM()
            {
                EmployeeID = emps.EmployeeID,
            };

            ExtraShiftAddUpdateVM extraShift = new ExtraShiftAddUpdateVM()
            {
                Employee = emps,
                ExtraShift = extraShiftVM

            };

            return View(extraShift);
        }

        [HttpPost]
        public ActionResult AddExtraShift(ExtraShiftVM extraShift)
        {
            if (ModelState.IsValid)
            {
                TimeSpan validateDays = TimeSpan.FromDays(1);

                //if (extraShiftDate == DateTime.Now.Date)
                //{
                decimal total = extraShift.HowManyHours * extraShift.ShiftWagePerHour;
                ExtraShift extraShifts = new ExtraShift()
                {
                    EmployeeID = extraShift.EmployeeID,
                    ExtraShiftDate = DateTime.Now.Date,
                    HowManyHours = extraShift.HowManyHours,
                    ShiftWagePerHour = extraShift.ShiftWagePerHour,
                    TotalWage = total
                };

                _extraShiftRep.Add(extraShifts);

                Employee emp = _empRep.GetActives().FirstOrDefault(x => x.ID == extraShift.EmployeeID);
                emp.Salary += total;
                _empRep.Update(emp);

                return RedirectToAction("ListExtraShifts");
                //}
                //else
                //{
                //    ViewBag.Error = "Lütfen uygun tarih seçimi yapınız!";
                //    return ExtraShiftAdd(extraShift);
                //}

            }
            else
            {
                return ExtraShiftAdd(extraShift);
            }

        }

        private ActionResult ExtraShiftAdd(ExtraShiftVM extraShift)
        {
            EmployeeVM emps = _empRep.GetActives().Select(x => new EmployeeVM
            {
                EmployeeID = x.ID,
                FirstName = x.FirstName,
                LastName = x.LastName,
                WagePerHour = x.WagePerHour

            }).FirstOrDefault(x => x.EmployeeID == extraShift.EmployeeID);

            ExtraShiftVM extraShiftVM = new ExtraShiftVM()
            {
                EmployeeID = emps.EmployeeID,
                ShiftWagePerHour = emps.WagePerHour.Value
            };

            ExtraShiftAddUpdateVM extraShiftX = new ExtraShiftAddUpdateVM()
            {
                Employee = emps,
                ExtraShift = extraShiftVM

            };

            return View(extraShiftX);
        }

        public ActionResult UpdateExtraShift(int id)
        {
            ExtraShift updated = _extraShiftRep.Find(id);

            ExtraShiftVM xsvm = new ExtraShiftVM()
            {
                ShiftWagePerHour = updated.ShiftWagePerHour,
                ExtraShiftDate = updated.ExtraShiftDate,
                HowManyHours = updated.HowManyHours,
                ExtraShiftID = updated.ID,
                EmployeeID = updated.EmployeeID,
                TotalWage = updated.TotalWage,
                Status = updated.Status

            };

            //List<EmployeeVM> emps = _empRep.GetActives().Select(x => new EmployeeVM
            //{
            //    EmployeeID = x.ID,
            //    FirstName = x.FirstName,
            //    LastName = x.LastName,
            //    WagePerHour =x.WagePerHour
            //}).ToList();

            Employee theOne = _empRep.FirstOrDefault(x => x.ID == xsvm.EmployeeID);

            EmployeeVM evm = new EmployeeVM()
            {
                FirstName = theOne.FirstName,
                LastName = theOne.LastName,
                WagePerHour = theOne.WagePerHour,
                EmployeeID = theOne.ID

            };

            ExtraShiftAddUpdateVM model = new ExtraShiftAddUpdateVM()
            {
                ExtraShift = xsvm,
                Employee = evm
            };

            return View(model);
        }

        [HttpPost]
        public ActionResult UpdateExtraShift(ExtraShiftVM extraShift)
        {
            if (ModelState.IsValid)
            {
                decimal newTotal = extraShift.HowManyHours * extraShift.ShiftWagePerHour;

                ExtraShift old = _extraShiftRep.FirstOrDefault(x => x.ID == extraShift.ExtraShiftID); //GÜNCELLENMESİ GEREKEN
                decimal oldTotal = old.ShiftWagePerHour * old.HowManyHours;

                old.HowManyHours = extraShift.HowManyHours;
                old.ShiftWagePerHour = extraShift.ShiftWagePerHour;
                //old.EmployeeID = extraShift.EmployeeID;
                old.TotalWage = newTotal;

                _extraShiftRep.Update(old);

                Employee emp = _empRep.GetActives().FirstOrDefault(x => x.ID == extraShift.EmployeeID);
                if (extraShift.Status == ENTITY.Enum.DataStatus.Deleted)
                {
                    emp.Salary += newTotal;
                }
                else
                {
                    emp.Salary += (newTotal - oldTotal);
                }

                _empRep.Update(emp);
                TempData["Success"] = "İşlem başarılı!";
                return RedirectToAction("ListExtraShifts");

            }
            else
            {
                ExtraShift updated = _extraShiftRep.Find(extraShift.ExtraShiftID);

                ExtraShiftVM xsvm = new ExtraShiftVM()
                {
                    ShiftWagePerHour = updated.ShiftWagePerHour,
                    ExtraShiftDate = updated.ExtraShiftDate,
                    HowManyHours = updated.HowManyHours,
                    ExtraShiftID = updated.ID,
                    EmployeeID = updated.EmployeeID,
                    TotalWage = updated.TotalWage

                };

                List<EmployeeVM> emps = _empRep.GetActives().Select(x => new EmployeeVM
                {
                    FirstName = x.FirstName,
                    LastName = x.LastName
                }).ToList();

                ExtraShiftAddUpdateVM model = new ExtraShiftAddUpdateVM()
                {
                    ExtraShift = xsvm,
                    EmployeeVMs = emps
                };

                //ViewBag.Error = "Lütfen bir tarih seçiniz!";

                return View(model);
            }

        }

        public ActionResult DeleteExtraShift(int id)
        {
            ExtraShift deleted = _extraShiftRep.FirstOrDefault(x => x.ID == id);
            _extraShiftRep.Delete(deleted);

            Employee emp = _empRep.GetActives().FirstOrDefault(x => x.ID == deleted.EmployeeID);
            emp.Salary -= deleted.TotalWage;
            _empRep.Update(emp);
            return RedirectToAction("ListExtraShifts");
        }



    }
}