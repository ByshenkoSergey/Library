using System;

namespace BLL.DTOModels
{
    public class PublisherDTO
    {
        public Guid PublisherId { get; set; }
        public string PublisherName { get; set; }
        public string PublisherInfo { get; set; }
        public string PublisherTellNumber { get; set; }
        public string PublisherEmail { get; set; }
    }
}
