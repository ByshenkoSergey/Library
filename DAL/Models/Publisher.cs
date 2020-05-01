using System;
using System.Collections.Generic;

namespace DAL.Models
{
    public class Publisher
    {
        public Guid PublisherId { get; set; }
        public string PublisherName { get; set; }
        public string PublisherInfo { get; set; }
        public string PublisherTellNumber { get; set; }
        public string PublisherEmail { get; set; }

        public virtual IList<Book> Books { get; set; }

        public Publisher()
        {
            Books = new List<Book>();
        }

    }
}