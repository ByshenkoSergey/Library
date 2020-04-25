using BL.DTOModels;
using BL.Infrastructure;
using BL.Service.Interfaces;
using DAL.Models;
using DAL.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BL
{
    public class PublishingHouseService : IPublishingHouseService
    {
        private IUnitOfWork _unit;
        private IMapConfig _mapper;

        public PublishingHouseService(IUnitOfWork unit, IMapConfig mapper)
        {
            _unit = unit;
            _mapper = mapper;
        }

        public async Task<PublishingHouseDTO> GetPublishingHouseDTOAsync(Guid id)
        {
            var publishingHouse = await _unit.PublishingHouseRepository.GetAsync(id);

            if (publishingHouse == null)
            {
                return null;
            }

            return _mapper.GetMapper().Map<PublishingHouseDTO>(publishingHouse);
        }

        public async Task DeletePublishingHouseAsync(Guid id)
        {
            try
            {
                _unit.PublishingHouseRepository.Delete(id);
                await _unit.SaveChangeAsync();
            }
            catch (NullReferenceException e)
            {
                throw e;
            }
        }

        public async Task<IEnumerable<PublishingHouseDTO>> GetAllPublishingHouseDTOAsync()
        {
            return _mapper.GetMapper().Map<IEnumerable<PublishingHouse>, IEnumerable<PublishingHouseDTO>>(await _unit.PublishingHouseRepository.GetAllAsync());
        }


        public async Task EditPublishingHouseAsync(Guid id, PublishingHouseDTO publishingHouseDTO)
        {
            try
            {
                var publishingHouse = _mapper.GetMapper().Map<PublishingHouse>(publishingHouseDTO);
                _unit.PublishingHouseRepository.Edit(publishingHouse, id);
                await _unit.SaveChangeAsync();
            }

            catch (NullReferenceException e)
            {
                throw e;
            }
        }

        public async Task<Guid> AddPublishingHouseAsync(PublishingHouseDTO publishingHouseDTO)
        {
            var publishingHouse = _mapper.GetMapper().Map<PublishingHouse>(publishingHouseDTO);
            _unit.PublishingHouseRepository.Add(publishingHouse);
            await _unit.SaveChangeAsync();
            var id = await _unit.PublishingHouseRepository.GetModelIdAsync(publishingHouse.PublishingHouseName);
            if (id == default)
            {
                throw new ValidationException("Publishing house not found", "");
            }
            return id;
        }

        public void Dispose()
        {
            _unit.Dispose();
        }

    }
}
