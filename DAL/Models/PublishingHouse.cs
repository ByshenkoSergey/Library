using System;
using System.Collections.Generic;

namespace DAL.Models
{
    public class PublishingHouse
    {
        public Guid PublishingHouseId { get; set; }
        public string PublishingHouseName { get; set; }
        public string PublishingHouseInfo { get; set; }
        public string PublishingHouseTellNumber { get; set; }
        public string PublishingHouseEmail { get; set; }

        public virtual IList<Book> Books { get; set; }

        public PublishingHouse()
        {
            Books = new List<Book>();
        }

    }
}