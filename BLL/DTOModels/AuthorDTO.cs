using System;

namespace BLL.DTOModels
{
    public class AuthorDTO
    {
        public Guid AuthorId { get; set; }
        public string AuthorName { get; set; }
        public string AuthorBiography { get; set; }

    }
}
