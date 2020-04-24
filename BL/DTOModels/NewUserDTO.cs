using System;

namespace BL.DTOModels
{
    public class NewUserDTO
    {
        public Guid UserId { get; set; }
        public string UserLogin { get; set; }
        public string UserPassword { get; set; }
        public string UserRole { get; set; }
        public string UserFirstName { get; set; }
        public string UserLastName { get; set; }
        public string UserYearsOld { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
    }
}
