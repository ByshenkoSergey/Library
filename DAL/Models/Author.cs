using System;
using System.Collections.Generic;

namespace DAL.Models
{
    public class Author
    {
        public Guid AuthorId { get; set; }
        public string AuthorName { get; set; }
        public string AuthorBiography { get; set; }

        public virtual IEnumerable<Book> Books { get; set; }

        public Author()
        {
            Books = new List<Book>();
        }
    }
}