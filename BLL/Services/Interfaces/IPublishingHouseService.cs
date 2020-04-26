using BLL.DTOModels;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BLL.Services.Interfaces
{
    public interface IPublishingHouseService:IDisposable
    {
        Task DeletePublishingHouseAsync(Guid id);
        Task EditPublishingHouseAsync(Guid id, PublishingHouseDTO publishingHouseDTO );
        Task<IEnumerable<PublishingHouseDTO>> GetAllPublishingHouseDTOAsync();
        Task<PublishingHouseDTO> GetPublishingHouseDTOAsync(Guid id);
        Task<Guid> AddPublishingHouseAsync(PublishingHouseDTO publishingHouseDTO);
    }
}