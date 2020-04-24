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
        Task InsertPublishingHouseAsync(PublishingHouse item);
        Task EditPublishingHouseAsync(PublishingHouse item, Guid id);
        Task DeletePublishingHouseAsync(Guid id);
        Task<Guid> GetPublishingHouseIdAsync(PublishingHouse item);
    }
}
