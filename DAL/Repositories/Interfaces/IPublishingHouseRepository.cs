using DAL.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DAL.Repository.Interfaces
{
    public interface IPublishingHouseRepository 
    {
        Task<IEnumerable<PublishingHouse>> GetAllPublishingHousesAsync();
        Task<PublishingHouse> GetPublishingHouseAsync(Guid id);
        void AddPublishingHouse(PublishingHouse item);
        void EditPublishingHouse(PublishingHouse item, Guid id);
        void DeletePublishingHouse(Guid id);
        Task<Guid> GetPublishingHouseIdAsync(PublishingHouse item);
    }
}
