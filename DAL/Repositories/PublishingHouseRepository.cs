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



        public async Task DeletePublishingHouseAsync(Guid id)
        {

            var publishingHouse = await _context.PublishingHouses.FindAsync(id);
            if (publishingHouse == null)
            {
                throw new NullReferenceException("Publishing house not found");
            }
            _context.Entry<PublishingHouse>(publishingHouse).State = EntityState.Deleted;
            _context.PublishingHouses.Remove(publishingHouse);

        }


        public async Task EditPublishingHouseAsync(PublishingHouse item, Guid id)
        {
            var publishingHouse = await _context.PublishingHouses.FindAsync(id);

            if (publishingHouse == null)
            {
                throw new NullReferenceException("PublishingHouse not found");
            }

            await DeletePublishingHouseAsync(id);
            await _context.SaveChangesAsync();
            await _context.PublishingHouses.AddAsync(item);
        }


        public async Task<PublishingHouse> GetPublishingHouseAsync(Guid id)
        {
            return await _context.PublishingHouses.FindAsync(id);
        }



        public async Task<IEnumerable<PublishingHouse>> GetAllPublishingHousesAsync()
        {
            return await _context.PublishingHouses.ToListAsync<PublishingHouse>();
        }


        public async Task InsertPublishingHouseAsync(PublishingHouse item)
        {
            await _context.PublishingHouses.AddAsync(item);
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
