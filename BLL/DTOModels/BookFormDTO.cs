using System;

namespace BLL.DTOModels
{
    public class BookFormDTO
    {
        public Guid BookId { get; set; }
        public string BookName { get; set; }
        public string BookFileAddress { get; set; }
        public string AuthorName { get; set; }
        public string YearOfPublishing { get; set; }
        public string PublisherName { get; set; }
        public int Rating { get; set; }

    }
}
