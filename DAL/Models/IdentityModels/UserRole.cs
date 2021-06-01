using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;

namespace DAL.Models.IdentityModels
{
    public class UserRole : IdentityRole<Guid>
    {
        public Guid RoleId { get; set; }
        public string RoleName { get; set; }
        public string RoleInfo { get; set; }

        public virtual IEnumerable<User> ApplicationUsers { get; set; }

        public UserRole()
        {
            ApplicationUsers = new List<User>();
        }
    }
}
