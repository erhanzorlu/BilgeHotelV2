using BilgeHotel.BLL.Repositories.ConcRep;
using BilgeHotel.COMMON.Tools;
using BilgeHotel.DAL.Context;
using BilgeHotel.ENTITY.Entity;
using BilgeHotel.MVCUI.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BilgeHotel.MVCUI.Controllers
{
    public class RegisterController : Controller
    {
       
        AppUserRepository _apRep;
        UserProfileRepository _proRep;

        public RegisterController()
        {
            _apRep = new AppUserRepository();
            _proRep = new UserProfileRepository();
        }

        public ActionResult RegisterNow()
        {
            
            return View();
        }

        [HttpPost]
        public ActionResult RegisterNow(RegisterVM rv)
        {
            if (ModelState.IsValid)
            {
                if (_apRep.Any(x => x.IdentificationNumber == rv.IdentificationNumber))
                {
                    ViewBag.ZatenVar = "Bu kimlik numarasına sahip kullanıcı zaten kayıtlı!";
                    return View();
                }
                else if (_proRep.Any(x => x.UserName == rv.UserName))
                {
                    ViewBag.ZatenVar = "Bu kullanıcı adı daha önce alınmış!";
                    return View();
                }
                else if (_proRep.Any(x => x.Email == rv.Email))
                {
                    ViewBag.ZatenVar = "Bu email adresi zaten kayıtlı!";
                    return View();
                }

                rv.Password = PasswordCryptographer.Crypt(rv.Password);

                if (!string.IsNullOrEmpty(rv.FirstName.Trim()) || !string.IsNullOrEmpty(rv.LastName.Trim()))
                {
                    AppUser appUser = new AppUser
                    {
                        FirstName = rv.FirstName,
                        LastName = rv.LastName,
                        IdentificationNumber = rv.IdentificationNumber
                    };

                    _apRep.Add(appUser);

                    UserProfile userProfile = new UserProfile
                    {
                        ID = appUser.ID,
                        Email = rv.Email,
                        UserName = rv.UserName,
                        Password = rv.Password
                        
                    };

                    _proRep.Add(userProfile);

                    string confirmationMail = $"Tebrikler hesabınız başarıyla oluşturulmuştur...Hesabınızı aktive etmek icin http://localhost:61894/Register/Activation/{userProfile.ActivationCode} linkine tıklayabilirsiniz";

                    EmailService.Send(rv.Email, body: confirmationMail, subject: "Hesap Aktivasyonu");

                }
                return RedirectToAction("Index", "Home");
            }

            return View();
            
        }


        public ActionResult Activation(Guid id)
        {
            UserProfile willBeActivated = _proRep.FirstOrDefault(x => x.ActivationCode == id);
            if (willBeActivated != null)
            {
                willBeActivated.Role = ENTITY.Enum.UserRole.Member;
                _proRep.Update(willBeActivated);
                TempData["HesapAktifMi"] = "Hesabınız aktif hale getirildi";
                return RedirectToAction("Login", "Home");
            }

            //Süpheli bir aktivite
            TempData["HesapAktifMi"] = "Hesabınız bulunamadı";
            return RedirectToAction("Login", "Home");
        }
    }
}