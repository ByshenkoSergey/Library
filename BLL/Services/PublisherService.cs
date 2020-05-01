using BLL.DTOModels;
using BLL.Infrastructure.Exceptions;
using BLL.Infrastructure.Mapping;
using BLL.Services.Interfaces;
using DAL.Models;
using DAL.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BLL.Services
{
    public class PublisherService : IPublisherService
    {
        private IUnitOfWork _unit;
        private IMapConfig _mapper;

        public PublisherService(IUnitOfWork unit, IMapConfig mapper)
        {
            _unit = unit;
            _mapper = mapper;
        }

        public async Task<PublisherDTO> GetPublisherDTOAsync(Guid id)
        {
            var publisher = await _unit.PublisherRepository.GetAsync(id);

            if (publisher == null)
            {
                return null;
            }

            return _mapper.GetMapper().Map<PublisherDTO>(publisher);
        }

        public async Task DeletePublisherAsync(Guid id)
        {
            try
            {
                _unit.PublisherRepository.Delete(id);
                await _unit.SaveChangeAsync();
            }
            catch (NullReferenceException e)
            {
                throw e;
            }
        }

        public async Task<IEnumerable<PublisherDTO>> GetAllPublisherDTOAsync()
        {
            return _mapper.GetMapper().Map<IEnumerable<Publisher>, IEnumerable<PublisherDTO>>(await _unit.PublisherRepository.GetAllAsync());
        }


        public async Task EditPublisherAsync(Guid id, PublisherDTO publisherDTO)
        {
            try
            {
                var publisher = _mapper.GetMapper().Map<Publisher>(publisherDTO);
                _unit.PublisherRepository.Edit(publisher, id);
                await _unit.SaveChangeAsync();
            }

            catch (NullReferenceException e)
            {
                throw e;
            }
        }

        public async Task<Guid> AddPublisherAsync(PublisherDTO publisherDTO)
        {
            var publisher = _mapper.GetMapper().Map<Publisher>(publisherDTO);
            _unit.PublisherRepository.Add(publisher);
            await _unit.SaveChangeAsync();
            var id = await _unit.PublisherRepository.GetModelIdAsync(publisher.PublisherName);
            if (id == default)
            {
                throw new ValidationException("Publisher not found", "");
            }
            return id;
        }

        public async Task<PublisherDTO> GetPublisherByNameAsync(string publisherName)
        {
            var publisherId = await _unit.PublisherRepository.GetModelIdAsync(publisherName);
            if (publisherId == null)
            {
                return null;
            }
            var publisher = await GetPublisherDTOAsync(publisherId);
            return publisher;
        }

        public void Dispose()
        {
            _unit.Dispose();
        }

    }
}
