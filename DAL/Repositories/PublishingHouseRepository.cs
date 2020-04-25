using DAL.Context;
using DAL.Models;
using DAL.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DAL.Repository
{
    public class PublishingHouseRepository : IPublishingHouseRepository
    {
        private LibraryDataBaseContext _context;

        public PublishingHouseRepository(LibraryDataBaseContext context)
        {
            this._context = context;
        }



        public void DeletePublishingHouse(Guid id)
        {

            var publishingHouse = _context.PublishingHouses.Find(id);
            if (publishingHouse == null)
            {
                throw new NullReferenceException("Publishing house not found");
            }
            _context.Entry<PublishingHouse>(publishingHouse).State = EntityState.Deleted;
            _context.PublishingHouses.Remove(publishingHouse);

        }


        public void EditPublishingHouse(PublishingHouse item, Guid id)
        {
            var publishingHouse = _context.PublishingHouses.Find(id);

            if (publishingHouse == null)
            {
                throw new NullReferenceException("PublishingHouse not found");
            }

           DeletePublishingHouse(id);
            AddPublishingHouse(item);
        }


        public async Task<PublishingHouse> GetPublishingHouseAsync(Guid id)
        {
            return await _context.PublishingHouses.FindAsync(id);
        }



        public async Task<IEnumerable<PublishingHouse>> GetAllPublishingHousesAsync()
        {
            return await _context.PublishingHouses.ToListAsync<PublishingHouse>();
        }


        public void AddPublishingHouse(PublishingHouse item)
        {
           _context.PublishingHouses.Add(item);
        }

        public async Task<Guid> GetPublishingHouseIdAsync(PublishingHouse item)
        {
            var publishingHouses = await GetAllPublishingHousesAsync();

            foreach (var publishingHouse in publishingHouses)
            {
                if (publishingHouse == item)
                    return publishingHouse.PublishingHouseId;
            }
            return default;
        }

    }
}
