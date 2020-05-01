using BLL.DTOModels;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BLL.Services.Interfaces
{
    public interface IPublisherService:IDisposable
    {
        Task DeletePublisherAsync(Guid id);
        Task EditPublisherAsync(Guid id, PublisherDTO publisherDTO );
        Task<IEnumerable<PublisherDTO>> GetAllPublisherDTOAsync();
        Task<PublisherDTO> GetPublisherDTOAsync(Guid id);
        Task<Guid> AddPublisherAsync(PublisherDTO publisherDTO);
        Task<PublisherDTO> GetPublisherByNameAsync(string publisherName);
    }
}