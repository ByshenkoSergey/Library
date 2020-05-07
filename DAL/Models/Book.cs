using System;

namespace DAL.Models
{
    public class Book
    {
        public Guid BookId { get; set; }
        public string BookName { get; set; }
        public string BookFileAddress { get; set; }
        public string YearOfPublishing { get; set; }
        public int Rating { get; set; }
        public string ContentType { get; set; }


        public Guid AuthorId { get; set; }
        public virtual Author Author { get; set; }

        public Guid PublisherId { get; set; }
        public virtual Publisher Publisher { get; set; }




    }
}