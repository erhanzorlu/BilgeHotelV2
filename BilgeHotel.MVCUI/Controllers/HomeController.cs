using BilgeHotel.BLL.Repositories.ConcRep;
using BilgeHotel.COMMON.Tools;
using BilgeHotel.DAL.Context;
using BilgeHotel.ENTITY.Entity;
using BilgeHotel.MVCUI.Models.ViewModels;
using BilgeHotel.MVCUI.Models.ViewModels.PageVMs;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Web;
using System.Web.Mvc;

namespace BilgeHotel.MVCUI.Controllers
{

    public class HomeController : Controller
    {
        AppUserRepository _apRep;
        UserProfileRepository _proRep;
        RoomRepository _roomRep;
        //RoomAndImageRepository _roomAndImageRep;
        ImageRepository _imageRep;
        RoomFeatureRepository _featureRep;
        RoomAndImageRepository _roomAndImageRep;
        HotelInfoRepository _hotelInfoRep;
        EmployeeRepository _emp;

        public HomeController()
        {
            _apRep = new AppUserRepository();
            _proRep = new UserProfileRepository();
            _roomRep = new RoomRepository();
            _emp = new EmployeeRepository();
            //_roomAndImageRep = new RoomAndImageRepository();
            _imageRep = new ImageRepository();
            _featureRep = new RoomFeatureRepository();
            _roomAndImageRep = new RoomAndImageRepository();
            _hotelInfoRep = new HotelInfoRepository();
        }

        public ActionResult Index()
        {
            //Her kapasitedeki odadan 1 tane göstereceğiz.
            List<RoomFeatureVM> feature = _featureRep.GetActives().Select(x => new RoomFeatureVM
            {
                Description = x.Description,
                FeatureID = x.ID
            }).ToList();

            List<RoomVM> room = _roomRep.GetActives().Select(x => new RoomVM
            {
                RoomID = x.ID,
                Capacity = x.Capacity,
                FloorNumber = x.FloorNumber,
                PricePerNight = x.PricePerNight,
                FeatureID = x.RoomFeatureID

            }).ToList();

            List<RoomAndImageVM> roomAndImage = _roomAndImageRep.GetActives().Select(x => new RoomAndImageVM
            {
                ImageID = x.ImageID,
                RoomID = x.RoomID,
            }).ToList();

            List<ImageVM> images = _imageRep.GetActives().Select(x => new ImageVM
            {
                ImagePath = x.ImagePath,
                ImageID = x.ID,
                RoomAndImageVms = roomAndImage
            }).ToList();

            HotelInfoVM hotelInfos = _hotelInfoRep.GetActives().Select(x => new HotelInfoVM
            {
                Name = x.Name,
                Address = x.Address,
                Description = x.Description,

            }).FirstOrDefault();

            IndexVM indexVm = new IndexVM()
            {
                RoomFeaturesVm = feature,
                RoomsVm = room,
                RoomAndImagesVm = roomAndImage,
                ImagesVm = images,
                HotelInfosVm = hotelInfos
            };

            return View(indexVm);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult Login()
        {
            return View();

        }

        [HttpPost]
        public ActionResult Login(LoginVM lv)
        {
            #region alternatif algo
            //var kisix = _proRep.FirstOrDefault(x => x.Email == lv.Email && x.Role == ENTITY.Enum.UserRole.Member);
            //if (kisix == null)
            //{
            //    TempData["Message"] = "hatalı giriş mal";

            //    return View();
            //}
            //if (PasswordCryptographer.DeCrypt(kisix.Password) == null) ViewBag.Messsage = "Ağla";
            //string sifre = PasswordCryptographer.DeCrypt(kisix.Password);
            //var kisi = _proRep.FirstOrDefault(x => sifre == lv.Password);
            //if (kisi != null)
            //{
            //    return RedirectToAction("Index", "Home");
            //}
            //ViewBag.Message = "Kullanıcı bulunamadı";
            //return View();
            #endregion
            string passwordDecrypted;
            //deneme
            if (ModelState.IsValid)
            {
                UserProfile userProfile = _proRep.FirstOrDefault(x => x.Email == lv.Email && x.Role == ENTITY.Enum.UserRole.Member);
                Employee emp = _emp.FirstOrDefault(x => x.Email == lv.Email);

                if (userProfile != null) passwordDecrypted = PasswordCryptographer.DeCrypt(userProfile.Password);
                else if (emp != null) passwordDecrypted = PasswordCryptographer.DeCrypt(emp.Password);
                else
                {
                    ViewBag.LoginError = "Hesap bulunamadı, yeniden deneyin ya da kaydolun!";
                    return View();
                }

                if (userProfile != null && passwordDecrypted == lv.Password && userProfile.Role == ENTITY.Enum.UserRole.Member)
                {
                    //AppUser için session eklenecek
                    AppUser appUser = _apRep.FirstOrDefault(x => x.ID == userProfile.ID);

                    Session["UserAuth"] = appUser.ID;
                    Session["UserFullName"] = appUser.FirstName + " " + appUser.LastName;

                    return RedirectToAction("Index");
                }
                else if (emp != null && passwordDecrypted == lv.Password)
                {
                    Session["Auth"] = (int)emp.JobID;
                    return Redirect("/Management/Manager/Index");

                }
                else
                {
                    ViewBag.LoginError = "Hesap bulunamadı, yeniden deneyin ya da kaydolun!";
                    return View();
                }

            }

            else
            {
                ViewBag.LoginError = "Hatalı giriş!";
                return View();
            }

        }

        public ActionResult ResetPassword()
        {
            return View();
        }

        [HttpPost]
        public ActionResult ResetPassword(ResetPwVM rvm)
        {
            if (_proRep.Any(x => x.Email == rvm.Email))
            {
                int getId = _proRep.Where(x => x.Email == rvm.Email)
                 .Select(x => x.ID)
                 .FirstOrDefault();

                rvm.ID = getId;

                string confirmationMail = $"Şifre değişikliği yapmak için http://localhost:61894/Home/ConfirmReset/{rvm.ID} linkine tıklayabilirsiniz.";

                EmailService.ResetPassword(rvm.Email, body: confirmationMail, subject: "Şifre Değişikliği");

                ViewBag.Info = "Şifre yenilemek için size bir mail gönderdik, maildeki linke tıklamadan şifre değişikliği yapılmayacaktır!";
                return View();
            }
            return View();

        }

        public ActionResult ConfirmReset(int ID)
        {
            UserProfile updated = _proRep.Find(ID);
            ResetPwVM resetPwVM = new ResetPwVM()
            {
                ID = updated.ID,
            };

            return View();
        }

        [HttpPost]
        public ActionResult ConfirmReset(ResetPwVM resetPwVM)
        {

            //if (resetPwVM.Password == resetPwVM.PasswordConfirmed)
            //{
            //    UserProfile userProfile = _proRep.Find(resetPwVM.ID);
            //    userProfile.Password = PasswordCryptographer.Crypt(resetPwVM.Password);
            //    _proRep.Update(userProfile);
            //    TempData["SuccesMessage"] = "Şifreniz başarıyla değiştirilmiştir...";

            //    return RedirectToAction("Login");
            //}
            //else
            //{
            //    ViewBag.ErrorMessage = "Şifreler uyuşmadı.Tekrar deneyin";
            //    return View();
            //}

            if (ModelState.IsValid)
            {
                UserProfile userProfile = _proRep.Find(resetPwVM.ID);
                userProfile.Password = PasswordCryptographer.Crypt(resetPwVM.Password);
                _proRep.Update(userProfile);
                TempData["SuccesMessage"] = "Şifreniz başarıyla değiştirilmiştir...";

                return RedirectToAction("Login");
            }
            else
            {
                ViewBag.ErrorMessage = "Şifreler uyuşmadı.tekrar deneyiniz";
                return View();
            }

        }

        public ActionResult EditProfile(int id)
        {
            UserProfileVM userProfileVM = _proRep.Select(x => new UserProfileVM
            {
                Email = x.Email,
                Password = x.Password,
                Role = x.Role,
                UserName = x.UserName,
                UserProfileID = x.ID,
            }).FirstOrDefault(x => x.UserProfileID == id);

            AppUserVM appUserVM = _apRep.Select(x => new AppUserVM
            {
                AppUserID = x.ID,
                FirstName = x.FirstName,
                IdentificationNumber = x.IdentificationNumber,
                LastName = x.LastName,
                PhoneNumber = x.PhoneNumber,
            }).FirstOrDefault(x => x.AppUserID == id);

            EditProfileVM editProfileVM = new EditProfileVM()
            {
                UserProfile = userProfileVM,
                AppUser = appUserVM,
            };

            return View(editProfileVM);
        }

        [HttpPost]
        public ActionResult EditProfile(AppUserVM appUser, UserProfileVM userProfile)
        {

            AppUser user = _apRep.Find(appUser.AppUserID);
            UserProfile profile = _proRep.Find(userProfile.UserProfileID);
            user.FirstName = appUser.FirstName;
            user.LastName = appUser.LastName;
            user.IdentificationNumber = appUser.IdentificationNumber;
            profile.UserName = userProfile.UserName;
            _apRep.Update(user);
            _proRep.Update(profile);

            return RedirectToAction("Index");
        }

    }
}








