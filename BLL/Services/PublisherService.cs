using BLL.DTOModels;
using BLL.Infrastructure.Mapping;
using BLL.Services.Interfaces;
using DAL.Models;
using DAL.UnitOfWork;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BLL.Services
{
    public class PublisherService : IPublisherService
    {
        private readonly IUnitOfWork _unit;
        private readonly IMapConfig _mapper;
        private readonly ILogger<PublisherService> _logger;

        public PublisherService(IUnitOfWork unit, IMapConfig mapper, ILogger<PublisherService> logger)
        {
            _unit = unit;
            _mapper = mapper;
            _logger = logger;
            _logger.LogInformation("Dependency injection successfully");
        }

        public async Task<PublisherDTO> GetPublisherDTOAsync(Guid id)
        {
            var publisher = await _unit.PublisherRepository.GetAsync(id);

            if (publisher == null)
            {
                _logger.LogWarning("Publisher not found");
                return null;
            }

            _logger.LogInformation("Return publisher DTO");
            return _mapper.GetMapper().Map<PublisherDTO>(publisher);
        }

        public async Task DeletePublisherAsync(Guid id)
        {
            try
            {
                _unit.PublisherRepository.Delete(id);
                await _unit.SaveChangeAsync();
                _logger.LogInformation("Publisher is deleted");
            }
            catch (NullReferenceException e)
            {
                _logger.LogError($"Error - {e.Message}");
                throw e;
            }
        }

        public async Task<IEnumerable<PublisherDTO>> GetAllPublisherDTOAsync()
        {
            var publisherList = await _unit.PublisherRepository.GetAllAsync();
            var publisherListDTO = _mapper.GetMapper().Map<IEnumerable<Publisher>, IEnumerable<PublisherDTO>>(publisherList);
            _logger.LogInformation("Return publisher list DTO");
            return publisherListDTO;
        }


        public async Task EditPublisherAsync(Guid id, PublisherDTO publisherDTO)
        {
            try
            {
                var publisher = _mapper.GetMapper().Map<Publisher>(publisherDTO);
                _unit.PublisherRepository.Edit(publisher, id);
                await _unit.SaveChangeAsync();
                _logger.LogInformation("Publisher is puted");
            }

            catch (NullReferenceException e)
            {
                _logger.LogError($"Error - {e.Message}");
                throw e;
            }
        }

        public void Dispose()
        {
            _unit.Dispose();
            _logger.LogInformation("Publisher repository is disposed");
        }

    }
}
