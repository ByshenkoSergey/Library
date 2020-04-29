using System;

namespace BLL.DTOModels
{
    public class PublishingHouseDTO
    {
        public Guid PublishingHouseId { get; set; }
        public string PublishingHouseName { get; set; }
        public string PublishingHouseInfo { get; set; }
        public string PublishingHouseTellNumber { get; set; }
        public string PublishingHouseEmail { get; set; }
    }
}
