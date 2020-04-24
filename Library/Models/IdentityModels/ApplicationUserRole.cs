using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;

namespace DAL.Models.IdentityModels
{
    public class ApplicationUserRole : IdentityRole<Guid>
    {
        public Guid RoleId { get; set; }
        [PersonalData]
        public string RoleName { get; set; }

        public virtual IEnumerable<ApplicationUser> ApplicationUsers { get; set; }

        public ApplicationUserRole()
        {
            ApplicationUsers = new List<ApplicationUser>();
        }
    }
}
