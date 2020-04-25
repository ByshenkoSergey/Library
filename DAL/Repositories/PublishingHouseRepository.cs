using DAL.Context;
using DAL.Models;
using DAL.Repository;
using System;
using System.Threading.Tasks;

namespace DAL.Repositories
{
    class PublishingHouseRepository : Repository<PublishingHouse>
    {
        public PublishingHouseRepository(LibraryDataBaseContext context)
  : base(context) { }

        public override async Task<Guid> GetModelIdAsync(string name)
        {
            var publishingHouseList = await GetAllAsync();
            foreach (var publishingHouse in publishingHouseList)
            {
                if (publishingHouse.PublishingHouseName == name)
                {
                    return publishingHouse.PublishingHouseId;
                }
            }

            return default;
        }

    }
}
