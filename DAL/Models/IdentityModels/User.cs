using Microsoft.AspNetCore.Identity;
using System;

namespace DAL.Models.IdentityModels
{
    public class User : IdentityUser<Guid>
    {
        public Guid UserId { get; set; }
        public string UserLogin { get; set; }
        public string UserPassword { get; set; }
        public string UserFirstName { get; set; }
        public string UserLastName { get; set; }
        public string UserYearsOld { get; set; }

        public Guid ApplicationUserRoleId { get; set; }
        public virtual UserRole ApplicationUserRole { get; set; }
    }
}
