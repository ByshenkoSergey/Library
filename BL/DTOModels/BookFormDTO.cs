using System;
using System.Collections.Generic;

namespace BL.DTOModels
{
    public class BookFormDTO
    {
        public Guid BookId { get; set; }
        public string BookName { get; set; }
        public string BookFileAddress { get; set; }
        public string AuthorName { get; set; }
        public string YearOfPublishing { get; set; }
        public string PublishingHouseName { get; set; }
        public int Rating { get; set; }

    }
}
