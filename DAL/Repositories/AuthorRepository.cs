using DAL.Context;
using DAL.Models;
using DAL.Repository;
using Microsoft.Extensions.Logging;
using System;
using System.Threading.Tasks;

namespace DAL.Repositories
{
    public class AuthorRepository : Repository<Author>
    {
        private readonly ILogger<AuthorRepository> _logger;
        public AuthorRepository(LibraryDataBaseContext context, ILogger<AuthorRepository> logger)
    : base(context, logger) 
        {
            _logger = logger;
            _logger.LogInformation("Dependency injection successfully");
        }

        public override async Task<Guid> GetModelIdAsync(string name)
        {
            var authorList = await GetAllAsync();
            foreach (var author in authorList)
            {
                if (author.AuthorName == name)
                {
                    _logger.LogInformation("Return author id");
                    return author.AuthorId;
                }
            }
            _logger.LogWarning("Author not found, return default");
            return default;
        }
    }
}
