using DAL.Context;
using DAL.Models;
using DAL.Repository;
using Microsoft.Extensions.Logging;
using System;
using System.Threading.Tasks;

namespace DAL.Repositories
{
    class PublisherRepository : Repository<Publisher>
    {
        private readonly ILogger<PublisherRepository> _logger;
        public PublisherRepository(LibraryDataBaseContext context, ILogger<PublisherRepository> logger)
  : base(context, logger) 
        {
            _logger = logger;
            _logger.LogInformation("Dependency injection successfully");
        }

        public override async Task<Guid> GetModelIdAsync(string name)
        {
            var PublisherList = await GetAllAsync();
            foreach (var Publisher in PublisherList)
            {
                if (Publisher.PublisherName == name)
                {
                    _logger.LogInformation("Return publisher id");
                    return Publisher.PublisherId;
                }
            }
            _logger.LogWarning("Publisher not found, return default");
            return default;
        }

    }
}
