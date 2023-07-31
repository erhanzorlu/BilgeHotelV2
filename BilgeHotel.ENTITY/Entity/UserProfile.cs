using BilgeHotel.ENTITY.Base;
using BilgeHotel.ENTITY.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BilgeHotel.ENTITY.Entity
{
    public class UserProfile : BaseEntity
    {
        public UserProfile()
        {
            Role = UserRole.Visitor;
            ActivationCode = Guid.NewGuid();
        }
        public string UserName { get; set; }
        public string Password { get; set; }
        public Guid ActivationCode { get; set; }
        public string Email { get; set; }
        public UserRole Role { get; set; }

        //Relational Properties
        public virtual AppUser AppUser { get; set; }

     
    }

}
