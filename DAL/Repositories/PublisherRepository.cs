using DAL.Context;
using DAL.Models;
using DAL.Repository;
using System;
using System.Threading.Tasks;

namespace DAL.Repositories
{
    class PublisherRepository : Repository<Publisher>
    {
        public PublisherRepository(LibraryDataBaseContext context)
  : base(context) { }

        public override async Task<Guid> GetModelIdAsync(string name)
        {
            var PublisherList = await GetAllAsync();
            foreach (var Publisher in PublisherList)
            {
                if (Publisher.PublisherName == name)
                {
                    return Publisher.PublisherId;
                }
            }

            return default;
        }

    }
}
