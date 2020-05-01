using System;

namespace BLL.DTOModels
{
    public class BookAddDTO
    {
        public Guid? BookId { get; set; }
        public string BookName { get; set; }
        public string BookFileAddress { get; set; }
        public string AuthorName { get; set; }легкая форма
        public string YearOfPublishing { get; set; }
        public string PublishingHouseName { get; set; }

    }
}
