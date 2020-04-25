using Microsoft.AspNetCore.Identity;
using System;

namespace DAL.Models.IdentityModels
{
    public class User : IdentityUser<Guid>
    {
        public Guid UserId { get; set; }
        [PersonalData]
        public string UserLogin { get; set; }
        [PersonalData]
        public string UserPassword { get; set; }
        [PersonalData]
        public string UserFirstName { get; set; }
        [PersonalData]
        public string UserLastName { get; set; }
        [PersonalData]
        public string UserYearsOld { get; set; }


        public Guid ApplicationUserRoleId { get; set; }
        public virtual UserRole ApplicationUserRole { get; set; }

    }
}
