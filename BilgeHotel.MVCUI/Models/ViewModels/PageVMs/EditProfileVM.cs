using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BilgeHotel.MVCUI.Models.ViewModels.PageVMs
{
    public class EditProfileVM
    {
        public UserProfileVM UserProfile { get; set; }
        public AppUserVM AppUser { get; set; }
    }
}