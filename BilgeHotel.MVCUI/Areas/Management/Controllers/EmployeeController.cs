using BilgeHotel.BLL.Repositories.ConcRep;
using BilgeHotel.COMMON.Tools;
using BilgeHotel.ENTITY.Entity;
using BilgeHotel.MVCUI.Areas.Management.Data.ViewModels.EmployeeVMs;
using BilgeHotel.MVCUI.Areas.Management.Data.ViewModels.PureVMs;
using BilgeHotel.MVCUI.AuthenticationClasses;
using BilgeHotel.MVCUI.Models.CustomTools;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BilgeHotel.MVCUI.Areas.Management.Controllers
{
    //[EmployeeAuthentication]
    public class EmployeeController : Controller
    {
        EmployeeRepository _empRep;
        JobRepository _jobRep;
        ImageRepository _imageRep;
        ShiftRepository _shiftRep;
        ImageRepository _imgRep;

        public EmployeeController()
        {
            _empRep = new EmployeeRepository();
            _jobRep = new JobRepository();
            _imageRep = new ImageRepository();
            _shiftRep = new ShiftRepository();
            _imgRep = new ImageRepository();
        }

        public ActionResult ListEmployee()
        {
            List<ShiftVM> shifts = _shiftRep.GetActives().Select(x => new ShiftVM
            {
                ShiftID = x.ID,
                ShiftInterval = x.ShiftInterval,
            }).ToList();

            List<ImageVM> images = _imageRep.GetActives().Select(x => new ImageVM
            {
                ImageID = x.ID,
                Description = x.Description,
                ImagePath = x.ImagePath,
            }).ToList();

            List<JobVM> jobs = _jobRep.GetActives().Select(x => new JobVM
            {
                JobID = x.ID,
                Name = x.Name,
            }).ToList();


            List<EmployeeVM> Emps = _empRep.GetActives().Select(x => new EmployeeVM
            {
                EmployeeID = x.ID,
                FirstName = x.FirstName,
                LastName = x.LastName,
                Address = x.Address,
                Email = x.Email,
                Password = x.Password,
                PhoneNumber = x.PhoneNumber,
                OffDay = x.OffDay,
                Salary = x.Salary,
                WagePerHour = x.WagePerHour,
                JobID = x.JobID,
                ImageID = x.ImageID,
                ShiftID = x.ShiftID,
                CreatedDate = x.CreatedDate,
                ModifiedDate = x.ModifiedDate,
                DeletedDate = x.DeletedDate,
                Status = x.Status,
            }).ToList();

            EmployeeListPageVMs guestPageVMs = new EmployeeListPageVMs()
            {
                EmployeeVMs = Emps,
                JobVMs = jobs,
                ShiftVMs = shifts,
                ImageVMs = images,
            };


            return View(guestPageVMs);
        }
        public ActionResult AddEmployee()
        {
            return EmployeeAdd();
        }

        private ActionResult EmployeeAdd()
        {
            List<ShiftVM> shifts = _shiftRep.GetActives().Select(x => new ShiftVM
            {
                ShiftID = x.ID,
                ShiftInterval = x.ShiftInterval
            }).ToList();

            List<ImageVM> images = _imageRep.GetActives().Select(x => new ImageVM
            {
                ImageID = x.ID,
                Description = x.Description,
                ImagePath = x.ImagePath,
            }).ToList();

            List<JobVM> jobs = _jobRep.GetActives().Select(x => new JobVM
            {
                JobID = x.ID,
                Name = x.Name,
            }).Where(x => x.JobID >= 2).ToList();

            EmployeeAddUpdatePageVM employeeAddUpdatePageVM = new EmployeeAddUpdatePageVM()
            {
                ImageVMs = images,
                JobVMs = jobs,
                ShiftVMs = shifts,

            };
            return View(employeeAddUpdatePageVM);
        }

        [HttpPost]
        public ActionResult AddEmployee(EmployeeVM employeeVM, HttpPostedFileBase images, string fileName)
        {
            //if (ModelState.IsValid)
            //{
            employeeVM.ImagePath = ImageUploader.UploadImage("/Pictures/", images, fileName);

            string password = PasswordCryptographer.Crypt(employeeVM.Password);
            string email = EmailCreator.CreateEmail(employeeVM.FirstName, employeeVM.LastName);

            Image image = new Image()
            {
                ImagePath = employeeVM.ImagePath,
            };
            _imgRep.Add(image);

            decimal? salary;
            var days = DateTime.DaysInMonth(DateTime.Now.Year, DateTime.Now.Month);

            if (employeeVM.JobID >= 6 && employeeVM.JobID < 10) //Yönetici olmayanlar ve Resepsiyonist olmayanlar
            {
                salary = employeeVM.WagePerHour * (days - 4) * 8;

                if (employeeVM.ShiftID >= 3)
                {
                    ViewBag.ErrorMessage = "Çalışan sectiğiniz vardiyada çalışamaz";
                    return RedirectToAction("AddEmployee");
                }
                else // vardiyası normal saatlar olanlar
                {
                    Employee employee = new Employee()
                    {
                        FirstName = employeeVM.FirstName,
                        LastName = employeeVM.LastName,
                        Address = employeeVM.Address,
                        Email = email,
                        ImageID = image.ID,
                        JobID = employeeVM.JobID,
                        OffDay = employeeVM.OffDay,
                        Password = password,
                        PhoneNumber = employeeVM.PhoneNumber,
                        Salary = salary,
                        ShiftID = employeeVM.ShiftID,
                        WagePerHour = employeeVM.WagePerHour,

                    };
                    _empRep.Add(employee);
                    return RedirectToAction("ListEmployee");
                }

            }

            else if (employeeVM.JobID == 5) // Resepsiyonistse
            {
                salary = employeeVM.WagePerHour * (days - 4) * 8;

                if (employeeVM.ShiftID != 4) //mesai aralığı doğru seçilmişse
                {
                    if (_empRep.GetReceptionists().Any(x => x.OffDay == employeeVM.OffDay))
                    {
                        ViewBag.OffDayError = "Bu izin gününe sahip resepsiyonist zaten mevcut!";
                        return EmployeeAdd();
                    }
                    else
                    {
                        Employee employee = new Employee()
                        {
                            FirstName = employeeVM.FirstName,
                            LastName = employeeVM.LastName,
                            Address = employeeVM.Address,
                            Email = email,
                            ImageID = image.ID,
                            JobID = employeeVM.JobID,
                            OffDay = employeeVM.OffDay,
                            Password = password,
                            PhoneNumber = employeeVM.PhoneNumber,
                            Salary = salary,
                            ShiftID = employeeVM.ShiftID,
                            WagePerHour = employeeVM.WagePerHour,

                        };

                        _empRep.Add(employee);
                        return RedirectToAction("ListEmployee");

                    }

                }
                else
                {
                    ViewBag.ShiftError = "Resepsiyonistler için bu vardiya seçilemez!";
                    return EmployeeAdd();
                }

            }

            else if (employeeVM.JobID >= 10) // IT VE Elektrikci ise 
            {
                salary = employeeVM.WagePerHour * (days - 8) * 10;

                if (employeeVM.ShiftID == 4) // IT ve Elektrikci vardiyasına uyanlar //HAFTADA 2 GÜN OFF
                {
                    Employee employee = new Employee()
                    {
                        FirstName = employeeVM.FirstName,
                        LastName = employeeVM.LastName,
                        Address = employeeVM.Address,
                        Email = email,
                        ImageID = image.ID,
                        JobID = employeeVM.JobID,
                        OffDay = employeeVM.OffDay,
                        Password = password,
                        PhoneNumber = employeeVM.PhoneNumber,
                        Salary = salary,
                        ShiftID = employeeVM.ShiftID,
                        WagePerHour = employeeVM.WagePerHour,

                    };
                    _empRep.Add(employee);
                    return RedirectToAction("ListEmployee");
                }
                else
                {
                    ViewBag.ErrorMessage = "Çalışan sectiğiniz vardiyada çalışamaz";
                    return RedirectToAction("AddEmployee");
                };
            }


            else // Yönetici olanlar HAFTADA 2 GÜN OFF
            {
                if (employeeVM.ShiftID <= 2) // Yöneticilerin çalışma saatleri
                {
                    Employee employee = new Employee()
                    {
                        FirstName = employeeVM.FirstName,
                        LastName = employeeVM.LastName,
                        Address = employeeVM.Address,
                        Email = email,
                        ImageID = image.ID,
                        JobID = employeeVM.JobID,
                        OffDay = employeeVM.OffDay,
                        Password = password,
                        PhoneNumber = employeeVM.PhoneNumber,
                        Salary = employeeVM.Salary,
                        ShiftID = employeeVM.ShiftID,
                        WagePerHour = null,

                    };
                    _empRep.Add(employee);
                    return RedirectToAction("ListEmployee");
                }
                else
                {
                    ViewBag.ErrorMessage = "Çalışan seçtiğiniz vardiyada çalışamaz";
                    return RedirectToAction("AddEmployee");
                }

            }

            //return RedirectToAction("ListEmployee");
            //}
            //else
            //{
            //    List<ShiftVM> shifts = _shiftRep.Select(x => new ShiftVM
            //    {
            //        ShiftID = x.ID,
            //        ShiftInterval = x.ShiftInterval
            //    }).ToList();

            //    List<ImageVM> imageVms = _imageRep.Select(x => new ImageVM
            //    {
            //        ImageID = x.ID,
            //        Description = x.Description,
            //        ImagePath = x.ImagePath,
            //    }).ToList();

            //    List<JobVM> jobs = _jobRep.Select(x => new JobVM
            //    {
            //        JobID = x.ID,
            //        Name = x.Name,
            //    }).ToList();

            //    EmployeeAddUpdatePageVM employeeAddUpdatePageVM = new EmployeeAddUpdatePageVM()
            //    {
            //        ImageVMs = imageVms,
            //        JobVMs = jobs,
            //        ShiftVMs = shifts,

            //    };
            //    return View(employeeAddUpdatePageVM);
            //}
        }


        public ActionResult UpdateEmployee(int id)
        {
            List<ShiftVM> shifts = _shiftRep.Select(x => new ShiftVM
            {
                ShiftID = x.ID,
                ShiftInterval = x.ShiftInterval
            }).ToList();

            List<ImageVM> images = _imageRep.Select(x => new ImageVM
            {
                ImageID = x.ID,
                Description = x.Description,
                ImagePath = x.ImagePath,
            }).ToList();

            List<JobVM> jobs = _jobRep.Select(x => new JobVM
            {
                JobID = x.ID,
                Name = x.Name,
            }).ToList();

            Employee secilen = _empRep.FirstOrDefault(x => x.ID == id);
            string password = PasswordCryptographer.DeCrypt(secilen.Password);

            EmployeeVM employeeVM = new EmployeeVM()
            {
                EmployeeID = id,
                FirstName = secilen.FirstName,
                LastName = secilen.LastName,
                Address = secilen.Address,
                Email = secilen.Email,
                ImageID = secilen.ImageID,
                JobID = secilen.JobID,
                OffDay = secilen.OffDay,
                Password = password,
                PhoneNumber = secilen.PhoneNumber,
                Salary = secilen.Salary,
                ShiftID = secilen.ShiftID,
                WagePerHour = secilen.WagePerHour,
            };

            EmployeeAddUpdatePageVM pageVM = new EmployeeAddUpdatePageVM()
            {
                EmployeeVM = employeeVM,
                ImageVMs = images,
                JobVMs = jobs,
                ShiftVMs = shifts,
            };

            return View(pageVM);
        }

        [HttpPost]
        public ActionResult UpdateEmployee(EmployeeVM employeeVM, HttpPostedFileBase httpImages, string fileName)
        {
            if (ModelState.IsValid)
            {
                Employee secilen = _empRep.FirstOrDefault(x => x.ID == employeeVM.EmployeeID);
                string password = PasswordCryptographer.Crypt(employeeVM.Password);
                string email = EmailCreator.CreateEmail(employeeVM.FirstName, employeeVM.LastName);
                employeeVM.ImagePath = ImageUploader.UploadImage("/Pictures/", httpImages, fileName);

                List<ImageVM> images = _imageRep.Select(x => new ImageVM
                {
                    ImageID = x.ID,
                    Description = x.Description,
                    ImagePath = x.ImagePath,
                }).ToList();

                Image photo = new Image()
                {
                    ImagePath = employeeVM.ImagePath,
                };
                _imageRep.Add(photo);


                if (employeeVM.JobID >= 6 && employeeVM.JobID < 10) // Yönetici olmayanlar ve Resepsiyonist olmayan
                {
                    if (employeeVM.ShiftID >= 3)
                    {
                        ViewBag.ErrorMessage = "Çalışan sectiğiniz vardiyada çalışamaz";
                        return RedirectToAction("UpdateEmployee");
                    }
                    else // vardiyası normal saatlar olanlar
                    {
                        secilen.FirstName = employeeVM.FirstName;
                        secilen.LastName = employeeVM.LastName;
                        secilen.Email = email;
                        secilen.PhoneNumber = employeeVM.PhoneNumber;
                        secilen.Address = employeeVM.Address;
                        secilen.Password = password;
                        secilen.OffDay = employeeVM.OffDay;
                        secilen.Salary = employeeVM.Salary;
                        secilen.WagePerHour = employeeVM.WagePerHour;
                        secilen.ShiftID = employeeVM.ShiftID;
                        secilen.JobID = employeeVM.JobID;
                        secilen.ImageID = photo.ID;
                        _empRep.Update(secilen);
                        return RedirectToAction("ListEmployee");
                    }

                }

                else if (employeeVM.JobID == 5) // Resepsiyonistler
                {
                    if (employeeVM.ShiftID != 4) // Vardiyası resepsiyonist vardiyalarına uyansa
                    {
                        if (_empRep.GetReceptionists().Any(x => x.OffDay == employeeVM.OffDay)) //Bu vardiyada çalışan bir receps var mı?
                        {
                            if (secilen.OffDay == employeeVM.OffDay) //Varsa seçilenle aynı kişi mi?
                            {
                                secilen.FirstName = employeeVM.FirstName;
                                secilen.LastName = employeeVM.LastName;
                                secilen.Email = email;
                                secilen.PhoneNumber = employeeVM.PhoneNumber;
                                secilen.Address = employeeVM.Address;
                                secilen.Password = password;
                                secilen.OffDay = employeeVM.OffDay;
                                secilen.Salary = employeeVM.Salary;
                                secilen.WagePerHour = employeeVM.WagePerHour;
                                secilen.ShiftID = employeeVM.ShiftID;
                                secilen.JobID = employeeVM.JobID;
                                secilen.ImageID = photo.ID;
                                _empRep.Update(secilen);
                                return RedirectToAction("ListEmployee");
                            }
                            else
                            {
                                //ViewBag.OffDayError = "Bu izin gününe sahip bir çalışan mevcut!";
                                TempData["OffDayError"] = "Bu izin gününe sahip bir çalışan mevcut!";
                                return RedirectToAction("UpdateEmployee");
                            }
                        }
                        else
                        {
                            secilen.FirstName = employeeVM.FirstName;
                            secilen.LastName = employeeVM.LastName;
                            secilen.Email = email;
                            secilen.PhoneNumber = employeeVM.PhoneNumber;
                            secilen.Address = employeeVM.Address;
                            secilen.Password = password;
                            secilen.OffDay = employeeVM.OffDay;
                            secilen.Salary = employeeVM.Salary;
                            secilen.WagePerHour = employeeVM.WagePerHour;
                            secilen.ShiftID = employeeVM.ShiftID;
                            secilen.JobID = employeeVM.JobID;
                            secilen.ImageID = photo.ID;
                            _empRep.Update(secilen);
                            return RedirectToAction("ListEmployee");
                        }
                    }
                    else
                    {
                        
                        TempData["ShiftError"] = "Bu çalışan seçtiğiniz vardiyada çalışamaz!";
                        return RedirectToAction("UpdateEmployee");
                    };

                }
 
                #region erva
                //else if (employeeVM.JobID == 5) //Resepsiyonistler
                //{
                //    if (employeeVM.ShiftID != 4) //Vardiyası resepsiyonist vardiyalarına uyansa
                //    {
                //        if (_empRep.GetReceptionists().Any(x => x.OffDay == employeeVM.OffDay)) // Bu izin gününe sahip bir resepsiyonist var mı?
                //        {
                //            if(secilen.OffDay == employeeVM.OffDay) //Varsa bu aynı kişi mi?
                //            {
                //                secilen.FirstName = employeeVM.FirstName;
                //                secilen.LastName = employeeVM.LastName;
                //                secilen.Email = email;
                //                secilen.PhoneNumber = employeeVM.PhoneNumber;
                //                secilen.Address = employeeVM.Address;
                //                secilen.Password = password;
                //                secilen.OffDay = employeeVM.OffDay;
                //                secilen.Salary = employeeVM.Salary;
                //                secilen.WagePerHour = employeeVM.WagePerHour;
                //                secilen.ShiftID = employeeVM.ShiftID;
                //                secilen.JobID = employeeVM.JobID;
                //                secilen.ImageID = photo.ID;
                //                _empRep.Update(secilen);
                //                return RedirectToAction("ListEmployee");
                //            }
                //            else
                //            {
                //                ViewBag.OffDayError = "Bu izin gününe sahip resepsiyonist zaten mevcut!";
                //                return EmployeeAdd();
                //            }

                //        }

                //        ViewBag.ErrorMessage = "Bu çalışan seçtiğiniz vardiyada çalışamaz!";
                //        return RedirectToAction("UpdateEmployee");

                //    }
                //    else
                //    {
                //        ViewBag.ErrorMessage = "Bu çalışan seçtiğiniz vardiyada çalışamaz!";
                //        return RedirectToAction("UpdateEmployee");
                //    };

                //}
                #endregion



                else if (employeeVM.JobID >= 10) // IT VE Elektrikci ise
                {
                    if (employeeVM.ShiftID == 4) // IT ve Elektrikci vardiyasına uyanlar
                    {
                        secilen.FirstName = employeeVM.FirstName;
                        secilen.LastName = employeeVM.LastName;
                        secilen.Email = email;
                        secilen.PhoneNumber = employeeVM.PhoneNumber;
                        secilen.Address = employeeVM.Address;
                        secilen.Password = password;
                        secilen.OffDay = employeeVM.OffDay;
                        secilen.Salary = employeeVM.Salary;
                        secilen.WagePerHour = employeeVM.WagePerHour;
                        secilen.ShiftID = employeeVM.ShiftID;
                        secilen.JobID = employeeVM.JobID;
                        secilen.ImageID = photo.ID;
                        _empRep.Update(secilen);
                        return RedirectToAction("ListEmployee");
                    }
                    else
                    {
                        ViewBag.ErrorMessage = "Çalışan sectiğiniz vardiyada çalışamaz";
                        return RedirectToAction("UpdateEmployee");
                    };
                }


                else // Yönetici olanlar
                {
                    if (employeeVM.ShiftID <= 2) // Yöneticilerin çalışma saatleri
                    {
                        secilen.FirstName = employeeVM.FirstName;
                        secilen.LastName = employeeVM.LastName;
                        secilen.Email = email;
                        secilen.PhoneNumber = employeeVM.PhoneNumber;
                        secilen.Address = employeeVM.Address;
                        secilen.Password = password;
                        secilen.OffDay = employeeVM.OffDay;
                        secilen.Salary = employeeVM.Salary;
                        secilen.WagePerHour = employeeVM.WagePerHour;
                        secilen.ShiftID = employeeVM.ShiftID;
                        secilen.JobID = employeeVM.JobID;
                        secilen.ImageID = photo.ID;
                        _empRep.Update(secilen);
                        return RedirectToAction("ListEmployee");
                    }
                    else
                    {
                        ViewBag.ErrorMessage = "Çalışan sectiğiniz vardiyada çalışamaz";
                        return RedirectToAction("UpdateEmployee");
                    }

                }

            }

            else // ModelState Valid değilse
            {
                List<ShiftVM> shifts = _shiftRep.Select(x => new ShiftVM
                {
                    ShiftID = x.ID,
                    ShiftInterval = x.ShiftInterval
                }).ToList();

                List<ImageVM> images = _imageRep.Select(x => new ImageVM
                {
                    ImageID = x.ID,
                    Description = x.Description,
                    ImagePath = x.ImagePath,
                }).ToList();

                List<JobVM> jobs = _jobRep.Select(x => new JobVM
                {
                    JobID = x.ID,
                    Name = x.Name,
                }).ToList();

                Employee secilen = _empRep.FirstOrDefault(x => x.ID == employeeVM.EmployeeID);
                string password = PasswordCryptographer.DeCrypt(secilen.Password);

                EmployeeVM employeeVm = new EmployeeVM()
                {
                    EmployeeID = employeeVM.EmployeeID,
                    FirstName = secilen.FirstName,
                    LastName = secilen.LastName,
                    Address = secilen.Address,
                    Email = secilen.Email,
                    ImageID = secilen.ImageID,
                    JobID = secilen.JobID,
                    OffDay = secilen.OffDay,
                    Password = password,
                    PhoneNumber = secilen.PhoneNumber,
                    Salary = secilen.Salary,
                    ShiftID = secilen.ShiftID,
                    WagePerHour = secilen.WagePerHour,
                };

                EmployeeAddUpdatePageVM pageVM = new EmployeeAddUpdatePageVM()
                {
                    EmployeeVM = employeeVm,
                    ImageVMs = images,
                    JobVMs = jobs,
                    ShiftVMs = shifts,
                };

                return View(pageVM);
            }

        }

        public ActionResult DeleteEmployee(int id)
        {
            _empRep.Delete(_empRep.Find(id));
            return RedirectToAction("ListEmployee");
        }

        public ActionResult AddExtraShift(int id)
        {
            return View();
        }
    }
}